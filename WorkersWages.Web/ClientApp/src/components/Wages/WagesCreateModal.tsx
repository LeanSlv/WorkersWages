import { AisModal } from "@ais-gorod/react-ui";
import { useCallback } from "react";
import { useHistory } from "react-router-dom";
import { WageCreateRequest, WorkersWagesApiClient } from "../../services/WorkersWagesApiClient";
import { WagesEditForm } from './WagesEditForm';

interface Props {
    onDataChanged: () => void;
}

export const WagesCreateModal = (props: Props) => {
    const history = useHistory();

    const propsOnDataChanged = props.onDataChanged;
    const handleSubmit = useCallback(async (data: WageCreateRequest) => {
        const apiClient = new WorkersWagesApiClient('/extapi');
        await apiClient.wagesCreate(data).then((_) => {
            history.goBack();
            propsOnDataChanged();
        });
    }, [history, propsOnDataChanged]);

    return (
        <AisModal show={true} onHide={() => history.goBack()} title="Добавление заработной платы">
            <WagesEditForm onSubmit={handleSubmit} />
        </AisModal>
    );
};

WagesCreateModal.displayName = 'WagesCreateModal';
