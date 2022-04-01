import { AisTablePagination, AisTable, AisPageHeader, AisDisplay, AisConfirmModal, AisButton, AisIcon } from '@ais-gorod/react-ui';
import { ManufactoryInfo } from '../../services/WorkersWagesApiClient';
import { ManufactoriesListFilter, FilterData } from './ManufactoriesListFilter';
import { Link } from 'react-router-dom';
import { useCallback, useState } from 'react';

interface Props {
    data: ManufactoryInfo[] | undefined;
    dataTotalCount?: number;
    pagination?: AisTablePagination;
    filterData?: FilterData;
    setFilter: (filter: FilterData) => void;
    handleDelete: (id: number) => void;
}

export const ManufactoriesListPage = (props: Props) => {
    const [deleteId, setDeleteId] = useState<number>();

    const handleDelete = useCallback(() => {
        if (deleteId === undefined) return;

        props.handleDelete(deleteId);
        setDeleteId(undefined);
    }, [deleteId, setDeleteId]);

    return (
        <>
            <AisConfirmModal show={!!deleteId} title="Удаление цеха" onConfirm={handleDelete} onCancel={() => setDeleteId(undefined)}>
                <>Вы действительно хотите удалить <strong>этот</strong> цех?</>
            </AisConfirmModal>
            <AisPageHeader title="Цеха" />
            <AisTable
                actionButtons={
                    <Link to={(l) => ({ ...l, pathname: '/manufactories/add' })}>
                        <AisButton>Добавить</AisButton>
                    </Link>
                }
                filter={
                    <ManufactoriesListFilter
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
                            <th>Название</th>
                            <th>Номер</th>
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
                            <Link to={(l) => ({ ...l, pathname: `/manufactories/edit/${item.id}` })}>
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
                            <Link to={(l) => ({ ...l, pathname: `/manufactories/details/${item.id}` })}>{item.name}</Link>
                        </td>
                        <td>{item.number}</td>
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

ManufactoriesListPage.displayName = 'ManufactoriesListPage';
