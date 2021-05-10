import React from 'react';
import { RouteComponentProps } from 'react-router-dom';
import HomeInfo from "../containers/HomeInfo"
import { Layout } from './Layout'

export default class Home extends React.Component<RouteComponentProps>{
    render(){
        return (
            <React.Fragment>
                <Layout props={this.props}>
                    <HomeInfo history = {this.props.history} location = {this.props.location} match = {this.props.match}/>
                </Layout>
            </React.Fragment>
        )
    }
}