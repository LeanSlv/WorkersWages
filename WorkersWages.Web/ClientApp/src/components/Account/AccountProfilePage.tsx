import { AisPageHeader, AisContentSpinner, AisGrid, AisCard, AisButton } from '@ais-gorod/react-ui';
import { useCallback, useEffect, useState } from 'react';
import { AccountUserInfoResponse, WorkersWagesApiClient } from '../../services/WorkersWagesApiClient';
import { AccountEditMainCard } from './AccountEditMainCard';
import { AccountEditCredentialsCard } from './AccountEditCredentialsCard';

interface Props {
    onDataChanged: () => void;
}

export const AccountProfilePage = (props: Props) => {
    const [data, setData] = useState<AccountUserInfoResponse>();
    const loadData = useCallback(() => {
        const apiClient = new WorkersWagesApiClient("/extapi");
        apiClient.accountUserInfo().then((r) => setData(r));
    }, [setData]);

    useEffect(() => loadData(), [loadData]);

    const [showEditMainForm, setShowEditMainForm] = useState<boolean>(false);
    const [showEditCredentialsForm, setShowEditCredentialsForm] = useState<boolean>(false);
    const handleShowEditMain = useCallback(() => {
        setShowEditMainForm(true);
        setShowEditCredentialsForm(false);
    }, [setShowEditMainForm, setShowEditCredentialsForm]);

    const handleShowEditCredentials = useCallback(() => {
        setShowEditMainForm(false);
        setShowEditCredentialsForm(true);
    }, [setShowEditMainForm, setShowEditCredentialsForm]);

    const propsOnDataChanged = props.onDataChanged;
    const handleDataChanged = useCallback(() => {
        loadData();
        setShowEditMainForm(false);
        setShowEditCredentialsForm(false);
        propsOnDataChanged();
    }, [loadData, setShowEditMainForm, setShowEditCredentialsForm, propsOnDataChanged]);

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
                <AisGrid.Col xs={3} sm={3} lg={3}>
                    <AisCard
                        header={<h4>Основные данные</h4>}
                        footer={
                            <>
                                <AisButton className="btn-block mb-1" onClick={handleShowEditMain}>Редактировать основные данные</AisButton>
                                <AisButton className="btn-block" variant="outline-primary" onClick={handleShowEditCredentials}>Редактировать учетные данные</AisButton>
                            </>
                        }
                        footerClassName="text-center"
                    >
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
                    </AisCard>
                </AisGrid.Col>
                <AisGrid.Col xs={6} sm={6} lg={6}>
                    {showEditMainForm && (<AccountEditMainCard data={data} onDataChanged={handleDataChanged} />)}
                    {showEditCredentialsForm && (<AccountEditCredentialsCard data={data} onDataChanged={handleDataChanged} />)}
                </AisGrid.Col>
            </AisGrid.Row>
        </>
    );
};

AccountProfilePage.displayName = 'AccountProfilePage';
