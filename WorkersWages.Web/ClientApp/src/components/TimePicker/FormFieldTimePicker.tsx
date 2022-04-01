import { FunctionComponent } from 'react';
import { getIn } from 'formik';
import { FormFieldWrapper } from './FormFieldWrapper';
import { TimePicker } from './TimePicker';
import { FormFieldError } from './FormFieldError';

interface Props {
    /** Свойство name. Имя элемента из модели формы. */
    name: string;

    /** Заголовок. */
    label: false | string;

    /** Текст заполнителя при пустом элемента ввода. */
    placeholder?: string;
}

export const FormFieldTimePicker: FunctionComponent<Props> = (props: Props) => {
    return (
        <FormFieldWrapper {...props}>
            {(formik) => (
                <>
                    <TimePicker
                        id={props.name}
                        time={getIn(formik.values, props.name)}
                        onChange={({ time }) => formik.setFieldValue(props.name, time)}
                        isInvalid={!!getIn(formik.errors, props.name) || !!formik.errors[props.name]}
                    />
                    <FormFieldError name={props.name} errors={formik.errors} />
                </>
            )}
        </FormFieldWrapper>
    );
};

FormFieldTimePicker.displayName = 'FormFieldTimePicker';