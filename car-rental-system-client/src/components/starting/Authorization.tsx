import React from 'react';
import Header from '../shared/Header';

export default class Authorization extends React.Component{
    render(){
        return (
            <React.Fragment>
                <Header />
                <div>
                    Sign in
                </div>
            </React.Fragment>
        );
    }
}