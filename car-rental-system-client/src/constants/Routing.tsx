import { BrowserRouter as Router, Route } from "react-router-dom";
import Registration from '../components/starting/Registration';
import Authorization from '../components/starting/Authorization';
import Hello from '../components/starting/Hello';
import App from '../App'

export const routing = (
    <Router>
        <Route exact path="/" component={ App } /> 
        <Route exact path="/hello" component={ Hello } />
        <Route exact path="/registration" component={ Registration } />
        <Route exact path="/authorization" component={ Authorization } />
    </Router>
)