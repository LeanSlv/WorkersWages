import { AisTablePagination, AisTable, AisPageHeader, AisDisplay } from '@ais-gorod/react-ui';
import { ManufactoryInfo } from '../../services/WorkersWagesApiClient';
import { ManufactoriesListFilter, FilterData } from './ManufactoriesListFilter';
import { Link } from 'react-router-dom';

interface Props {
    data: ManufactoryInfo[] | undefined;
    dataTotalCount?: number;
    pagination?: AisTablePagination;
    filterData?: FilterData;
    setFilter: (filter: FilterData) => void;
}

export const ManufactoriesListPage = (props: Props) => {
    return (
        <>
            <AisPageHeader title="Цеха" />
            <AisTable
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
