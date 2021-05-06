import { BrowserRouter as Router, Route } from "react-router-dom";
import Registration from '../pages/common/registration/containers/Registration';
import Authorization from '../pages/common/authorization/containers/Authorization';
import Hello from '../pages/common/hello/containers/Hello';
import Home from "../pages/common/home/containers/Home";
import { PrivateRoute }  from './PrivateRoute'
import { UserRole } from "../types/UserRole";

export const routes = (
    <Router>
        <Route exact path="/" component={ Hello } /> 
        <Route exact path="/registration" component={ Registration } />
        <Route exact path="/authorization" component={ Authorization } />
        <PrivateRoute exact path="/home" roles={null} component={ Home } />
    </Router>
)