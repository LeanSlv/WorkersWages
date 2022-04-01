import { AisModal } from "@ais-gorod/react-ui";
import { useCallback, useEffect, useState } from "react";
import { useHistory, useParams } from "react-router-dom";
import { WageEditRequest, WorkersWagesApiClient } from "../../services/WorkersWagesApiClient";
import { WagesEditForm } from './WagesEditForm';

interface Props {
    onDataChanged: () => void;
}

const apiClient = new WorkersWagesApiClient('/extapi');

export const WagesEditModal = (props: Props) => {
    const history = useHistory();
    const { id } = useParams() as {
        id: string;
    };

    const [wageInfo, setWageInfo] = useState<WageEditRequest>();
    useEffect(() => {
        if (!id) return;

        apiClient.wagesDetails(+id).then((r) => setWageInfo(
            new WageEditRequest({
                workerLastName: r.workerLastName,
                manufactoryId: 1, // TODO: добавить в вывод ИД цеха
                professionId: 1, // TODO: добавить вывод ИД профессии
                rank: 1, // TODO: добавить вывод разряда профессии
            })
        ));
    }, [id])

    const propsOnDataChanged = props.onDataChanged;
    const handleSubmit = useCallback(async (data: WageEditRequest) => {
        if (!id) return;

        await apiClient.wagesEdit(+id, data).then((_) => {
            history.goBack();
            propsOnDataChanged();
        });
    }, [id, history, propsOnDataChanged]);

    return (
        <AisModal show={true} onHide={() => history.goBack()} title="Редактирование заработной платы">
            <WagesEditForm onSubmit={handleSubmit} data={wageInfo} />
        </AisModal>
    );
};

WagesEditModal.diaplayName = 'WagesEditModal';
