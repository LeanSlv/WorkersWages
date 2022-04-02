import { AisTablePagination, AisTable, AisPageHeader, AisDisplay, AisButton, AisIcon, AisConfirmModal } from '@ais-gorod/react-ui';
import { useCallback, useState } from 'react';
import { Link } from 'react-router-dom';
import { ProfessionInfo } from '../../services/WorkersWagesApiClient';
import { ProfessionsListFilter, FilterData } from './ProfessionsListFilter';

interface Props {
    data: ProfessionInfo[] | undefined;
    dataTotalCount?: number;
    pagination?: AisTablePagination;
    filterData?: FilterData;
    setFilter: (filter: FilterData) => void;
    handleDelete: (id: number) => void;
}

export const ProfessionsListPage = (props: Props) => {
    const [deleteId, setDeleteId] = useState<number>();

    const handleDelete = useCallback(() => {
        if (deleteId === undefined) return;

        props.handleDelete(deleteId);
        setDeleteId(undefined);
    }, [deleteId, setDeleteId]);

    return (
        <>
            <AisConfirmModal show={!!deleteId} title="Удаление профессии" onConfirm={handleDelete} onCancel={() => setDeleteId(undefined)}>
                <>Вы действительно хотите удалить <strong>эту</strong> профессию?</>
            </AisConfirmModal>
            <AisPageHeader title="Список профессий" />
            <AisTable
                actionButtons={
                    <Link to={(l) => ({ ...l, pathname: '/professions/add' })}>
                        <AisButton>Добавить</AisButton>
                    </Link>
                }
                filter={
                    <ProfessionsListFilter
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
                            <Link to={(l) => ({ ...l, pathname: `/professions/edit/${item.id}` })}>
                                <AisButton variant="action" size="sm">
                                    <AisIcon type="edit" />
                                </AisButton>
                            </Link>
                            <AisButton variant="action" size="sm" onClick={() => setDeleteId(item.id)}>
                                <AisIcon type="delete" />
                            </AisButton>
                        </td>
                        <td>{item.id}</td>
                        <td>{item.name}</td>
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

ProfessionsListPage.displayName = 'ProfessionsListPage';
