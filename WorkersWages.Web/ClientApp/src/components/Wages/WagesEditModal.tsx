import { AisModal } from "@ais-gorod/react-ui";
import { useCallback, useEffect, useState } from "react";
import { WageEditRequest, WorkersWagesApiClient } from "../../services/WorkersWagesApiClient";
import { WagesEditForm } from './WagesEditForm';

interface Props {
    id: number;
    onHide: () => void;
    onDataChanged: () => void;
}

const apiClient = new WorkersWagesApiClient('/extapi');

export const WagesEditModal = (props: Props) => {
    const id = props.id;
    const [wageInfo, setWageInfo] = useState<WageEditRequest>();
    useEffect(() => {
        if (!id) return;

        apiClient.wagesDetails(id).then((r) => setWageInfo(
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

        await apiClient.wagesEdit(id, data).then((_) => propsOnDataChanged());
    }, [id, history, propsOnDataChanged]);

    return (
        <AisModal show={true} onHide={props.onHide} title="Редактирование заработной платы">
            <WagesEditForm onSubmit={handleSubmit} data={wageInfo} />
        </AisModal>
    );
};

WagesEditModal.diaplayName = 'WagesEditModal';
