import { ReactNode, FunctionComponent } from 'react';
import { FormikContextType, useFormikContext } from 'formik';
import { Col, Form, Row } from 'react-bootstrap';
import './FormField.scss';

export interface Props {
    /** Свойство name. Имя элемента из модели формы. */
    name: string;

    /** Заголовок. */
    label: false | string;

    /** Собственно элемент формы. */
    children: (formik: FormikContextType<FormikValues>) => ReactNode;
}

interface FormikValues {
    [key: string]: any;
}

export const FormFieldWrapper: FunctionComponent<Props> = (props: Props) => {
    const formik = useFormikContext<FormikValues>();

    const wrapperContent = (
        <>
            {props.label !== false && (
                <Form.Label
                    column
                    sm={12}
                    className={'form-field-label'}
                >
                    {props.label}
                </Form.Label>
            )}
            <Col sm={12}>{props.children(formik)}</Col>
        </>
    );

    return (
        <Form.Group as={Row} controlId={props.name} className={'mb-3'}>
            {wrapperContent}
        </Form.Group>
    );
};

FormFieldWrapper.displayName = 'FormFieldWrapper';
