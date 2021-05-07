import React from 'react'
import { RouteComponentProps } from 'react-router'
import { Layout } from '../../../common/home/components/Layout'

export default class PointManagement extends React.Component<RouteComponentProps>{
    srender(){
        return(
            <React.Fragment>
               <Layout props={this.props}>
                   <p>Point Management</p>
               </Layout>
            </React.Fragment>
        )
    }
}