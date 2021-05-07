import React from 'react'
import { UserState } from './Home';

export default class HomeInfo extends React.Component<UserState>{
    constructor(props: UserState){
        super(props);
    }

    state: UserState = {
        currentUser: this.props.currentUser,
        isAdmin: this.props.isAdmin,
        isAdminOwner: this.props.isAdminOwner,
        history: this.props.history,
        location: this.props.location,
        match: this.props.match
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