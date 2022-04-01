import { AisTablePagination, AisTable, AisPageHeader, AisDisplay, AisConfirmModal, AisButton, AisIcon } from '@ais-gorod/react-ui';
import { WageInfo } from '../../services/WorkersWagesApiClient';
import { WagesListFilter, FilterData } from './WagesListFilter';
import { Link } from 'react-router-dom';
import { useCallback, useState } from 'react';

interface Props {
    data: WageInfo[] | undefined;
    dataTotalCount?: number;
    pagination?: AisTablePagination;
    filterData?: FilterData;
    setFilter: (filter: FilterData) => void;
    handleDelete: (id: number) => void;
}

export const WagesListPage = (props: Props) => {
    const [deleteId, setDeleteId] = useState<number>();

    const handleDelete = useCallback(() => {
        if (deleteId === undefined) return;

        props.handleDelete(deleteId);
        setDeleteId(undefined);
    }, [deleteId, setDeleteId]);

    return (
        <>
            <AisConfirmModal show={!!deleteId} title="Удаление заработной платы" onConfirm={handleDelete} onCancel={() => setDeleteId(undefined)}>
                <>Вы действительно хотите удалить <strong>эту</strong> заработную плату?</>
            </AisConfirmModal>
            <AisPageHeader title="Заработные платы" />
            <AisTable
                actionButtons={
                    <Link to={(l) => ({ ...l, pathname: '/wages/add' })}>
                        <AisButton>Добавить</AisButton>
                    </Link>
                }
                filter={
                    <WagesListFilter
                        data={props.filterData}
                        onSubmit={(data) => {
                            data.page = 0;
                            props.setFilter(data);
                        }}
                        onReset={() => props.setFilter({ page: 0 })}
                        noCard
                    />
                }
                data={props.data}
                dataTotalCount={props.dataTotalCount}
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
                            <Link to={(l) => ({ ...l, pathname: `/wages/edit/${item.id}` })}>
                                <AisButton variant="action" size="sm">
                                    <AisIcon type="edit" />
                                </AisButton>
                            </Link>
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
                pagination={props.pagination}
                useCard
            />
        </>
    );
};

WagesListPage.displayName = 'WagesListPage';
