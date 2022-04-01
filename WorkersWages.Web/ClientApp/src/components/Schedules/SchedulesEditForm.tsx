import { AisButton, AisForm, AisFormField, Yup, AisSelectOption, AisGrid } from "@ais-gorod/react-ui";
import { ScheduleEditRequest, WeekDays, WorkersWagesApiClient } from "../../services/WorkersWagesApiClient";
import { FormFieldTimePicker } from '../TimePicker/FormFieldTimePicker';

export interface FormValues {
    manufactoryId: number;
    weekDay: WeekDays;
    workingStart?: Date;
    workingEnd?: Date
    breakStart?: Date
    breakEnd?: Date
}

interface Props {
    data?: FormValues;
    onSubmit: (data: FormValues) => void;
}

const validationSchema = Yup.object().shape({
    manufactoryId: Yup.number().required(),
    weekDay: Yup.mixed<WeekDays>().required(),
    workingStart: Yup.date(),
    workingEnd: Yup.date(),
    breakStart: Yup.date(),
    breakEnd: Yup.date(),
});

const manufactoryIdOptions = async (inputValue: string, value: string | number | undefined, callback: (options: AisSelectOption<number>[]) => void) => {
    const apiClient = new WorkersWagesApiClient('/extapi');
    const data = await apiClient.manufactoriesGET(inputValue, undefined, 20, 0);
    const options = data.manufactories?.map((item) => {
        return { value: item.id ?? 0, label: item.name };
    });
    callback(options);
};

const weekDayOptions = [
    { value: WeekDays.Monday, label: 'Понедельник' },
    { value: WeekDays.Tuesday, label: 'Вторник' },
    { value: WeekDays.Wednesday, label: 'Среда' },
    { value: WeekDays.Thursday, label: 'Четверг' },
    { value: WeekDays.Friday, label: 'Пятница' },
    { value: WeekDays.Saturday, label: 'Суббота' },
    { value: WeekDays.Sunday, label: 'Воскресенье' },
];

export const SchedulesEditForm = (props: Props) => {
    return (
        <AisForm onSubmit={props.onSubmit} validationSchema={validationSchema} initialValues={props.data}>
            <AisFormField.SelectAsync label="Цех" name="manufactoryId" loadOptions={manufactoryIdOptions} />
            <AisFormField.Select label="День недели" name="weekDay" options={weekDayOptions} />
            <AisGrid.Row>
                <AisGrid.Col>
                    <FormFieldTimePicker label="Время начала работы" name="workingStart" />
                </AisGrid.Col>
                <AisGrid.Col>
                    <FormFieldTimePicker label="Время окончания работы" name="workingEnd" />
                </AisGrid.Col>
            </AisGrid.Row>
            <AisGrid.Row>
                <AisGrid.Col>
                    <FormFieldTimePicker label="Время начала перерыва" name="breakStart" />
                </AisGrid.Col>
                <AisGrid.Col>
                    <FormFieldTimePicker label="Время окончания перерыва" name="breakEnd" />
                </AisGrid.Col>
            </AisGrid.Row>           
            <AisButton type="submit">Сохранить</AisButton>
        </AisForm>
    );
};

SchedulesEditForm.displayName = 'SchedulesEditForm';
