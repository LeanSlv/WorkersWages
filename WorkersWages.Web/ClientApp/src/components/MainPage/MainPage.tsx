import MainPageImage from './MainPageImage.png';
import './MainPage.scss';
import { AisPageTitle } from '@ais-gorod/react-ui';

export const MainPage = () => {
    return (
        <div className="w-100 text-center">
            <AisPageTitle />
            <h1>Сведения о месячной зарплате рабочих</h1>
            <div>
                <img src={MainPageImage}/>
            </div>
            <div>На этом сайте вы сможете управлять сведениями о месячной заработной плате рабочих своего предприятия.</div>
        </div>
    );
};

MainPage.DisplayName = 'MainPage';
