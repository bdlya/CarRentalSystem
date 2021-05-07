import React from 'react'
import { RouteComponentProps } from 'react-router'
import { authenticationService } from '../../../common/authorization/services/authentication.service'
import { Footer } from '../../../common/home/components/Footer'
import { UserState } from '../../../common/home/containers/Home'
import NavigationBar from '../../../common/home/containers/NavigationBar'

export default class AdditionalWorkManagement extends React.Component<RouteComponentProps>{
    state: UserState = {
        currentUser: authenticationService.getCurrentUserValue(),
        isAdmin: true,
        isAdminOwner: false,
        history: this.props.history,
        location: this.props.location,
        match: this.props.match
    }

    render(){
        return(
            <React.Fragment>
                <NavigationBar 
                    currentUser={this.state.currentUser} 
                    isAdmin = {this.state.isAdmin} 
                    isAdminOwner = {this.state.isAdminOwner}
                    history = {this.state.history}
                    location = {this.state.location}
                    match = {this.state.match} />
                <p>AdditionalWorkManagement</p>
                <Footer />
            </React.Fragment>
        )
    }
}