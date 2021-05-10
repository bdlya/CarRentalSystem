import React from 'react'
import { RouteComponentProps } from 'react-router';
import { User } from '../../../../types/User';
import { UserRole } from '../../../../types/UserRole';
import { UserState } from '../../../../types/UserState';
import { authenticationService } from '../../authorization/services/authentication.service';

export default class HomeInfo extends React.Component<RouteComponentProps>{
    state: UserState = {
        currentUser: null,
        isAdmin: false,
        isAdminOwner: false,
    }

    componentDidMount(){
        let user: User | null = authenticationService.getCurrentUserValue();
        if(user){
            this.setState({
                currentUser: user,
                isAdmin: user && user.role === UserRole.Administrator,
                isAdminOwner: user && user.role === UserRole.AdministratorOwner
            })
        }
    }

    render(){
        const {currentUser, isAdmin, isAdminOwner} = this.state;
        return(
            <div>
                {currentUser &&
                <div>
                    <header>Welcome</header>
                    {isAdmin && 
                    <div>
                        <label>
                            Administrator
                        </label>
                    </div>
                    }
                    {isAdminOwner &&
                    <div>
                        <label>
                            Administrator owner
                        </label>
                    </div>
                    }
                    {(!isAdminOwner && !isAdmin) &&
                    <div>
                        <label>
                            User
                        </label>
                    </div>
                    }
                </div>
                }       
            </div>
        )
    }
}