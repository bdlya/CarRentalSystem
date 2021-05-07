import React from 'react';
import { User } from '../../../../types/User';
import { UserRole } from '../../../../types/UserRole';
import { authenticationService } from '../../authorization/services/authentication.service';
import { RouteComponentProps } from 'react-router-dom';
import NavigationBar from "./NavigationBar"

export interface UserState extends RouteComponentProps {
    currentUser: User | null,
    isAdmin: boolean,
    isAdminOwner: boolean,
}

export default class Home extends React.Component<RouteComponentProps>{

    _isMounted: boolean = false;

    state: UserState = {
        currentUser: null,
        isAdmin: false,
        isAdminOwner: false,
        history: this.props.history,
        location: this.props.location,
        match: this.props.match
    }

    componentDidMount(){
        this._isMounted = true;

        authenticationService.currentUser.subscribe(user => {
            if(this._isMounted){
                this.setState({
                    currentUser: user,
                    isAdmin: user && user.role === UserRole.Administrator,
                    isAdminOwner: user && user.role === UserRole.AdministratorOwner
                })
            }
        })
    }

    componentWillUnmount(){
       this._isMounted = false;
    }

    render(){
        const currentUser = this.state.currentUser;
        return (
            <div>
                {currentUser && 
                    <NavigationBar 
                    currentUser={this.state.currentUser} 
                    isAdmin = {this.state.isAdmin} 
                    isAdminOwner = {this.state.isAdminOwner}
                    history = {this.state.history}
                    location = {this.state.location}
                    match = {this.state.match}/>
                }       
            </div>
        )
    }
}