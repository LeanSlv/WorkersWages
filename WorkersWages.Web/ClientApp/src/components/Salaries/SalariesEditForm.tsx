import { AisButton, AisForm, AisFormField, Yup } from "@ais-gorod/react-ui";
import { SalaryEditRequest } from "../../services/WorkersWagesApiClient";

interface Props {
    data?: SalaryEditRequest;
    onSubmit: (data: SalaryEditRequest) => void;
}

const validationSchema = Yup.object().shape({
    name: Yup.string().required()
});

export const SalariesEditForm = (props: Props) => {
    return (
        <AisForm onSubmit={props.onSubmit} validationSchema={validationSchema} initialValues={props.data}>
            <AisFormField.Text label="Название" name="name" />
            <AisButton type="submit">Сохранить</AisButton>
        </AisForm>
    );
};

SalariesEditForm.displayName = 'SalariesEditForm';
