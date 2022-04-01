import { AisModal } from "@ais-gorod/react-ui";
import { useCallback } from "react";
import { useHistory } from "react-router-dom";
import { ScheduleCreateRequest, WorkersWagesApiClient, Time } from "../../services/WorkersWagesApiClient";
import { SchedulesEditForm, FormValues } from './SchedulesEditForm';

interface Props {
    onDataChanged: () => void;
}

export const SchedulesCreateModal = (props: Props) => {
    const history = useHistory();

    const propsOnDataChanged = props.onDataChanged;
    const handleSubmit = useCallback(async (data: FormValues) => {
        const schedule = new ScheduleCreateRequest({
            manufactoryId: data.manufactoryId,
            weekDay: data.weekDay,
            workingStart: data.workingStart ? new Time({ hours: data.workingStart.getHours(), minutes: data.workingStart.getMinutes() }) : undefined,
            workingEnd: data.workingEnd ? new Time({ hours: data.workingEnd.getHours(), minutes: data.workingEnd.getMinutes() }) : undefined,
            breakStart: data.breakStart ? new Time({ hours: data.breakStart.getHours(), minutes: data.breakStart.getMinutes() }) : undefined,
            breakEnd: data.breakEnd ? new Time({ hours: data.breakEnd.getHours(), minutes: data.breakEnd.getMinutes() }) : undefined,
        });
        const apiClient = new WorkersWagesApiClient('/extapi');
        await apiClient.schedulesCreate(schedule).then((_) => {
            history.goBack();
            propsOnDataChanged();
        });
    }, [history, propsOnDataChanged]);

    return (
        <AisModal show={true} onHide={() => history.goBack()} title="Добавление графика работы цеха">
            <SchedulesEditForm onSubmit={handleSubmit} />
        </AisModal>
    );
};

SchedulesCreateModal.displayName = 'SchedulesCreateModal';
