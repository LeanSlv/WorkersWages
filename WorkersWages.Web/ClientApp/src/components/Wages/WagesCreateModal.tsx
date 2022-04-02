import { AisModal } from "@ais-gorod/react-ui";
import { useCallback } from "react";
import { WageCreateRequest, WorkersWagesApiClient } from "../../services/WorkersWagesApiClient";
import { WagesEditForm } from './WagesEditForm';

interface Props {
    onHide: () => void;
    onDataChanged: () => void;
}

export const WagesCreateModal = (props: Props) => {
    const propsOnDataChanged = props.onDataChanged;
    const propsOnHide = props.onHide;
    const handleSubmit = useCallback(async (data: WageCreateRequest) => {
        const apiClient = new WorkersWagesApiClient('/extapi');
        await apiClient.wagesCreate(data).then((_) => {
            propsOnHide();
            propsOnDataChanged();
        });
    }, [history, propsOnDataChanged, propsOnHide]);

    return (
        <AisModal show={true} onHide={props.onHide} title="Добавление заработной платы">
            <WagesEditForm onSubmit={handleSubmit} />
        </AisModal>
    );
};

WagesCreateModal.displayName = 'WagesCreateModal';
