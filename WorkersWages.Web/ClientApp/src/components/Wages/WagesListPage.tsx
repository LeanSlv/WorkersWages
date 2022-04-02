import { AisTable, AisPageHeader, AisDisplay, AisConfirmModal, AisButton, AisIcon, useAisList } from '@ais-gorod/react-ui';
import { WagesListFilter, FilterData } from './WagesListFilter';
import { Link } from 'react-router-dom';
import { WageListResponse, WorkersWagesApiClient } from '../../services/WorkersWagesApiClient';
import { useCallback, useState } from 'react';
import { WagesCreateModal } from './WagesCreateModal';
import { WagesEditModal } from './WagesEditModal';

const apiClient = new WorkersWagesApiClient('/extapi');

export const WagesListPage = () => {
    const [showCreateModal, setShowCreateModal] = useState<boolean>();
    const [editId, setEditId] = useState<number>();
    const [deleteId, setDeleteId] = useState<number>();

    const dataSource = useCallback(async (filter: FilterData, pageNumber: number, pageSize: number) => {
        const response = await apiClient.wagesList(
            undefined,
            undefined,
            undefined,
            undefined,
            pageSize,
            pageNumber * pageSize,
        );

        return {
            data: response,
            count: response.totalCount ?? 0,
        };
    }, []);

    const { data, filter, setFilter, pagination, reloadData } = useAisList<WageListResponse, FilterData>({
        dataSource: dataSource,
    });

    const handleDelete = useCallback(async () => {
        if (deleteId === undefined) return;

        await apiClient.wagesDelete(deleteId).then((_) => reloadData());
        setDeleteId(undefined);
    }, [deleteId, setDeleteId, reloadData]);

    return (
        <>
            {showCreateModal && (
                <WagesCreateModal onHide={() => setShowCreateModal(false)} onDataChanged={reloadData} />
            )}
            {!!editId && (
                <WagesEditModal id={editId} onHide={() => setEditId(undefined)} onDataChanged={reloadData} />
            )}
            <AisConfirmModal show={!!deleteId} title="Удаление заработной платы" onConfirm={handleDelete} onCancel={() => setDeleteId(undefined)}>
                <>Вы действительно хотите удалить <strong>эту</strong> заработную плату?</>
            </AisConfirmModal>
            <AisPageHeader title="Заработные платы" />
            <AisTable
                actionButtons={
                    <AisButton onClick={() => setShowCreateModal(true)}>Добавить</AisButton>
                }
                filter={
                    <WagesListFilter
                        data={filter}
                        onSubmit={(data) => {
                            data.page = 0;
                            setFilter(data);
                        }}
                        onReset={() => setFilter({ page: 0 })}
                        noCard
                    />
                }
                data={data?.wages}
                dataTotalCount={data?.totalCount}
                thead={
                    <>
                        <tr>
                            <th></th>
                            <th>ИД</th>
                            <th>Фамилия рабочего</th>
                            <th>Цех</th>
                            <th>Название профессии</th>
                            <th>Разряд</th>
                            <th>
                                Размер
                                <br />
                                <small>С учетом надбавок</small>
                            </th>
                            <th>
                                Создано
                                <br />
                                <small>Обновлено</small>
                            </th>
                        </tr>
                    </>
                }
                row={(item) => (
                    <tr key={item.id}>
                        <td className="w-min">
                            <AisButton variant="action" size="sm" onClick={() => setEditId(item.id)}>
                                <AisIcon type="edit" />
                            </AisButton>
                            <AisButton variant="action" size="sm" onClick={() => setDeleteId(item.id)}>
                                <AisIcon type="delete" />
                            </AisButton>
                        </td>
                        <td>{item.id}</td>
                        <td>
                            <Link to={(l) => ({ ...l, pathname: `/wages/details/${item.id}` })}>{item.workerLastName}</Link>
                        </td>
                        <td>
                            <Link to={(l) => ({ ...l, pathname: `/manufactories/details/${item.id}` })}>{item.manufactoryDisplayName}</Link>
                        </td>
                        <td>{item.professionName}</td>
                        <td>{item.rank}</td>
                        <td>
                            <AisDisplay.Number value={item.amount} />
                            <br />
                            <small>
                                <AisDisplay.Number value={item.amountWithAllowances} />
                            </small>
                        </td>
                        <td>
                            <AisDisplay.DateTime value={item.created} />
                            <br />
                            <small>
                                <AisDisplay.DateTime value={item.updated} />
                            </small>
                        </td>
                    </tr>
                )}
                pagination={pagination}
                useCard
            />
        </>
    );
};

WagesListPage.displayName = 'WagesListPage';
