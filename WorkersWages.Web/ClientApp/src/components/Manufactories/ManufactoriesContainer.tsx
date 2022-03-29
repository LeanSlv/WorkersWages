import { useCallback } from "react";
import { useAisList } from '@ais-gorod/react-ui';
import { ManufactoryListResponse, WorkersWagesApiClient } from '../../services/WorkersWagesApiClient';
import { FilterData } from './ManufactoriesListFilter';
import { ManufactoriesListPage } from './ManufactoriesListPage';
import { ManufactoriesDetailsModal } from './ManufactoriesDetailsModal';
import { Route } from "react-router-dom";

export const ManufactoriesContainer = () => {
    const dataSource = useCallback(async (filter: FilterData, pageNumber: number, pageSize: number) => {
        const apiClient = new WorkersWagesApiClient('/extapi');
        const response = await apiClient.manufactoriesGET(
            filter.name,
            filter.number,
            pageSize,
            pageNumber * pageSize,
        );

        return {
            data: response,
            count: response.totalCount ?? 0,
        };
    }, []);

    const { data, filter, setFilter, pagination } = useAisList<ManufactoryListResponse, FilterData>({
        dataSource: dataSource,
    });

    return (
        <>
            <Route path="/manufactories/details/:id" exact>
                <ManufactoriesDetailsModal />
            </Route>
            <ManufactoriesListPage
                data={data?.manufactories}
                dataTotalCount={data?.totalCount}
                filterData={filter}
                setFilter={setFilter}
                pagination={pagination}
            />
        </>
    );
};

ManufactoriesContainer.displayName = 'ManufactoriesContainer';
