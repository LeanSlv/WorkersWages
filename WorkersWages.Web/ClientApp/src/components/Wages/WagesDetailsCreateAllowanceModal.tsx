import { AisModal } from "@ais-gorod/react-ui";
import { useCallback } from "react";
import { useHistory, useParams } from "react-router-dom";
import { WageAddAllowanceRequest, WorkersWagesApiClient } from "../../services/WorkersWagesApiClient";
import { WagesDetailsEditAllowanceForm } from './WagesDetailsEditAllowanceForm';

interface Props {
    onDataChanged: () => void;
}

export const WagesDetailsCreateAllowanceModal = (props: Props) => {
    const history = useHistory();
    const { wageId } = useParams() as {
        wageId: string;
    };

    const propsOnDataChanged = props.onDataChanged;
    const handleSubmit = useCallback(async (data: WageAddAllowanceRequest) => {
        if (!wageId) return;
        const apiClient = new WorkersWagesApiClient('/extapi');
        await apiClient.wagesAddAllowance(+wageId, data).then((_) => {
            history.goBack();
            propsOnDataChanged();
        });
    }, [history, propsOnDataChanged]);

    return (
        <AisModal show={true} onHide={() => history.goBack()} title="Добавление надбавки к заработной плате">
            <WagesDetailsEditAllowanceForm onSubmit={handleSubmit} />
        </AisModal>
    );
};

WagesDetailsCreateAllowanceModal.displayName = 'WagesDetailsCreateAllowanceModal';
