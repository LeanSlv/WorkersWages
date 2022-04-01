import { useCallback } from "react";
import { useAisList } from '@ais-gorod/react-ui';
import { ManufactoryListResponse, WorkersWagesApiClient } from '../../services/WorkersWagesApiClient';
import { FilterData } from './ManufactoriesListFilter';
import { ManufactoriesListPage } from './ManufactoriesListPage';
import { ManufactoriesDetailsModal } from './ManufactoriesDetailsModal';
import { Route } from "react-router-dom";
import { ManufactoriesCreateModal } from './ManufactoriesCreateModal';
import { ManufactoriesEditModal } from './ManufactoriesEditModal';

const apiClient = new WorkersWagesApiClient('/extapi');

export const ManufactoriesContainer = () => {
    const dataSource = useCallback(async (filter: FilterData, pageNumber: number, pageSize: number) => {
        const response = await apiClient.manufactoriesList(
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

    const { data, filter, setFilter, pagination, reloadData } = useAisList<ManufactoryListResponse, FilterData>({
        dataSource: dataSource,
    });

    const handleDelete = useCallback(async (id: number) => {
        await apiClient.salariesDelete(id).then((_) => reloadData());
    }, [reloadData]);

    return (
        <>
            <Route path="/manufactories/details/:id" exact>
                <ManufactoriesDetailsModal />
            </Route>
            <Route path="/manufactories/add" exact>
                <ManufactoriesCreateModal onDataChanged={reloadData} />
            </Route>
            <Route path="/manufactories/edit/:id" exact>
                <ManufactoriesEditModal onDataChanged={reloadData} />
            </Route>
            <ManufactoriesListPage
                data={data?.manufactories}
                dataTotalCount={data?.totalCount}
                filterData={filter}
                setFilter={setFilter}
                pagination={pagination}
                handleDelete={handleDelete}
            />
        </>
    );
};

ManufactoriesContainer.displayName = 'ManufactoriesContainer';
