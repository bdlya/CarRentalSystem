import React from 'react';
import { BrowserRouter as Route, Link } from "react-router-dom";

export default class Hello extends React.Component {
    render(){
        return(
            <React.Fragment>
                <div>
                    Hello
                </div>
                <div>
                    <Link to="/registration">Registration</Link>
                </div>
                <div>
                    <Link to="/authorization">Authorization</Link>
                </div>
            </React.Fragment>
        );
    }
}