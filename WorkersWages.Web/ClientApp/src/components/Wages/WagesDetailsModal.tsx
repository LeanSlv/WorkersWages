import { AisModal, AisTable, AisGrid } from "@ais-gorod/react-ui";
import { useEffect, useState } from "react";
import { useHistory, useParams } from 'react-router-dom';
import { WorkersWagesApiClient, WageDetailsResponse } from '../../services/WorkersWagesApiClient';

export const WagesDetailsModal = () => {
    const history = useHistory();
    const { id } = useParams() as {
        id: string;
    };

    const [wageInfo, setWageInfo] = useState<WageDetailsResponse>();
    useEffect(() => {
        const apiClient = new WorkersWagesApiClient('/extapi');
        apiClient.wagesDetails(+id).then((r) => setWageInfo(r));
    }, []);

    if (!wageInfo) return null;

    return (
        <AisModal show={true} onHide={() => history.goBack()} title="Подробности заработной платы" size="lg">
            <AisGrid.Row>
                <AisGrid.Col>
                    <AisTable vertical>
                        <tr>
                            <th>Фамилия рабочего</th>
                            <td>{wageInfo.workerLastName}</td>
                        </tr>
                        <tr>
                            <th>Название цеха</th>
                            <td>{wageInfo.manufactoryDisplayName}</td>
                        </tr>
                        <tr>
                            <th>Название профессии</th>
                            <td>{wageInfo.professionName}</td>
                        </tr>
                        <tr>
                            <th>Разряд</th>
                            <td>{wageInfo.rank}</td>
                        </tr>
                        <tr>
                            <th>Размер</th>
                            <td>{wageInfo.amount}</td>
                        </tr>
                        <tr>
                            <th>Размер с учетом надбавок</th>
                            <td>{wageInfo.amountWithAllowances}</td>
                        </tr>
                    </AisTable>
                </AisGrid.Col>
                
                <AisGrid.Col>
                    <AisTable
                        data={wageInfo.allowances}
                        thead={
                            <tr>
                                <th>Наименование</th>
                                <th>Размер надбавки</th>
                            </tr>
                        }
                        row={(item) => (
                            <tr key={item.id}>
                                <td>{item.name}</td>
                                <td>{item.amount}</td>
                            </tr>
                        )}
                    />
                </AisGrid.Col>
            </AisGrid.Row>
        </AisModal>
    );
};

WagesDetailsModal.displayName = 'WagesDetailsModal';
