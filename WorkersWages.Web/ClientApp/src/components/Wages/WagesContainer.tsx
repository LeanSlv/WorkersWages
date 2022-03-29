import { useCallback } from "react";
import { useAisList } from '@ais-gorod/react-ui';
import { WageListResponse, WorkersWagesApiClient } from '../../services/WorkersWagesApiClient';
import { FilterData } from './WagesListFilter';
import { WagesListPage } from './WagesListPage';
import { Route } from 'react-router-dom';
import { WagesDetailsModal } from './WagesDetailsModal';

export const WagesContainer = () => {
    const dataSource = useCallback(async (filter: FilterData, pageNumber: number, pageSize: number) => {
        const apiClient = new WorkersWagesApiClient('/extapi');
        const response = await apiClient.wagesGET(
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

    const { data, filter, setFilter, pagination } = useAisList<WageListResponse, FilterData>({
        dataSource: dataSource,
    });

    return (
        <>
            <Route path="/wages/details/:id" exact>
                <WagesDetailsModal />
            </Route>
            <WagesListPage
                data={data?.wages}
                dataTotalCount={data?.totalCount}
                filterData={filter}
                setFilter={setFilter}
                pagination={pagination}
            />
        </>
    );
};

WagesContainer.displayName = 'WagesContainer';
