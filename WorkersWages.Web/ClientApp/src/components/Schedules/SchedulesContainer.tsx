import { useCallback, useEffect } from "react";
import { useAisList } from '@ais-gorod/react-ui';
import { ScheduleListResponse, WorkersWagesApiClient } from '../../services/WorkersWagesApiClient';
import { FilterData } from './SchedulesListFilter';
import { SchedulesListPage } from './SchedulesListPage';
import { Route } from "react-router-dom";
import { SchedulesCreateModal } from './SchedulesCreateModal';
import { SchedulesEditModal } from './SchedulesEditModal';
import { useInterval } from "../../hooks/useInterval";

const apiClient = new WorkersWagesApiClient('/extapi');

export const SchedulesContainer = () => {
    const dataSource = useCallback(async (filter: FilterData, pageNumber: number, pageSize: number) => {
        const response = await apiClient.schedulesList(
            filter.manufactoryId,
            filter.weekDay,
            pageSize,
            pageNumber * pageSize,
        );
        console.log(response);
        return {
            data: response,
            count: response.totalCount ?? 0,
        };
    }, []);

    const { data, filter, setFilter, pagination, reloadData } = useAisList<ScheduleListResponse, FilterData>({
        dataSource: dataSource,
    });

    const handleDelete = useCallback(async (id: number) => {
        await apiClient.schedulesDelete(id).then((_) => reloadData());
    }, [reloadData]);

    const interval = useInterval({ callback: reloadData });
    useEffect(() => interval(), [interval]);

    return (
        <>
            <Route path="/schedules/add" exact>
                <SchedulesCreateModal onDataChanged={reloadData} />
            </Route>
            <Route path="/schedules/edit/:id" exact>
                <SchedulesEditModal onDataChanged={reloadData} />
            </Route>
            <SchedulesListPage
                data={data?.schedules}
                dataTotalCount={data?.totalCount}
                filterData={filter}
                setFilter={setFilter}
                pagination={pagination}
                handleDelete={handleDelete}
            />
        </>
    );
};

SchedulesContainer.displayName = 'SchedulesContainer';
