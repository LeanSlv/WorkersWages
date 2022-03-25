import { NavLink } from 'react-router-dom';
import { BSNav, AisNavbar, AisNavDropdown, AisNavDropdownItem } from '@ais-gorod/react-ui';
import { useCallback, useEffect, useState } from 'react';
import { AuthorizationUserInfoResponse, WorkersWagesWebLocalApiClient } from '../services/WorkersWagesWebLocalApiClient';

const apiClient = new WorkersWagesWebLocalApiClient();

export const NavMenu = () => {
    const [userInfo, setUserInfo] = useState<AuthorizationUserInfoResponse>();

    const handleLogout = useCallback(async () => {
        await apiClient.logout().then((_) => window.location.reload());
    }, []);

    useEffect(() => {
        apiClient.userInfo().then(r => setUserInfo(r));
    }, []);

    return (
        <AisNavbar variant="dark" expand="lg" sticky="top">
            <AisNavbar.Brand as={NavLink} to="/">
                <strong>Сведения о месячной зарплате рабочих</strong>
            </AisNavbar.Brand>
            <BSNav className="me-auto">
                <BSNav.Link as={NavLink} to="/manufactories">
                    Цеха
                </BSNav.Link>
                <BSNav.Link as={NavLink} to="/users">
                    Пользователи
                </BSNav.Link>
                <BSNav.Link as={NavLink} to="/wages">
                    Заработные платы
                </BSNav.Link>
                <AisNavDropdown
                    id="main-nav-expanded"
                    title={'Справочники'}
                >
                    <AisNavDropdownItem to="/professions">Профессии</AisNavDropdownItem>
                    <AisNavDropdownItem to="/salaries">Оклады</AisNavDropdownItem>
                    <AisNavDropdownItem to="/schedules">Графики работы цехов</AisNavDropdownItem>
                </AisNavDropdown>
            </BSNav>

            <BSNav>
                {userInfo?.displayName ? (
                    <>
                        <AisNavbar.Text>
                            {userInfo.displayName}
                        </AisNavbar.Text>
                        <BSNav.Link onClick={handleLogout}>
                            Выйти
                        </BSNav.Link>
                    </>
                ) : (
                    <BSNav.Link as={NavLink} to="/login">
                        Войти
                    </BSNav.Link>
                )}
            </BSNav>
        </AisNavbar>
    );
};

NavMenu.displayName = 'NavMenu';
