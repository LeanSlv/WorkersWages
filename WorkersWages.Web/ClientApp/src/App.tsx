import { useEffect, useState } from 'react';
import { Layout } from './components/Layout';
import { Route } from 'react-router-dom';
import { UserInfoContext, UserInfo } from './components/UserInfoContext';
import { WorkersWagesWebLocalApiClient } from './services/WorkersWagesWebLocalApiClient';

// Pages
import { MainPage } from './components/MainPage/MainPage';
import { LoginPage } from './components/Account/LoginPage';
import { RegisterPage } from './components/Account/RegisterPage';
import { ProfessionsContainer } from './components/Professions/ProfessionsContainer';
import { SalariesContainer } from './components/Salaries/SalariesContainer';

import './App.scss';


function App() {
    const [userInfo, setUserInfo] = useState<UserInfo>();
    useEffect(() => {
        const apiClient = new WorkersWagesWebLocalApiClient();
        apiClient.userInfo().then((data) => setUserInfo(data));
    }, []);

    return (
        <UserInfoContext.Provider value={userInfo}>
            <Layout isLoading={false}>
                <Route path="/" exact component={MainPage} />
                <Route path="/login" exact component={LoginPage} />
                <Route path="/register" exact component={RegisterPage} />

                <Route path="/professions" exact component={ProfessionsContainer} />
                <Route path="/salaries" exact component={SalariesContainer} />
            </Layout>
        </UserInfoContext.Provider>
    );
}

export default App;
