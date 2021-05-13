import React from 'react';
import { RouteComponentProps } from 'react-router';
import { Layout } from '../../common/home/components/Layout';

type BookingProps = RouteComponentProps<{
    id: string
}>

export default class Booking extends React.Component<BookingProps>{
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