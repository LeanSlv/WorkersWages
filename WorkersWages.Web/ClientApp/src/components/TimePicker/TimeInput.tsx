import { forwardRef } from 'react';
import { InputGroup } from 'react-bootstrap';

interface Props {
    className?: string;

    autoComplete?: string;

    isInvalid?: boolean;
}

export const TimeInput = forwardRef<HTMLDivElement, Props>((props, ref) => {
    const inputProps = { ...props };
    inputProps.autoComplete = 'off';
    delete inputProps.isInvalid;
    if (props.isInvalid === true) {
        inputProps.className += ' is-invalid';
    }

    return (
        <InputGroup ref={ref} size={'sm'}>
            <input aria-autocomplete="none" {...inputProps} />
        </InputGroup>
    );
});

TimeInput.displayName = 'TimeInput';
