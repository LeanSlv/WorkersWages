import { AisCard, AisForm, AisFormField, AisButton, Yup, AisAlert } from '@ais-gorod/react-ui';
import { useCallback } from 'react';
import { AccountEditCredentialsInfoRequest, AccountUserInfoResponse, WorkersWagesApiClient } from '../../services/WorkersWagesApiClient';

interface Props {
    data: AccountUserInfoResponse;
    onDataChanged: () => void;
}

const validationSchema = Yup.object().shape({
    userName: Yup.string(),
    password: Yup.string()
});

export const AccountEditCredentialsCard = (props: Props) => {
    const propsOnDataChanged = props.onDataChanged;
    const handleSubmit = useCallback(async (data: AccountEditCredentialsInfoRequest) => {
        const apiClient = new WorkersWagesApiClient("/extapi");
        await apiClient.accountEditCredentialsInfo(data).then((_) => propsOnDataChanged());
    }, [propsOnDataChanged]);

    return (
        <AisCard header={<h3>Редактирование учетных данных</h3>}>
            <AisAlert variant="primary">
                Для изменения логина или пароля введите новые данные в поля ниже. Если оставить поля пустыми, данные не изменятся.
            </AisAlert>
            <AisForm onSubmit={handleSubmit} validationSchema={validationSchema}>
                <AisFormField.Text label="Логин" name="userName" />
                <AisFormField.Text label="Парль" name="password" type="password" />
                <AisButton type="submit">Сохранить</AisButton>
            </AisForm>
        </AisCard>
    );
};

AccountEditCredentialsCard.displayName = 'AccountEditCredentialsCard';
