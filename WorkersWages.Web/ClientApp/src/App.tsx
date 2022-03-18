import { Layout } from './components/Layout';
import './App.scss';
import { Route } from 'react-router-dom';
import { MainPage } from './components/MainPage/MainPage';

function App() {
    return (
        <Layout isLoading={false}>
                <Route path="/" exact component={MainPage} />
        </Layout>
    );
}

export default App;
