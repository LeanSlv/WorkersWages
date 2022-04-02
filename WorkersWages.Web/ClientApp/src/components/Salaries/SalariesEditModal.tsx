import { AisModal } from "@ais-gorod/react-ui";
import { useCallback, useEffect, useState } from "react";
import { useHistory, useParams } from "react-router-dom";
import { SalaryEditRequest, WorkersWagesApiClient } from "../../services/WorkersWagesApiClient";
import { SalariesEditForm } from './SalariesEditForm';

interface Props {
    onDataChanged: () => void;
}

const apiClient = new WorkersWagesApiClient('/extapi');

export const SalariesEditModal = (props: Props) => {
    const history = useHistory();
    const { id } = useParams() as {
        id: string;
    };

    const [salaryInfo, setSalaryInfo] = useState<SalaryEditRequest>();
    useEffect(() => {
        if (!id) return;

        apiClient.salariesDetails(+id).then((r) => setSalaryInfo(
            new SalaryEditRequest({
                professionId: r.professionId,
                rank: r.rank,
                amount: r.amount,
            })
        ));
    }, [id])

    const propsOnDataChanged = props.onDataChanged;
    const handleSubmit = useCallback(async (data: SalaryEditRequest) => {
        if (!id) return;

        await apiClient.salariesEdit(+id, data).then((_) => {
            history.goBack();
            propsOnDataChanged();
        });
    }, [id, history, propsOnDataChanged]);

    return (
        <AisModal show={true} onHide={() => history.goBack()} title="Редактирование оклада">
            <SalariesEditForm onSubmit={handleSubmit} data={salaryInfo} />
        </AisModal>
    );
};

SalariesEditModal.displayName = 'SalariesEditModal';
