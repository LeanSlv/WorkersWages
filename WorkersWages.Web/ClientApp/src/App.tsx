import { useCallback, useEffect, useState } from 'react';
import { Layout } from './components/Layout';
import { Route, useHistory, useLocation } from 'react-router-dom';
import { UserInfoContext, UserInfo } from './components/UserInfoContext';
import { WorkersWagesWebLocalApiClient } from './services/WorkersWagesWebLocalApiClient';

// Pages
import { MainPage } from './components/MainPage/MainPage';
import { LoginPage } from './components/Account/LoginPage';
import { RegisterPage } from './components/Account/RegisterPage';
import { ProfessionsContainer } from './components/Professions/ProfessionsContainer';
import { SalariesContainer } from './components/Salaries/SalariesContainer';
import { SchedulesContainer } from './components/Schedules/SchedulesContainer';
import { ManufactoriesContainer } from './components/Manufactories/ManufactoriesContainer';
import { WagesContainer } from './components/Wages/WagesContainer';
import { AccountProfilePage } from './components/Account/AccountProfilePage';

import './App.scss';
import { WorkersWagesApiClient } from './services/WorkersWagesApiClient';

function App() {
    const history = useHistory();
    const location = useLocation();

    const [userInfo, setUserInfo] = useState<UserInfo>();
    const loadUserInfo = useCallback(() => {
        const apiClient = new WorkersWagesApiClient('/extapi');
        apiClient.accountUserInfo().then((data) => setUserInfo(
            {
                displayName: `${data.lastName} ${data.firstName} ${data.middleName ?? ''}`.trim(),
                email: data.email,
                reloadDataTime: data.reloadDataTime
            })
        );
    }, [setUserInfo]);

    useEffect(() => loadUserInfo(), []);

    useEffect(() => {
        if (!userInfo?.displayName && !(location.pathname.toString() === '/' || location.pathname.startsWith('/login') || location.pathname.startsWith('/register'))) {
            history.replace({ ...location, pathname: '/' });
        }
    }, [userInfo, history, location]);

    return (
        <UserInfoContext.Provider value={userInfo}>
            <Layout isLoading={false}>
                <Route path="/" exact component={MainPage} />
                {userInfo?.displayName ? (
                    <>
                        <Route path="/professions" component={ProfessionsContainer} />
                        <Route path="/salaries" component={SalariesContainer} />
                        <Route path="/schedules" component={SchedulesContainer} />
                        <Route path="/manufactories" component={ManufactoriesContainer} />
                        <Route path="/wages" component={WagesContainer} />
                        <Route path="/profile">
                            <AccountProfilePage onDataChanged={loadUserInfo} />
                        </Route>
                    </>
                ) : (
                    <>
                        <Route path="/login" exact>
                            <LoginPage onSubmit={loadUserInfo} />
                        </Route>
                        <Route path="/register" exact>
                            <RegisterPage onSubmit={loadUserInfo} />
                        </Route>
                    </>
                )}
            </Layout>
        </UserInfoContext.Provider>
    );
}

export default App;
