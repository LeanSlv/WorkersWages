import { useCallback } from 'react';
import { AisForm, AisFormField, AisButton, AisCard, AisGrid } from '@ais-gorod/react-ui';
import { useHistory, Link } from 'react-router-dom';
import { AccountLoginRequest, WorkersWagesWebLocalApiClient } from '../../services/WorkersWagesWebLocalApiClient';
import './LoginPage.scss';

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
                    <AisForm onSubmit={handleSubmit}>
                        <AisFormField.Text label="Логин" name="userName" />
                        <AisFormField.Text label="Пароль" name="password" type="password" />
                        <AisButton type="submit" variant="primary" className="btn-block">
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
