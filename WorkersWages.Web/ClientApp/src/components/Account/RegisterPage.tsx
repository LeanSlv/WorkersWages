import { useCallback } from 'react';
import { AisForm, AisFormField, AisButton, AisCard, AisGrid, Yup } from '@ais-gorod/react-ui';
import { useHistory } from 'react-router-dom';
import { AccountRegisterRequest, WorkersWagesWebLocalApiClient } from '../../services/WorkersWagesWebLocalApiClient';

interface RegisterData {
    firstName: string;
    lastName: string;
    middleName?: string;
    email: string;
    userName: string;
    password: string;
    confirmPassword: string;
}

const FormValuesSchema = Yup.object().shape({
    firstName: Yup.string().required(),
    lastName: Yup.string().required(),
    email: Yup.string().email('Электронная почта введена некорректно.').required(),
    userName: Yup.string().required(),
    password: Yup.string().required(),
    confirmPassword: Yup.string()
        .oneOf([Yup.ref('password'), null], 'Пароли не совпадают.')
        .required()
});

export const RegisterPage = () => {
    const history = useHistory();
    const handleSubmit = useCallback(async (data: RegisterData) => {
        const request = new AccountRegisterRequest({
            firstName: data.firstName,
            middleName: data.middleName,
            lastName: data.lastName,
            email: data.email,
            userName: data.userName,
            password: data.password
        });

        const apiClient = new WorkersWagesWebLocalApiClient();
        await apiClient.register(request).then((_) => history.push('/'));
    }, []);

    return (
        <AisGrid.Row id="flexContainer">
            <AisGrid.Col md={8} lg={4}>
                <AisCard header="Регистрация" headerClassName="text-center">
                    <AisForm onSubmit={handleSubmit} validationSchema={FormValuesSchema}>
                        <AisFormField.Text label="Имя" name="firstName" />
                        <AisFormField.Text label="Фамилия" name="lastName" />
                        <AisFormField.Text label="Отчество" name="middleName" />
                        <AisFormField.Text label="Электронная почта" name="email" />
                        <AisFormField.Text label="Логин" name="userName" />
                        <AisFormField.Text label="Пароль" name="password" type="password" />
                        <AisFormField.Text label="Повторите пароль" name="confirmPassword" type="password" />
                        <AisButton type="submit" variant="primary">
                            Зарегистрироваться
                        </AisButton>
                    </AisForm>
                </AisCard>
            </AisGrid.Col>
        </AisGrid.Row>
    );
};

RegisterPage.displayName = 'RegisterPage';
