import { NavMenu } from './NavMenu';
import { AisLayout } from '@ais-gorod/react-ui';
import { ReactNode } from 'react';

interface Props {
    children: ReactNode | ReactNode[];
    isLoading: boolean;
}

export const Layout = (props: Props) => {
    return (
        <AisLayout nav={<NavMenu />} containerFluid isLoading={props.isLoading} pageTitleBase={'Сведения о месячной зарплате рабочих'}>
            {props.children}
        </AisLayout>
    );
};

Layout.displayName = 'Layout';
