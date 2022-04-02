import { AisTable, AisGrid, AisPageHeader, AisButton, AisIcon, AisContentSpinner, AisConfirmModal, AisDisplay } from "@ais-gorod/react-ui";
import { useCallback, useEffect, useState } from "react";
import { useParams, Link, Route } from 'react-router-dom';
import { WorkersWagesApiClient, WageDetailsResponse } from '../../services/WorkersWagesApiClient';
import { WagesDetailsCreateAllowanceModal } from './WagesDetailsCreateAllowanceModal';
import { WagesDetailsEditAllowanceModal } from './WagesDetailsEditAllowanceModal';

const apiClient = new WorkersWagesApiClient('/extapi');

export const WagesDetailsPage = () => {
    const { id } = useParams() as {
        id: string;
    };

    const loadData = useCallback(() => {
        if (!id) return;
        apiClient.wagesDetails(+id).then((r) => setWageInfo(r));
    }, [id]);

    const [wageInfo, setWageInfo] = useState<WageDetailsResponse>();
    useEffect(() => loadData(), []);

    const [deleteId, setDeleteId] = useState<number>();
    const handleDelete = useCallback(async () => {
        if (!deleteId) return;
        await apiClient.wagesDeleteAllowance(+id, deleteId).then((_) => {
            loadData();
            setDeleteId(undefined);
        });
    }, [deleteId]);

    if (!wageInfo) {
        return (
            <div style={{ position: 'relative', height: '10rem' }}>
                <AisContentSpinner />
            </div>
        );
    }

    return (
        <>
            <Route path="/wages/details/:wageId/add-allowance" exact>
                <WagesDetailsCreateAllowanceModal onDataChanged={loadData} />
            </Route>
            <Route path="/wages/details/:wageId/edit-allowance/:allowanceId" exact>
                <WagesDetailsEditAllowanceModal onDataChanged={loadData} />
            </Route>
            <AisConfirmModal show={!!deleteId} title="Удаление надбавки" onConfirm={handleDelete} onCancel={() => setDeleteId(undefined)}>
                <>Вы действительно хотите удалить <strong>эту</strong> надбавку?</>
            </AisConfirmModal>
            <AisPageHeader title="Подробности заработной платы" />
            <AisGrid.Row>
                <AisGrid.Col>
                    <AisTable vertical useCard>
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
                            <td>
                                <AisDisplay.Number value={wageInfo.amount} />
                            </td>
                        </tr>
                        <tr>
                            <th>Размер с учетом надбавок</th>
                            <td>
                                <AisDisplay.Number value={wageInfo.amountWithAllowances} />
                            </td>
                        </tr>
                    </AisTable>
                </AisGrid.Col>
                
                <AisGrid.Col>
                    <AisTable
                        actionButtons={
                            <Link to={(l) => ({ ...l, pathname: `/wages/details/${id}/add-allowance` })}>
                                <AisButton>Добавить</AisButton>
                            </Link>
                        }
                        data={wageInfo.allowances}
                        thead={
                            <tr>
                                <th></th>
                                <th>Наименование</th>
                                <th>Размер надбавки</th>
                            </tr>
                        }
                        row={(item) => (
                            <tr key={item.id}>
                                <td className="w-min">
                                    <Link to={(l) => ({ ...l, pathname: `/wages/details/${id}/edit-allowance/${item.id}` })}>
                                        <AisButton variant="action" size="sm">
                                            <AisIcon type="edit" />
                                        </AisButton>
                                    </Link>
                                    <AisButton variant="action" size="sm" onClick={() => setDeleteId(item.id)}>
                                        <AisIcon type="delete" />
                                    </AisButton>
                                </td>
                                <td>{item.name}</td>
                                <td>
                                    <AisDisplay.Number value={item.amount} />
                                </td>
                            </tr>
                        )}
                        useCard
                    />
                </AisGrid.Col>
            </AisGrid.Row>
        </>
    );
};

WagesDetailsPage.displayName = 'WagesDetailsPage';
