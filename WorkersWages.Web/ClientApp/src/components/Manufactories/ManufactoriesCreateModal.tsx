import { AisModal } from "@ais-gorod/react-ui";
import { useCallback } from "react";
import { useHistory } from "react-router-dom";
import { ManufactoryCreateRequest, WorkersWagesApiClient } from "../../services/WorkersWagesApiClient";
import { ManufactoriesEditForm } from './ManufactoriesEditForm';

interface Props {
    onDataChanged: () => void;
}

export const ManufactoriesCreateModal = (props: Props) => {
    const history = useHistory();

    const propsOnDataChanged = props.onDataChanged;
    const handleSubmit = useCallback(async (data: ManufactoryCreateRequest) => {
        const apiClient = new WorkersWagesApiClient('/extapi');
        await apiClient.manufactoriesCreate(data).then((_) => {
            history.goBack();
            propsOnDataChanged();
        });
    }, [history, propsOnDataChanged]);

    return (
        <AisModal show={true} onHide={() => history.goBack()} title="Добавление цеха">
            <ManufactoriesEditForm onSubmit={handleSubmit} />
        </AisModal>
    );
};

ManufactoriesCreateModal.displayName = 'ManufactoriesCreateModal';
