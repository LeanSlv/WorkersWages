import { AisTablePagination, AisTable, AisPageHeader, AisDisplay } from '@ais-gorod/react-ui';
import { ScheduleInfo, TimeSpan, WeekDays } from '../../services/WorkersWagesApiClient';
import { SchedulesListFilter, FilterData } from './SchedulesListFilter';
import { Link } from 'react-router-dom';

interface Props {
    data: ScheduleInfo[] | undefined;
    dataTotalCount?: number;
    pagination?: AisTablePagination;
    filterData?: FilterData;
    setFilter: (filter: FilterData) => void;
}

const timeSpanFormat = (time: TimeSpan | undefined) => {
    if (!time || time.hours === undefined || time.minutes === undefined) return '-';

    const hours = time.hours.toString();
    const minutes = new Intl.NumberFormat('ru-RU', { minimumIntegerDigits: 2 }).format(time.minutes);
    return `${hours}:${minutes}`;
};

const WeekDayFormat = (weekDay: WeekDays) => {
    switch (weekDay) {
        case WeekDays.Monday: return 'Понедельник';
        case WeekDays.Tuesday: return 'Вторник';
        case WeekDays.Wednesday: return 'Среда';
        case WeekDays.Thursday: return 'Четверг';
        case WeekDays.Friday: return 'Пятница';
        case WeekDays.Saturday: return 'Суббота';
        case WeekDays.Sunday: return 'Воскресенье';
    }
};

export const SchedulesListPage = (props: Props) => {
    return (
        <>
            <AisPageHeader title="Графики работы цехов" />
            <AisTable
                filter={
                    <SchedulesListFilter
                        data={props.filterData}
                        onSubmit={(data) => {
                            data.page = 0;
                            props.setFilter(data);
                        }}
                        onReset={() => props.setFilter({ page: 0 })}
                        noCard
                    />
                }
                data={props.data}
                dataTotalCount={props.dataTotalCount}
                thead={
                    <>
                        <tr>
                            <th>ИД</th>
                            <th>Цех</th>
                            <th>День недели</th>
                            <th>
                                Время начала работы
                                <br />
                                <small>Время окончания работы</small>
                            </th>
                            <th>
                                Время начала перерыва
                                <br />
                                <small>Время окончания перерыва</small>
                            </th>
                            <th>
                                Создано
                                <br />
                                <small>Обновлено</small>
                            </th>
                        </tr>
                    </>
                }
                row={(item) => (
                    <tr key={item.id}>
                        <td>{item.id}</td>
                        <td>
                            <Link to={(l) => ({ ...l, pathname: `/manufactories/details/${item.manufactoryId}`})}>{item.manufactoryDisplayName}</Link>
                        </td>
                        <td>{WeekDayFormat(item.weekDay)}</td>
                        <td>
                            {timeSpanFormat(item.workingStart)}
                            <br />
                            <small>
                                {timeSpanFormat(item.workingEnd)}
                            </small>
                        </td>
                        <td>
                            {timeSpanFormat(item.breakStart)}
                            <br />
                            <small>
                                {timeSpanFormat(item.breakEnd)}
                            </small>
                        </td>
                        <td>
                            <AisDisplay.DateTime value={item.created} />
                            <br />
                            <small>
                                <AisDisplay.DateTime value={item.updated} />
                            </small>
                        </td>
                    </tr>
                )}
                pagination={props.pagination}
                useCard
            />
        </>
    );
};

SchedulesListPage.displayName = 'SchedulesListPage';
