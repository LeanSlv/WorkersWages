import { FormikErrors } from 'formik';
import { Form } from 'react-bootstrap';
import { AisDisplay } from '@ais-gorod/react-ui';

interface Props {
    /** Ошибки от formik. */
    errors: FormikErrors<any>;

    /** Имя элемента из модели формы.. */
    name: string | string[];

    /** Дополнительный css-класс. */
    className?: string;
}

export const FormFieldError = (props: Props) => {
    const hasErrors = () => {
        if (typeof props.name === 'string') {
            return props.errors[props.name] !== undefined;
        } else {
            let hasErrors = false;

            props.name.some((i) => {
                if (props.errors[i] !== undefined) {
                    hasErrors = true;
                    return true;
                }
                return false;
            });

            return hasErrors;
        }
    };

    const getErrors = () => {
        if (typeof props.name === 'string') {
            return props.errors[props.name] as string;
        } else {
            let errors = '';

            props.name.forEach((i) => {
                if (props.errors[i] !== undefined) {
                    errors = errors === '' ? (props.errors[i] as string) : ((errors + '\n' + props.errors[i]) as string);
                }
            });

            return errors;
        }
    };

    if (!hasErrors()) {
        return <></>;
    }
    return (
        <Form.Control.Feedback type="invalid" className={props.className}>
            <AisDisplay.MultilineText value={getErrors()} />
        </Form.Control.Feedback>
    );
};

FormFieldError.displayName = 'FormFieldError';
