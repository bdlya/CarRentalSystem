import React from "react"
import { Redirect, Route, RouteComponentProps, RouteProps } from "react-router-dom"
import { authenticationService } from '../pages/common/authorization/services/authentication.service'

type RouteComponent = React.FunctionComponent<RouteComponentProps<{}>> | React.ComponentClass<any>

interface PrivateRouteProps extends RouteProps{
    roles: string[] | null
}

export const PrivateRoute: React.FunctionComponent<PrivateRouteProps> = ({component, roles, ...rest}) => {
  const renderComponent = (Component?: RouteComponent) => (props: RouteComponentProps) => {
    if (!Component) {
      return null
    }

    const currentUser = authenticationService.getCurrentUserValue();
    if(!currentUser){
        return <Redirect to="/authorization" />
    }

    if(roles && roles.indexOf(currentUser.role) === -1){
        return <Redirect to="/home" />
    }

    return <Component {...props} />
  }

  return <Route {...rest} render={renderComponent(component)} />
}