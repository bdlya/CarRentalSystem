import { AppBar, Button, Toolbar } from "@material-ui/core";
import React from "react"
import { UserState } from './Home'
import { authenticationService } from '../../authorization/services/authentication.service';

export default class NavigationBar extends React.Component<UserState>{
    constructor(props: UserState){
        super(props);

        this.handleOnClick = this.handleOnClick.bind(this);
    }

    state: UserState = {
        currentUser: this.props.currentUser,
        isAdmin: this.props.isAdmin,
        isAdminOwner: this.props.isAdminOwner,
        history: this.props.history,
        location: this.props.location,
        match: this.props.match
    }

    handleOnClick(){
        authenticationService.logout();
        this.state.history.push("/authorization")
    }

    render(){
        const {currentUser, isAdmin, isAdminOwner} = this.state;
        return(
            <div>
                {currentUser &&
                <AppBar>
                    <Toolbar>
                    <Button>
                        Home
                    </Button>
                    {isAdminOwner &&
                    <div>
                    <Button>User Management</Button>
                    <Button>Point Management</Button>
                    </div>
                    }
                    {isAdmin &&
                    <div>
                    <Button>Car Management</Button>
                    <Button>Additional service management</Button>
                    </div>
                    }
                    {(!isAdminOwner && !isAdmin) &&
                    <div>
                    <Button>Booking</Button>
                    <Button>Profile</Button>
                    </div>
                    }
                    <Button onClick={this.handleOnClick}>
                        Logout
                    </Button>
                    </Toolbar>
                </AppBar>
                }
            </div>
        )
    }
}