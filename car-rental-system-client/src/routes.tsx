import { BrowserRouter as Router, Route } from "react-router-dom";
import Registration from './containers/starting/Registration';
import Authorization from './containers/starting/Authorization';
import Hello from './containers/starting/Hello';
import Home from "./containers/home/Home";
import { PrivateRoute }  from './containers/routing/PrivateRoute'
import { UserRole } from "./types/UserRole";

export const routes = (
    <Router>
        <Route exact path="/" component={ Hello } /> 
        <Route exact path="/registration" component={ Registration } />
        <Route exact path="/authorization" component={ Authorization } />
        <PrivateRoute exact path="/home" roles={null} component={ Home } />
    </Router>
)