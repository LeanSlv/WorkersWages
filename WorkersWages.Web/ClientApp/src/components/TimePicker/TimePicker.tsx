import DatePicker, { registerLocale } from 'react-datepicker';
import ru from 'date-fns/locale/ru';
import { TimeInput } from './TimeInput';
import './FormField.scss';

interface Props {
    /** Дата начала. */
    time?: Date;

    /** Событие изменения хотя одной из дат. */
    onChange: (arg: { time: Date | undefined }) => void;

    /** ИД элемента. */
    id: string;

    /** Текст заполнителя при пустой дате. */
    placeholder?: string;

    /** Позиция иконки календаря. */
    iconPosition?: 'before' | 'after';

    /** Значение не прошло валидацию. */
    isInvalid?: boolean;
}

export const TimePicker = (props: Props) => {
    registerLocale('ru', ru);
    const handleChange = (time: Date | null) => {
        props.onChange({ time: time ?? undefined });
    };

    return (
        <DatePicker
            id={props.id}
            selected={props.time !== undefined ? props.time : null}
            onChange={handleChange}
            placeholderText={props.placeholder ?? ''}
            locale="ru"
            customInput={<TimeInput isInvalid={props.isInvalid} />}
            className="input-text form-control"
            popperModifiers={[
                {
                    name: 'arrow',
                    options: {
                        padding: 22, // 22px. Это просто magic number, чтобы стрелочка не была с самого края календаря.
                    },
                },
            ]}

            showTimeSelect
            showTimeSelectOnly
            timeCaption=""
            timeIntervals={15}
            dateFormat="HH:mm"
            timeFormat="HH:mm"
        />
    );
};

TimePicker.displayName = 'TimePicker';
