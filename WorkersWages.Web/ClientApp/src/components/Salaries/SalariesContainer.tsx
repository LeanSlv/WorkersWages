import { useCallback } from "react";
import { useAisList } from '@ais-gorod/react-ui';
import { SalaryListResponse, WorkersWagesApiClient } from '../../services/WorkersWagesApiClient';
import { FilterData } from './SalariesListFilter';
import { SalariesListPage } from './SalariesListPage';

export const SalariesContainer = () => {
    const dataSource = useCallback(async (filter: FilterData, pageNumber: number, pageSize: number) => {
        const apiClient = new WorkersWagesApiClient('/extapi');
        const response = await apiClient.salariesGET(
            filter.professionId,
            filter.rank,
            pageSize,
            pageNumber * pageSize,
        );

        return {
            data: response,
            count: response.totalCount ?? 0,
        };
    }, []);

    const { data, filter, setFilter, pagination } = useAisList<SalaryListResponse, FilterData>({
        dataSource: dataSource,
    });

    return (
        <>
            <SalariesListPage
                data={data?.salaries}
                dataTotalCount={data?.totalCount}
                filterData={filter}
                setFilter={setFilter}
                pagination={pagination}
            />
        </>
    );
};

SalariesContainer.displayName = 'SalariesContainer';
