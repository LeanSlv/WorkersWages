import { AisPageHeader, AisContentSpinner, AisGrid } from '@ais-gorod/react-ui';
import { useEffect, useState } from 'react';
import { AccountUserInfoResponse, WorkersWagesApiClient } from '../../services/WorkersWagesApiClient';

export const AccountProfilePage = () => {
    const [data, setData] = useState<AccountUserInfoResponse>();
    useEffect(() => {
        const apiClient = new WorkersWagesApiClient("/extapi");
        apiClient.accountUserInfo().then((r) => setData(r));
    }, []);

    if (!data) {
        return (
            <div style={{ position: 'relative', height: '10rem' }}>
                <AisContentSpinner />
            </div>
        );
    }

    return (
        <>
            <AisPageHeader title="Личный кабинет" />
            <AisGrid.Row>
                <AisGrid.Col>
                    <div>
                        <strong>Фамилия: </strong>
                        <span>{data.lastName}</span>
                    </div>
                    <div>
                        <strong>Имя: </strong>
                        <span>{data.firstName}</span>
                    </div>
                    <div>
                        <strong>Отчество: </strong>
                        <span>{data.middleName}</span>
                    </div>
                    <div>
                        <strong>Логин: </strong>
                        <span>{data.userName}</span>
                    </div>
                    <div>
                        <strong>Электронная почта: </strong>
                        <span>{data.email}</span>
                    </div>
                </AisGrid.Col>
            </AisGrid.Row>
        </>
    );
};

AccountProfilePage.displayName = 'AccountProfilePage';
