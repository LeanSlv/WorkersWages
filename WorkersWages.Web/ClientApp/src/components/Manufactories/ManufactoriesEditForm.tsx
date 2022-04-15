import { AisButton, AisForm, AisFormField, Yup } from "@ais-gorod/react-ui";
import { ChangeEvent, useCallback, useState } from "react";
import { ManufactoryEditRequest, WorkersWagesApiClient } from "../../services/WorkersWagesApiClient";

interface Props {
    data?: ManufactoryEditRequest;
    onSubmit: (data: ManufactoryEditRequest) => void;
}

export interface FormData {
    name: string;
    number: string;
    headFIO: string;
    headPhoto?: File;
}

const validationSchema = Yup.object().shape({
    name: Yup.string().required(),
    number: Yup.string().required(),
    headFIO: Yup.string().required()
});

export const ManufactoriesEditForm = (props: Props) => {
    const [file, setFile] = useState<File | null>();
    const saveFile = useCallback((e: ChangeEvent<HTMLInputElement>) => {
        setFile(e.target.files?.item(0));
    }, [setFile]);

    const propsOnSubmit = props.onSubmit;
    const handleSubmit = useCallback((data: FormData) => {
        if (!file) return;
        const apiClient = new WorkersWagesApiClient('/extapi');
        apiClient.filesUpload({ data: file, fileName: file.name }).then((fileId) => {
            propsOnSubmit(new ManufactoryEditRequest({
                name: data.name,
                number: data.number,
                headFIO: data.headFIO,
                headPhotoId: fileId
            }));
        });

    }, [propsOnSubmit, file]);

    return (
        <AisForm onSubmit={handleSubmit} validationSchema={validationSchema} initialValues={props.data}>
            <AisFormField.Text label="Название *" name="name" />
            <AisFormField.Text label="Номер *" name="number" />
            <AisFormField.Text label="ФИО начальника *" name="headFIO" />
            <AisFormField.File label="Фото начальника" name="headPhoto" onChange={saveFile} />
            <AisButton type="submit">Сохранить</AisButton>
        </AisForm>
    );
};

ManufactoriesEditForm.displayName = 'ManufactoriesEditForm';
