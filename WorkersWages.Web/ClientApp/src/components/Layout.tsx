import { NavMenu } from './NavMenu';
import { AisLayout } from '@ais-gorod/react-ui';
import { ReactNode } from 'react';

export const Layout = (props: { children: ReactNode | ReactNode[]; isLoading: boolean }) => {
    return (
        <AisLayout nav={<NavMenu />} containerFluid isLoading={props.isLoading} pageTitleBase={'Сведения о месячной зарплате рабочих'}>
            {props.children}
        </AisLayout>
    );
};

Layout.displayName = 'Layout';
