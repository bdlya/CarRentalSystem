import React from 'react';
import { RouteComponentProps } from 'react-router';
import { Layout } from '../../common/home/components/Layout';

export default class Profile extends React.Component<RouteComponentProps>{
    render(){
        return(
            <React.Fragment>
               <Layout props={this.props}>
                   <p>Profile</p>
               </Layout>
            </React.Fragment>
        )
    }
}