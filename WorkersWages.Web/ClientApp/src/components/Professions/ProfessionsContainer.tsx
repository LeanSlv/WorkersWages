import { useCallback, useEffect } from "react";
import { useAisList } from '@ais-gorod/react-ui';
import { ProfessionListResponse, WorkersWagesApiClient } from '../../services/WorkersWagesApiClient';
import { FilterData } from './ProfessionsListFilter';
import { ProfessionsListPage } from './ProfessionsListPage';
import { Route } from "react-router-dom";
import { ProfessionsCreateModal } from './ProfessionsCreateModal';
import { ProfessionsEditModal } from './ProfessionsEditModal';
import { useInterval } from '../../hooks/useInterval';

const apiClient = new WorkersWagesApiClient('/extapi');

export const ProfessionsContainer = () => {
    const dataSource = useCallback(async (filter: FilterData, pageNumber: number, pageSize: number) => {
        const response = await apiClient.professionsList(
            filter.name,
            pageSize,
            pageNumber * pageSize,
        );

        return {
            data: response,
            count: response.totalCount ?? 0,
        };
    }, []);

    const { data, filter, setFilter, pagination, reloadData } = useAisList<ProfessionListResponse, FilterData>({
        dataSource: dataSource,
    });

    const handleDelete = useCallback(async (id: number) => {
        await apiClient.professionsDelete(id).then((_) => reloadData());
    }, [reloadData]);

    const interval = useInterval({ callback: reloadData });
    useEffect(() => interval(), [interval]);

    return (
        <>
            <Route path="/professions/add" exact>
                <ProfessionsCreateModal onDataChanged={reloadData} />
            </Route>
            <Route path="/professions/edit/:id" exact>
                <ProfessionsEditModal onDataChanged={reloadData} />
            </Route>
            <ProfessionsListPage
                data={data?.professions}
                dataTotalCount={data?.totalCount}
                filterData={filter}
                setFilter={setFilter}
                pagination={pagination}
                handleDelete={handleDelete}
            />
        </>
    );
};

ProfessionsContainer.displayName = 'ProfessionsContainer';