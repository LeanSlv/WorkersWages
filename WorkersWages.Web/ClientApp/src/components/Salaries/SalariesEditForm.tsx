import { AisButton, AisForm, AisFormField, Yup, AisSelectOption } from "@ais-gorod/react-ui";
import { SalaryEditRequest, WorkersWagesApiClient } from "../../services/WorkersWagesApiClient";

interface Props {
    data?: SalaryEditRequest;
    onSubmit: (data: SalaryEditRequest) => void;
}

const validationSchema = Yup.object().shape({
    professionId: Yup.number().required(),
    rank: Yup.number().required(),
    amount: Yup.number().required()
});

const professionIdOptions = async (inputValue: string, value: string | number | undefined, callback: (options: AisSelectOption<number>[]) => void) => {
    const apiClient = new WorkersWagesApiClient('/extapi');
    const data = await apiClient.professionsList(inputValue, 20, 0);
    const options = data.professions?.map((item) => {
        return { value: item.id ?? 0, label: item.name };
    });
    callback(options);
};

export const SalariesEditForm = (props: Props) => {
    return (
        <AisForm onSubmit={props.onSubmit} validationSchema={validationSchema} initialValues={props.data}>
            <AisFormField.SelectAsync label="Профессия" name="professionId" loadOptions={professionIdOptions} />
            <AisFormField.Text label="Разряд" name="rank" />
            <AisFormField.Text label="Сумма" name="amount" />
            <AisButton type="submit">Сохранить</AisButton>
        </AisForm>
    );
};

SalariesEditForm.displayName = 'SalariesEditForm';
