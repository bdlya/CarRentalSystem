import { Button } from '@material-ui/core';
import React from 'react';
import { User } from '../../types/User';
import { UserRole } from '../../types/UserRole';
import { authenticationService } from '../../utils/services/starting/authentication.service';
import { RouteComponentProps } from 'react-router-dom';

type HomeState = {
    currentUser: User | null,
    isAdmin: boolean,
    isAdminOwner: boolean,
}

export default class Home extends React.Component<RouteComponentProps>{
    constructor(props: RouteComponentProps){
        super(props);

        this.handleOnClick = this.handleOnClick.bind(this);
    }

    state: HomeState = {
        currentUser: null,
        isAdmin: false,
        isAdminOwner: false,
    }

    handleOnClick(){
        authenticationService.logout();
        this.props.history.push("/authorization")
    }

    componentDidMount(){
        authenticationService.currentUser.subscribe(user => this.setState({
            currentUser: user,
            isAdmin: user && user.role === UserRole.Administrator,
            isAdminOwner: user && user.role === UserRole.AdministratorOwner
        }))
    }

    render(){
        const {currentUser, isAdmin, isAdminOwner} = this.state;
        return (
            <div>
                {currentUser && 
                    <div>
                        <p>Hello user</p>
                        {isAdmin && <p>admin</p>}
                        {isAdminOwner && <p>adminOwner</p>}
                        <div>
                            <Button onClick={this.handleOnClick}>
                                Log out
                            </Button>
                        </div>
                    </div>
                }       
            </div>
        )
    }
}