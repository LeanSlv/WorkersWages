import { AisModal } from "@ais-gorod/react-ui";
import { useCallback, useEffect, useState } from "react";
import { useHistory, useParams } from "react-router-dom";
import { ScheduleEditRequest, WorkersWagesApiClient, Time } from "../../services/WorkersWagesApiClient";
import { SchedulesEditForm, FormValues } from './SchedulesEditForm';

interface Props {
    onDataChanged: () => void;
}

const apiClient = new WorkersWagesApiClient('/extapi');

export const SchedulesEditModal = (props: Props) => {
    const history = useHistory();
    const { id } = useParams() as {
        id: string;
    };

    const [scheduleInfo, setScheduleInfo] = useState<FormValues>();
    useEffect(() => {
        if (!id) return;

        apiClient.schedulesDetails(+id).then((r) => setScheduleInfo({
            manufactoryId: r.manufactoryId,
            weekDay: r.weekDay,
            workingStart: r.workingStart ? new Date(1, 1, 1, r.workingStart.hours, r.workingStart.minutes) : undefined,
            workingEnd: r.workingEnd ? new Date(1, 1, 1, r.workingEnd.hours, r.workingEnd.minutes) : undefined,
            breakStart: r.breakStart ? new Date(1, 1, 1, r.breakStart.hours, r.breakStart.minutes) : undefined,
            breakEnd: r.breakEnd ? new Date(1, 1, 1, r.breakEnd.hours, r.breakEnd.minutes) : undefined,
        }));
    }, [id])

    const propsOnDataChanged = props.onDataChanged;
    const handleSubmit = useCallback(async (data: FormValues) => {
        if (!id) return;

        const schedule = new ScheduleEditRequest({
            manufactoryId: data.manufactoryId,
            weekDay: data.weekDay,
            workingStart: data.workingStart ? new Time({ hours: data.workingStart.getHours(), minutes: data.workingStart.getMinutes() }) : undefined,
            workingEnd: data.workingEnd ? new Time({ hours: data.workingEnd.getHours(), minutes: data.workingEnd.getMinutes() }) : undefined,
            breakStart: data.breakStart ? new Time({ hours: data.breakStart.getHours(), minutes: data.breakStart.getMinutes() }) : undefined,
            breakEnd: data.breakEnd ? new Time({ hours: data.breakEnd.getHours(), minutes: data.breakEnd.getMinutes() }) : undefined,
        });

        await apiClient.schedulesEdit(+id, schedule).then((_) => {
            history.goBack();
            propsOnDataChanged();
        });
    }, [id, history, propsOnDataChanged]);

    if (!scheduleInfo) return null;

    return (
        <AisModal show={true} onHide={() => history.goBack()} title="Редактирование графика работы цеха">
            <SchedulesEditForm onSubmit={handleSubmit} data={scheduleInfo} />
        </AisModal>
    );
};

SchedulesEditModal.displayName = 'SchedulesEditModal';
