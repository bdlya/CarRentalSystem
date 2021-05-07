import React from 'react';
import { authenticationService } from '../services/authentication.service';
import Card from '@material-ui/core/Card';
import { Button, CardActions, CardContent, TextField } from '@material-ui/core';
import { RouteComponentProps } from 'react-router-dom';

type FormState = {
    login: string,
    password: string
}

export default class Authorization extends React.Component<RouteComponentProps<FormState>>{
    constructor(props: RouteComponentProps<FormState>){
        super(props)

        this.handleOnChange = this.handleOnChange.bind(this);
        this.handleOnSubmit = this.handleOnSubmit.bind(this);
    }

    state: FormState = {
        login: '',
        password: '',
    }

    handleOnChange(event: any){
        const value = event.target.value;
        const name = event.target.name;
        this.setState({
            [name]: value
        })
    }

    handleOnSubmit(){
        authenticationService.login(this.state.login, this.state.password, this.props.history.push);
    }

    render(){
        return (
            <React.Fragment>
                <div>
                    Sign in
                </div>
                <form>
                    <Card>
                        <CardContent>
                            <div>
                                <TextField name="login" label ="Login" onChange={this.handleOnChange}/>
                                <TextField name="password" label="Password" onChange={this.handleOnChange}/>
                            </div>
                        </CardContent>
                        <CardActions>
                            <Button onClick={this.handleOnSubmit}>
                                Sign in
                            </Button>
                        </CardActions>
                    </Card>
                </form>
            </React.Fragment>
        );
    }
}
