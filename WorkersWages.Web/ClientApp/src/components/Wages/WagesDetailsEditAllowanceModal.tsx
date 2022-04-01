import { AisModal } from "@ais-gorod/react-ui";
import { useCallback, useEffect, useState } from "react";
import { useHistory, useParams } from "react-router-dom";
import { WageEditAllowanceRequest, WorkersWagesApiClient, Time } from "../../services/WorkersWagesApiClient";
import { WagesDetailsEditAllowanceForm } from './WagesDetailsEditAllowanceForm';

interface Props {
    onDataChanged: () => void;
}

export const WagesDetailsEditAllowanceModal = (props: Props) => {
    const history = useHistory();
    const { wageId, allowanceId } = useParams() as {
        wageId: string;
        allowanceId: string;
    };

    const [allowanceInfo, setAllowanceInfo] = useState<WageEditAllowanceRequest>();
    useEffect(() => {
        /* TODO: Добавить в АПИ подробности на все сущности для вытаскивания данных при редактировании */
    }, [wageId, allowanceId])

    const propsOnDataChanged = props.onDataChanged;
    const handleSubmit = useCallback(async (data: WageEditAllowanceRequest) => {
        if (!wageId || !allowanceId) return;

        const apiClient = new WorkersWagesApiClient('/extapi');
        await apiClient.wagesEditAllowance(+wageId, +allowanceId, data).then((_) => {
            history.goBack();
            propsOnDataChanged();
        });
    }, [history, propsOnDataChanged]);

    return (
        <AisModal show={true} onHide={() => history.goBack()} title="Редактирование надбавки к заработной плате">
            <WagesDetailsEditAllowanceForm onSubmit={handleSubmit} data={allowanceInfo} />
        </AisModal>
    );
};

WagesDetailsEditAllowanceModal.displayName = 'WagesDetailsEditAllowanceModal';
