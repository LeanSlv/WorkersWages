import { AisFilter, FilterBase, FilterProps, AisFormField } from '@ais-gorod/react-ui';

export interface FilterData extends FilterBase {
    name?: string;
    number?: string;
}

export const ManufactoriesListFilter = (props: FilterProps<FilterData>) => {
    return (
        <AisFilter {...props}>
            <AisFormField.Text label="Название" name="name" />
            <AisFormField.Text label="Номер" name="number" />
        </AisFilter>
    );
};

ManufactoriesListFilter.displayName = 'ManufactoriesListFilter';
