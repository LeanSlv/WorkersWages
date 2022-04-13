import { useCallback, useEffect } from "react";
import { useAisList } from '@ais-gorod/react-ui';
import { SalaryListResponse, WorkersWagesApiClient } from '../../services/WorkersWagesApiClient';
import { FilterData } from './SalariesListFilter';
import { SalariesListPage } from './SalariesListPage';
import { SalariesCreateModal } from './SalariesCreateModal';
import { SalariesEditModal } from './SalariesEditModal';
import { Route } from 'react-router-dom';
import { useInterval } from "../../hooks/useInterval";

const apiClient = new WorkersWagesApiClient('/extapi');

export const SalariesContainer = () => {
    const dataSource = useCallback(async (filter: FilterData, pageNumber: number, pageSize: number) => {
        const response = await apiClient.salariesList(
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

    const { data, filter, setFilter, pagination, reloadData } = useAisList<SalaryListResponse, FilterData>({
        dataSource: dataSource,
    });

    const handleDelete = useCallback(async (id: number) => {
        await apiClient.salariesDelete(id).then((_) => reloadData());
    }, [reloadData]);

    const interval = useInterval({ callback: reloadData });
    useEffect(() => interval(), [interval]);

    return (
        <>
            <Route path="/salaries/add" exact>
                <SalariesCreateModal onDataChanged={reloadData} />
            </Route>
            <Route path="/salaries/edit/:id" exact>
                <SalariesEditModal onDataChanged={reloadData} />
            </Route>
            <SalariesListPage
                data={data?.salaries}
                dataTotalCount={data?.totalCount}
                filterData={filter}
                setFilter={setFilter}
                pagination={pagination}
                handleDelete={handleDelete}
            />
        </>
    );
};

SalariesContainer.displayName = 'SalariesContainer';
