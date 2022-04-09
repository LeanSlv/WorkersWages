import { AisCard, AisForm, AisFormField, AisButton, Yup } from '@ais-gorod/react-ui';
import { useCallback, useEffect, useState } from 'react';
import { AccountEditMainInfoRequest, AccountUserInfoResponse, WorkersWagesApiClient } from '../../services/WorkersWagesApiClient';

interface Props {
    data: AccountUserInfoResponse;
    onDataChanged: () => void;
}

const validationSchema = Yup.object().shape({
    firstName: Yup.string().required(),
    middleName: Yup.string(),
    lastName: Yup.string().required(),
    email: Yup.string().email('Электронная почта введена некорректно.').required(),
});

export const AccountEditMainCard = (props: Props) => {
    const [initialValues, setInitialValues] = useState<AccountEditMainInfoRequest>();

    const propsData = props.data;
    useEffect(() => setInitialValues(
        new AccountEditMainInfoRequest({
            firstName: propsData.firstName,
            middleName: propsData.middleName,
            lastName: propsData.lastName,
            email: propsData.email
        })
    ), [propsData]);

    const propsOnDataChanged = props.onDataChanged;
    const handleSubmit = useCallback(async (data: AccountEditMainInfoRequest) => {
        const apiClient = new WorkersWagesApiClient("/extapi");
        await apiClient.accountEditMainInfo(data).then((_) => propsOnDataChanged());
    }, [propsOnDataChanged]);

    if (!initialValues) return null;

    return (
        <AisCard header={<h3>Редактирование основых данных</h3>}>
            <AisForm onSubmit={handleSubmit} initialValues={initialValues} validationSchema={validationSchema}>
                <AisFormField.Text label="Фамилия" name="lastName" />
                <AisFormField.Text label="Имя" name="firstName" />
                <AisFormField.Text label="Отчество" name="middleName" />
                <AisFormField.Text label="Электронная почта" name="email" />
                <AisButton type="submit">Сохранить</AisButton>
            </AisForm>
        </AisCard>
    );
};

AccountEditMainCard.displayName = 'AccountEditMainCard';
