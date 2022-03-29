import { AisTablePagination, AisTable, AisPageHeader, AisDisplay } from '@ais-gorod/react-ui';
import { SalaryInfo } from '../../services/WorkersWagesApiClient';
import { SalariesListFilter, FilterData } from './SalariesListFilter';

interface Props {
    data: SalaryInfo[] | undefined;
    dataTotalCount?: number;
    pagination?: AisTablePagination;
    filterData?: FilterData;
    setFilter: (filter: FilterData) => void;
}

export const SalariesListPage = (props: Props) => {
    return (
        <>
            <AisPageHeader title="Список окладов" />
            <AisTable
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
