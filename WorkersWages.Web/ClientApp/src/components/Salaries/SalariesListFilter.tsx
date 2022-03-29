import { AisFilter, FilterBase, FilterProps, AisFormField, AisSelectOption } from '@ais-gorod/react-ui';
import { WorkersWagesApiClient } from '../../services/WorkersWagesApiClient';

export interface FilterData extends FilterBase {
    professionId?: number;
    rank?: number;
}

const professionIdOptions = async (inputValue: string, value: string | number | undefined, callback: (options: AisSelectOption<number>[]) => void) => {
    const apiClient = new WorkersWagesApiClient('/extapi');
    const data = await apiClient.professionsGET(inputValue, 20, 0);
    const options = data.professions?.map((item) => {
        return { value: item.id ?? 0, label: item.name };
    });
    callback(options);
};

export const SalariesListFilter = (props: FilterProps<FilterData>) => {
    return (
        <AisFilter {...props}>
            <AisFormField.SelectAsync label="Профессия" name="professionId" loadOptions={professionIdOptions} />
            <AisFormField.Number label="Разряд" name="rank" />
        </AisFilter>
    );
};

SalariesListFilter.displayName = 'SalariesListFilter';
