import { AisButton, AisForm, AisFormField, Yup, AisSelectOption } from "@ais-gorod/react-ui";
import { WageEditRequest, WorkersWagesApiClient } from "../../services/WorkersWagesApiClient";

interface Props {
    data?: WageEditRequest;
    onSubmit: (data: WageEditRequest) => void;
}

const validationSchema = Yup.object().shape({
    workerLastName: Yup.string().required(),
    manufactoryId: Yup.number().required(),
    professionId: Yup.number().required(),
    rank: Yup.number().required()
});

const apiClient = new WorkersWagesApiClient('/extapi');

const manufactoryIdOptions = async (inputValue: string, value: string | number | undefined, callback: (options: AisSelectOption<number>[]) => void) => {
    const data = await apiClient.manufactoriesList(inputValue, undefined, 20, 0);
    const options = data.manufactories?.map((item) => {
        return { value: item.id ?? 0, label: item.name };
    });
    callback(options);
};

const professionIdOptions = async (inputValue: string, value: string | number | undefined, callback: (options: AisSelectOption<number>[]) => void) => {
    const data = await apiClient.professionsList(inputValue, 20, 0);
    const options = data.professions?.map((item) => {
        return { value: item.id ?? 0, label: item.name };
    });
    callback(options);
};

export const WagesEditForm = (props: Props) => {
    return (
        <AisForm onSubmit={props.onSubmit} validationSchema={validationSchema} initialValues={props.data}>
            <AisFormField.Text label="Фамилия рабочего" name="workerLastName" />
            <AisFormField.SelectAsync label="Цех" name="manufactoryId" loadOptions={manufactoryIdOptions} />
            <AisFormField.SelectAsync label="Профессия" name="professionId" loadOptions={professionIdOptions} />
            <AisFormField.Number label="Разряд" name="rank" />
            <AisButton type="submit">Сохранить</AisButton>
        </AisForm>
    );
};

WagesEditForm.displayName = 'WagesEditForm';
