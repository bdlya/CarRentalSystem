import { BrowserRouter as Router, Route } from "react-router-dom";
import Registration from '../pages/common/registration/containers/Registration';
import Authorization from '../pages/common/authorization/containers/Authorization';
import Hello from '../pages/common/hello/containers/Hello';
import Home from "../pages/common/home/components/Home";
import { PrivateRoute }  from './PrivateRoute'
import { UserRole } from "../types/UserRole";
import UserManagement from "../pages/admin/adminowner/containers/UserManagement";
import PointManagement from "../pages/admin/adminowner/containers/PointManagement";
import CarManagement from "../pages/admin/adminManager/containers/CarManagement";
import AdditionalWorkManagement from "../pages/admin/adminManager/containers/AdditionalWorkManagement";
import Booking from '../pages/user/containers/Booking'
import Profile from "../pages/user/containers/Profile";

export const routes = (
    <Router>
        <Route exact path="/" component={ Hello } /> 
        <Route exact path="/registration" component={ Registration } />
        <Route exact path="/authorization" component={ Authorization } />
        <PrivateRoute exact path="/home" roles={null} component={ Home } />
        <PrivateRoute exact path ="/userManagement" roles={[UserRole.AdministratorOwner]} component = { UserManagement } />
        <PrivateRoute exact path ="/pointManagement" roles={[UserRole.AdministratorOwner]} component = { PointManagement } />
        <PrivateRoute exact path ="/carManagement" roles={[UserRole.Administrator]} component = { CarManagement } />
        <PrivateRoute exact path ="/additionalWorkManagement" roles={[UserRole.Administrator]} component = { AdditionalWorkManagement } />
        <PrivateRoute exact path ="/booking" roles={[UserRole.User]} component = { Booking } />
        <PrivateRoute exact path ="/profile" roles={[UserRole.User]} component = { Profile } />
    </Router>
)