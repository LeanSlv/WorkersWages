import { AisModal } from "@ais-gorod/react-ui";
import { useCallback } from "react";
import { useHistory } from "react-router-dom";
import { ProfessionCreateRequest, WorkersWagesApiClient } from "../../services/WorkersWagesApiClient";
import { ProfessionsEditForm } from './ProfessionsEditForm';

interface Props {
    onDataChanged: () => void;
}

export const ProfessionsCreateModal = (props: Props) => {
    const history = useHistory();

    const propsOnDataChanged = props.onDataChanged;
    const handleSubmit = useCallback(async (data: ProfessionCreateRequest) => {
        const apiClient = new WorkersWagesApiClient('/extapi');
        await apiClient.professionsCreate(data).then((_) => {
            history.goBack();
            propsOnDataChanged();
        });
    }, [history, propsOnDataChanged]);

    return (
        <AisModal show={true} onHide={() => history.goBack()} title="Добавление профессии">
            <ProfessionsEditForm onSubmit={handleSubmit} />
        </AisModal>
    );
};

ProfessionsCreateModal.displayName = 'ProfessionsCreateModal';
