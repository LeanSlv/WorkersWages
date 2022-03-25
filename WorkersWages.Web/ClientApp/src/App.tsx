import { Layout } from './components/Layout';
import { Route } from 'react-router-dom';
import { MainPage } from './components/MainPage/MainPage';
import { LoginPage } from './components/Account/LoginPage';
import { RegisterPage } from './components/Account/RegisterPage';

import './App.scss';

function App() {
    return (
        <Layout isLoading={false}>
            <Route path="/" exact component={MainPage} />
            <Route path="/login" exact component={LoginPage} />
            <Route path="/register" exact component={RegisterPage} />
        </Layout>
    );
}

export default App;
