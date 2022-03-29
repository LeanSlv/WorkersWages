import { useCallback } from "react";
import { useAisList } from '@ais-gorod/react-ui';
import { ProfessionListResponse, WorkersWagesApiClient } from '../../services/WorkersWagesApiClient';
import { FilterData } from './ProfessionsListFilter';

import { ProfessionsListPage } from './ProfessionsListPage';

export const ProfessionsContainer = () => {
    const dataSource = useCallback(async (filter: FilterData, pageNumber: number, pageSize: number) => {
        const apiClient = new WorkersWagesApiClient('/extapi');
        const response = await apiClient.professionsGET(
            filter.name,
            pageSize,
            pageNumber * pageSize,
        );

        return {
            data: response,
            count: response.totalCount ?? 0,
        };
    }, []);

    const { data, filter, setFilter, pagination } = useAisList<ProfessionListResponse, FilterData>({
        dataSource: dataSource,
    });

    return (
        <>
            <ProfessionsListPage
                data={data?.professions}
                dataTotalCount={data?.totalCount}
                filterData={filter}
                setFilter={setFilter}
                pagination={pagination}
            />
        </>
    );
};

ProfessionsContainer.displayName = 'ProfessionsContainer';