import { NavLink } from 'react-router-dom';
import { BSNav, AisNavbar, AisNavDropdown, AisNavDropdownItem } from '@ais-gorod/react-ui';
import { useCallback, useContext } from 'react';
import { WorkersWagesWebLocalApiClient } from '../services/WorkersWagesWebLocalApiClient';
import { MdOutlineAccountCircle, MdOutlineExitToApp, MdOutlineLogin } from 'react-icons/md';
import { UserInfoContext } from './UserInfoContext';

const apiClient = new WorkersWagesWebLocalApiClient();

export const NavMenu = () => {
    const userInfo = useContext(UserInfoContext);

    const handleLogout = useCallback(async () => {
        await apiClient.logout().then((_) => window.location.reload());
    }, []);

    return (
        <AisNavbar variant="dark" expand="lg" sticky="top">
            <AisNavbar.Brand as={NavLink} to="/">
                <strong>Сведения о месячной зарплате рабочих</strong>
            </AisNavbar.Brand>
            <BSNav className="me-auto">
                {userInfo && (
                    <>
                        <BSNav.Link as={NavLink} to="/manufactories">
                            Цеха
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
                    </>
                )}
            </BSNav>

            <BSNav>
                {userInfo?.displayName ? (
                    <>
                        <AisNavbar.Text>
                            <MdOutlineAccountCircle /> {userInfo.displayName}
                        </AisNavbar.Text>
                        <BSNav.Link onClick={handleLogout}>
                            <MdOutlineExitToApp /> Выйти
                        </BSNav.Link>
                    </>
                ) : (
                    <BSNav.Link as={NavLink} to="/login">
                        <MdOutlineLogin /> Войти
                    </BSNav.Link>
                )}
            </BSNav>
        </AisNavbar>
    );
};

NavMenu.displayName = 'NavMenu';
