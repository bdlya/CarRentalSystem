import React from 'react';
import { RouteComponentProps, RouterProps, WithRouterProps } from 'react-router';
import { Layout } from '../../common/home/components/Layout';

type CarProps = RouteComponentProps<{
    id: string
}>

export default class Cars extends React.Component<CarProps>{
    render(){
        return(
            <React.Fragment>
               <Layout props={this.props}>
                   <p>{this.props.match.params.id}</p>
               </Layout>
            </React.Fragment>
        )
    }
}