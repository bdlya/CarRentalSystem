import React from 'react';
import { RouteComponentProps } from 'react-router';
import NavigationBar from '../containers/NavigationBar';
import { Footer } from './Footer';

export const Layout = ({children, props} : {children: any, props: RouteComponentProps}) => {
    return(
        <React.Fragment>
            <NavigationBar history={props.history} location={props.location} match={props.match} />
            <main>
                {children}
            </main>
            <Footer />
        </React.Fragment>

    )
}