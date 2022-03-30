import { AisButton, AisForm, AisFormField, Yup } from "@ais-gorod/react-ui";
import { ProfessionEditRequest } from "../../services/WorkersWagesApiClient";

interface Props {
    data?: ProfessionEditRequest;
    onSubmit: (data: ProfessionEditRequest) => void;
}

const validationSchema = Yup.object().shape({
    name: Yup.string().required()
});

export const ProfessionsEditForm = (props: Props) => {
    return (
        <AisForm onSubmit={props.onSubmit} validationSchema={validationSchema} initialValues={props.data}>
            <AisFormField.Text label="Название" name="name" />
            <AisButton type="submit">Сохранить</AisButton>
        </AisForm>
    );
};

ProfessionsEditForm.displayName = 'ProfessionsEditForm';
