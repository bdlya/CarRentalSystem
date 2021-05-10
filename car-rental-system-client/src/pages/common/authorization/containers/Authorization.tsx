import React from 'react';
import { authenticationService } from '../services/authentication.service';
import Card from '@material-ui/core/Card';
import { Button, CardActions, CardContent, TextField } from '@material-ui/core';
import { matchPath, RouteComponentProps } from 'react-router-dom';
import { Form, Field } from 'react-final-form';
import { FORM_ERROR } from 'final-form';

type FormState = {
    login: string;
    password: string;
}

export default class Authorization extends React.Component<RouteComponentProps<FormState>>{
    constructor(props: RouteComponentProps<FormState>){
        super(props)

        this.handleOnSubmit = this.handleOnSubmit.bind(this);
        this.handleOnChange = this.handleOnChange.bind(this);
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

    handleOnSubmit(): Promise<any> {
        return authenticationService.login(this.state.login, this.state.password)
        .then(res => {
            if(res.ok){
                this.props.history.push('/home')
            }
            else{
                if(res.type === "Form"){
                    return {[FORM_ERROR] : "Username or password are incorrect"}
                }

                return {login: res.errors['Login'], password: res.errors['Password']}
            }
        });
    }

    render(){
        return (
            <React.Fragment>
                <Form
                    onSubmit={this.handleOnSubmit}
                    render={({ handleSubmit, submitError,}) => (
                        <form onSubmit={handleSubmit}>
                            <Card>
                            <CardContent>
                                <div>
                                    <Field name="login">
                                        {({meta}) => (
                                            <div>
                                                <TextField name="login" label ="Login" onChange={this.handleOnChange} error={!meta.valid} helperText={meta.submitError? meta.error || meta.submitError : ''}/>
                                            </div>
                                        )}
                                    </Field>
                                    <Field name="password">
                                        {({meta}) => (
                                            <div>
                                                <TextField name="password" label ="Password" onChange={this.handleOnChange} error={!meta.valid} helperText={meta.submitError? meta.error || meta.submitError : ''}/>
                                            </div>
                                        )}
                                    </Field>
                                </div>
                            </CardContent>
                            <CardActions>
                                <Button type="submit">
                                    Sign in
                                </Button>
                            </CardActions>
                            {submitError && <div>{submitError}</div>}
                            </Card>
                        </form>
                    )}>
                </Form>
            </React.Fragment>
        );
    }
}
