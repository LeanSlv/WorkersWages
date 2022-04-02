import { WagesListPage } from './WagesListPage';
import { Route } from 'react-router-dom';
import { WagesDetailsPage } from './WagesDetailsPage';


export const WagesContainer = () => {
    return (
        <>
            <Route path="/wages" exact>
                <WagesListPage />
            </Route>
            <Route path="/wages/details/:id">
                <WagesDetailsPage />
            </Route>
        </>
    );
};

WagesContainer.displayName = 'WagesContainer';
