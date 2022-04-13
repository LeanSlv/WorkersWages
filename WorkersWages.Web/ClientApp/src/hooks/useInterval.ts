import { useCallback, useContext } from 'react';
import { UserInfoContext } from '../components/UserInfoContext';
import { AisToast } from '@ais-gorod/react-ui';

interface Props {
    callback: () => void;
}

export function useInterval(props: Props) {
    const userInfo = useContext(UserInfoContext);
    const cb = props.callback;
    const interval = useCallback(() => {
        if (!userInfo?.reloadDataTime || userInfo.reloadDataTime === 0) return;

        const interval = setInterval(() => {
            cb();
            AisToast.Information(`Данные автоматически обновлены. Следующее обновление произойдет через ${userInfo.reloadDataTime} секунд`);
        }, userInfo.reloadDataTime * 1000);

        return () => clearInterval(interval);
    }, [cb, userInfo]);

    return interval;
}
