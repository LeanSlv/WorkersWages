import { AisTablePagination, AisTable, AisPageHeader, AisDisplay } from '@ais-gorod/react-ui';
import { ProfessionInfo } from '../../services/WorkersWagesApiClient';
import { ProfessionsListFilter, FilterData } from './ProfessionsListFilter';

interface Props {
    data: ProfessionInfo[] | undefined;
    dataTotalCount?: number;
    pagination?: AisTablePagination;
    filterData?: FilterData;
    setFilter: (filter: FilterData) => void;
}

export const ProfessionsListPage = (props: Props) => {
    return (
        <>
            <AisPageHeader title="Список профессий" />
            <AisTable
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
