import { AisButton, AisForm, AisFormField, Yup } from "@ais-gorod/react-ui";
import { WageEditAllowanceRequest } from "../../services/WorkersWagesApiClient";

interface Props {
    data?: WageEditAllowanceRequest;
    onSubmit: (data: WageEditAllowanceRequest) => void;
}

const validationSchema = Yup.object().shape({
    name: Yup.string().required(),
    amount: Yup.number().required(),
});

export const WagesDetailsEditAllowanceForm = (props: Props) => {
    return (
        <AisForm onSubmit={props.onSubmit} validationSchema={validationSchema} initialValues={props.data}>
            <AisFormField.Text label="Название" name="name" />
            <AisFormField.Number label="Размер" name="amount" />
            <AisButton type="submit">Сохранить</AisButton>
        </AisForm>
    );
};

WagesDetailsEditAllowanceForm.displayName = 'WagesDetailsEditAllowanceForm';
