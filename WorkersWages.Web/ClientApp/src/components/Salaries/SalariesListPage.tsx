import { AisTablePagination, AisTable, AisPageHeader, AisDisplay, AisButton, AisIcon, AisConfirmModal } from '@ais-gorod/react-ui';
import { useCallback, useState } from 'react';
import { Link } from 'react-router-dom';
import { SalaryInfo } from '../../services/WorkersWagesApiClient';
import { SalariesListFilter, FilterData } from './SalariesListFilter';

interface Props {
    data: SalaryInfo[] | undefined;
    dataTotalCount?: number;
    pagination?: AisTablePagination;
    filterData?: FilterData;
    setFilter: (filter: FilterData) => void;
    handleDelete: (id: number) => void;
}

export const SalariesListPage = (props: Props) => {
    const [deleteId, setDeleteId] = useState<number>();

    const handleDelete = useCallback(() => {
        if (deleteId === undefined) return;

        props.handleDelete(deleteId);
        setDeleteId(undefined);
    }, [deleteId, setDeleteId]);

    return (
        <>
            <AisConfirmModal show={!!deleteId} title="Удаление оклада" onConfirm={handleDelete} onCancel={() => setDeleteId(undefined)}>
                <>Вы действительно хотите удалить <strong>этот</strong> оклад?</>
            </AisConfirmModal>
            <AisPageHeader title="Список окладов" />
            <AisTable
                actionButtons={
                    <Link to={(l) => ({ ...l, pathname: '/salaries/add' })}>
                        <AisButton>Добавить</AisButton>
                    </Link>
                }
                filter={
                    <SalariesListFilter
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
                    <tr>
                        <th></th>
                        <th>ИД</th>
                        <th>Название профессии</th>
                        <th>Разряд</th>
                        <th>Сумма оклада</th>
                        <th>
                            Создано
                            <br />
                            <small>Обновлено</small>
                        </th>
                    </tr>
                }
                row={(item) => (
                    <tr key={item.id}>
                        <td className="w-min">
                            <Link to={(l) => ({ ...l, pathname: `/salaries/edit/${item.id}` })}>
                                <AisButton variant="action" size="sm">
                                    <AisIcon type="edit" />
                                </AisButton>
                            </Link>
                            <AisButton variant="action" size="sm" onClick={() => setDeleteId(item.id)}>
                                <AisIcon type="delete" />
                            </AisButton>
                        </td>
                        <td>{item.id}</td>
                        <td>{item.professionName}</td>
                        <td>{item.rank}</td>
                        <td>{item.amount}</td>
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

SalariesListPage.displayName = 'SalariesListPage';
