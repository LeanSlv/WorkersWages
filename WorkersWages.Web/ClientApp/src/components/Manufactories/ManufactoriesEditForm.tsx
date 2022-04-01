import { AisButton, AisForm, AisFormField, Yup } from "@ais-gorod/react-ui";
import { ManufactoryEditRequest } from "../../services/WorkersWagesApiClient";

interface Props {
    data?: ManufactoryEditRequest;
    onSubmit: (data: ManufactoryEditRequest) => void;
}

const validationSchema = Yup.object().shape({
    name: Yup.string().required(),
    number: Yup.string().required(),
    headFIO: Yup.string()
});

export const ManufactoriesEditForm = (props: Props) => {
    return (
        <AisForm onSubmit={props.onSubmit} validationSchema={validationSchema} initialValues={props.data}>
            <AisFormField.Text label="Название" name="name" />
            <AisFormField.Text label="Номер" name="number" />
            <AisFormField.Text label="ФИО начальника" name="headFIO" />
            <AisButton type="submit">Сохранить</AisButton>
        </AisForm>
    );
};

ManufactoriesEditForm.displayName = 'ManufactoriesEditForm';
