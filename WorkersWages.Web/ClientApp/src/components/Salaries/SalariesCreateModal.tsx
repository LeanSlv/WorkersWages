import { AisModal } from "@ais-gorod/react-ui";
import { useCallback } from "react";
import { useHistory } from "react-router-dom";
import { SalaryEditRequest, WorkersWagesApiClient } from "../../services/WorkersWagesApiClient";
import { SalariesEditForm } from './SalariesEditForm';

interface Props {
    onDataChanged: () => void;
}

export const SalariesCreateModal = (props: Props) => {
    const history = useHistory();

    const propsOnDataChanged = props.onDataChanged;
    const handleSubmit = useCallback(async (data: SalaryEditRequest) => {
        const apiClient = new WorkersWagesApiClient('/extapi');
        await apiClient.salariesCreate(data).then((_) => {
            history.goBack();
            propsOnDataChanged();
        });
    }, [history, propsOnDataChanged]);

    return (
        <AisModal show={true} onHide={() => history.goBack()} title="Добавление оклада">
            <SalariesEditForm onSubmit={handleSubmit} />
        </AisModal>
    );
};

SalariesCreateModal.displayName = 'SalariesCreateModal';
