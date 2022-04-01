import { useCallback } from "react";
import { useAisList } from '@ais-gorod/react-ui';
import { WageListResponse, WorkersWagesApiClient } from '../../services/WorkersWagesApiClient';
import { FilterData } from './WagesListFilter';
import { WagesListPage } from './WagesListPage';
import { Route } from 'react-router-dom';
import { WagesDetailsPage } from './WagesDetailsPage';
import { WagesCreateModal } from './WagesCreateModal';
import { WagesEditModal } from './WagesEditModal';

const apiClient = new WorkersWagesApiClient('/extapi');

export const WagesContainer = () => {
    const dataSource = useCallback(async (filter: FilterData, pageNumber: number, pageSize: number) => {
        const response = await apiClient.wagesList(
            undefined,
            undefined,
            undefined,
            undefined,
            pageSize,
            pageNumber * pageSize,
        );

        return {
            data: response,
            count: response.totalCount ?? 0,
        };
    }, []);

    const { data, filter, setFilter, pagination, reloadData } = useAisList<WageListResponse, FilterData>({
        dataSource: dataSource,
    });

    const handleDelete = useCallback(async (id: number) => {
        await apiClient.wagesDelete(id).then((_) => reloadData());
    }, [reloadData]);

    return (
        <>
            <Route path="/wages" exact>
                <Route path="/wages/add" exact>
                    <WagesCreateModal onDataChanged={reloadData} />
                </Route>
                <Route path="/wages/edit/:id" exact>
                    <WagesEditModal onDataChanged={reloadData} />
                </Route>
                <WagesListPage
                    data={data?.wages}
                    dataTotalCount={data?.totalCount}
                    filterData={filter}
                    setFilter={setFilter}
                    pagination={pagination}
                    handleDelete={handleDelete}
                />
            </Route>
            <Route path="/wages/details/:id">
                <WagesDetailsPage />
            </Route>
        </>
    );
};

WagesContainer.displayName = 'WagesContainer';
