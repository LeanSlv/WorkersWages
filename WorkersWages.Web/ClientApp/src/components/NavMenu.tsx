import { NavLink } from 'react-router-dom';
import { BSNav, AisIcon, AisNavbar, AisNavDropdown, AisNavDropdownItem } from '@ais-gorod/react-ui';

export const NavMenu = () => {
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
        </AisNavbar>
    );
};

NavMenu.displayName = 'NavMenu';
