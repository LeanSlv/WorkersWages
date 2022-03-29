import { AisFilter, FilterBase, FilterProps, AisFormField } from '@ais-gorod/react-ui';

export interface FilterData extends FilterBase {
    name?: string;
}

export const ProfessionsListFilter = (props: FilterProps<FilterData>) => {
    return (
        <AisFilter {...props}>
            <AisFormField.Text label="Название" name="name" />
        </AisFilter>
    );
};

ProfessionsListFilter.displayName = 'ProfessionsListFilter';
