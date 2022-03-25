import { useCallback } from 'react';
import { AisForm, AisFormField, AisButton, AisCard, AisGrid, Yup } from '@ais-gorod/react-ui';
import { useHistory, Link } from 'react-router-dom';
import { AccountLoginRequest, WorkersWagesWebLocalApiClient } from '../../services/WorkersWagesWebLocalApiClient';

const FormValuesSchema = Yup.object().shape({
    userName: Yup.string().required(),
    password: Yup.string().required()
});

export const LoginPage = () => {
    const history = useHistory();
    const handleSubmit = useCallback(async (data: AccountLoginRequest) => {
        const apiClient = new WorkersWagesWebLocalApiClient();
        await apiClient.login(data).then((_) => history.goBack());
    }, []);

    return (
        <AisGrid.Row id="flexContainer">
            <AisGrid.Col md={8} lg={4}>
                <AisCard header="Вход в систему" headerClassName="text-center">
                    <AisForm onSubmit={handleSubmit} validationSchema={FormValuesSchema}>
                        <AisFormField.Text label="Логин" name="userName" />
                        <AisFormField.Text label="Пароль" name="password" type="password" />
                        <AisButton type="submit" variant="primary">
                            Войти
                        </AisButton>
                        {'  '}
                        <Link to={(l) => ({ ...l, pathname: '/register' })}>Регистрация</Link>
                    </AisForm>
                </AisCard>
            </AisGrid.Col>
        </AisGrid.Row>
    );
};

LoginPage.displayName = 'LoginPage';
