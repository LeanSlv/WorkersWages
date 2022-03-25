import { Layout } from './components/Layout';
import { Route } from 'react-router-dom';
import { MainPage } from './components/MainPage/MainPage';
import { LoginPage } from './components/Account/LoginPage';

import './App.scss';

function App() {
    return (
        <Layout isLoading={false}>
            <Route path="/" exact component={MainPage} />
            <Route path="/login" exact component={LoginPage} />
        </Layout>
    );
}

export default App;
