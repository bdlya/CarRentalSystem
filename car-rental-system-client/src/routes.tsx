import { BrowserRouter as Router, Route } from "react-router-dom";
import Registration from './containers/starting/Registration';
import Authorization from './containers/starting/Authorization';
import Hello from './containers/starting/Hello';
import App from './containers/main/App'

export const routes = (
    <Router>
        <Route exact path="/" component={ App } /> 
        <Route exact path="/hello" component={ Hello } />
        <Route exact path="/registration" component={ Registration } />
        <Route exact path="/authorization" component={ Authorization } />
    </Router>
)