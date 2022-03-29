import { useCallback } from "react";
import { useAisList } from '@ais-gorod/react-ui';
import { ScheduleListResponse, WorkersWagesApiClient } from '../../services/WorkersWagesApiClient';
import { FilterData } from './SchedulesListFilter';
import { SchedulesListPage } from './SchedulesListPage';

export const SchedulesContainer = () => {
    const dataSource = useCallback(async (filter: FilterData, pageNumber: number, pageSize: number) => {
        const apiClient = new WorkersWagesApiClient('/extapi');
        const response = await apiClient.schedulesGET(
            filter.manufactoryId,
            filter.weekDay,
            pageSize,
            pageNumber * pageSize,
        );

        return {
            data: response,
            count: response.totalCount ?? 0,
        };
    }, []);

    const { data, filter, setFilter, pagination } = useAisList<ScheduleListResponse, FilterData>({
        dataSource: dataSource,
    });

    return (
        <>
            <SchedulesListPage
                data={data?.schedules}
                dataTotalCount={data?.totalCount}
                filterData={filter}
                setFilter={setFilter}
                pagination={pagination}
            />
        </>
    );
};

SchedulesContainer.displayName = 'SchedulesContainer';
