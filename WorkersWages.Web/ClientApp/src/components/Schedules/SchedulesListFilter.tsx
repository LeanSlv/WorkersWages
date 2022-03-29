import { AisFilter, FilterBase, FilterProps, AisFormField, AisSelectOption } from '@ais-gorod/react-ui';
import { WeekDays, WorkersWagesApiClient } from '../../services/WorkersWagesApiClient';

export interface FilterData extends FilterBase {
    manufactoryId?: number;
    weekDay?: WeekDays;
}

const professionIdOptions = async (inputValue: string, value: string | number | undefined, callback: (options: AisSelectOption<number>[]) => void) => {
    const apiClient = new WorkersWagesApiClient('/extapi');
    const data = await apiClient.manufactoriesGET(inputValue, undefined, 20, 0);
    const options = data.manufactories?.map((item) => {
        return { value: item.id ?? 0, label: item.name };
    });
    callback(options);
};

export const SchedulesListFilter = (props: FilterProps<FilterData>) => {
    return (
        <AisFilter {...props}>
            <AisFormField.SelectAsync label="Цех" name="manufactoryId" loadOptions={professionIdOptions} />
            <AisFormField.Text label="День недели" name="weekDay" />
        </AisFilter>
    );
};

SchedulesListFilter.displayName = 'SchedulesListFilter';
