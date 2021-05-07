import { AppBar, Button, Toolbar } from "@material-ui/core";
import React from "react"
import { UserState } from './Home'
import { authenticationService } from '../../authorization/services/authentication.service';

export default class NavigationBar extends React.Component<UserState>{
    constructor(props: UserState){
        super(props);

        this.handleOnLogout = this.handleOnLogout.bind(this);
        this.nextPath = this.nextPath.bind(this)
    }

    state: UserState = {
        currentUser: this.props.currentUser,
        isAdmin: this.props.isAdmin,
        isAdminOwner: this.props.isAdminOwner,
        history: this.props.history,
        location: this.props.location,
        match: this.props.match
    }

    handleOnLogout(){
        authenticationService.logout();
        this.state.history.push("/authorization")
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
                    <Button>Booking</Button>
                    <Button>Profile</Button>
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