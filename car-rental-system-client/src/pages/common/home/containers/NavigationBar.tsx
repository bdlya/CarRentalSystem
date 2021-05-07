import { AppBar, Button, Toolbar } from "@material-ui/core";
import React from "react"
import { authenticationService } from '../../authorization/services/authentication.service';
import { RouteComponentProps } from "react-router";
import { User } from "../../../../types/User";
import { UserRole } from "../../../../types/UserRole";
import { UserState } from '../../../../types/UserState';


export default class NavigationBar extends React.Component<RouteComponentProps>{
    constructor(props: RouteComponentProps){
        super(props);

        this.handleOnLogout = this.handleOnLogout.bind(this);
        this.nextPath = this.nextPath.bind(this)
    }

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

    handleOnLogout(){
        authenticationService.logout();
        this.nextPath("/authorization")
    }

    nextPath(path: string){
        this.props.history.push(path);
    }

    render(){
        const {currentUser, isAdmin, isAdminOwner} = this.state;
        return(
            <div style={{margin: "100px"}}>
                {currentUser &&
                <AppBar>
                    <Toolbar>
                    <Button onClick={() => this.nextPath("/home")}>
                        Home
                    </Button>
                    {isAdminOwner &&
                    <div>
                    <Button onClick={() => this.nextPath("/userManagement")}>User Management</Button>
                    <Button onClick={() => this.nextPath("/pointManagement")}>Point Management</Button>
                    </div>
                    }
                    {isAdmin &&
                    <div>
                    <Button onClick={() => this.nextPath("/carManagement")}>Car Management</Button>
                    <Button onClick={() => this.nextPath("/additionalWorkManagement")}>Additional work management</Button>
                    </div>
                    }
                    {(!isAdminOwner && !isAdmin) &&
                    <div>
                    <Button onClick={() => this.nextPath("/booking")}>Booking</Button>
                    <Button onClick={() => this.nextPath("/profile")}>Profile</Button>
                    </div>
                    }
                    <Button onClick={this.handleOnLogout}>
                        Logout
                    </Button>
                    </Toolbar>
                </AppBar>
                }
            </div>
        )
    }
}