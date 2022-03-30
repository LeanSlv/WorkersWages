import { useCallback } from "react";
import { useAisList } from '@ais-gorod/react-ui';
import { ProfessionListResponse, WorkersWagesApiClient } from '../../services/WorkersWagesApiClient';
import { FilterData } from './ProfessionsListFilter';
import { ProfessionsListPage } from './ProfessionsListPage';
import { Route } from "react-router-dom";
import { ProfessionsCreateModal } from './ProfessionsCreateModal';
import { ProfessionsEditModal } from './ProfessionsEditModal';

const apiClient = new WorkersWagesApiClient('/extapi');

export const ProfessionsContainer = () => {
    const dataSource = useCallback(async (filter: FilterData, pageNumber: number, pageSize: number) => {
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

    const { data, filter, setFilter, pagination, reloadData } = useAisList<ProfessionListResponse, FilterData>({
        dataSource: dataSource,
    });

    const handleDelete = useCallback(async (id: number) => {
        await apiClient.professionsDELETE(id).then((_) => reloadData());
    }, [reloadData]);

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