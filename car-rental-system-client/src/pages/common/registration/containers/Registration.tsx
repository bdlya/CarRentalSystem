import React from 'react';
import { matchPath, RouteComponentProps } from 'react-router-dom';
import { Form, Field } from 'react-final-form';
import { Button, CardActions, CardContent, TextField } from '@material-ui/core';
import Card from '@material-ui/core/Card';
import { registrationService }  from '../services/registration.service';
import { FORM_ERROR } from 'final-form';


type FormState = {
    name: string;
    surname: string;
    login: string;
    password: string;
} 

export default class Registration extends React.Component<RouteComponentProps<FormState>>{
    constructor(props: RouteComponentProps<FormState>){
        super(props)

        this.handleOnSubmit = this.handleOnSubmit.bind(this);
        this.handleOnChange = this.handleOnChange.bind(this);
    }

    state: FormState = {
        name: '',
        surname: '',
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
        return registrationService.register(this.state.name, this.state.surname, this.state.login, this.state.password)
        .then(res => {
            if(res.ok){
                this.props.history.push('/authorization')
            }
            else{
                if(res.type === "Form"){
                    return {[FORM_ERROR] : res.message}
                }

                return {name: res.errors['Name'].split(',')[0], surname: res.errors['Surname'].split(',')[0], login: res.errors['Login'], password: res.errors['Password']}
            }
        })
    }

    render(){
        return (
            <React.Fragment>
                <Form
                    onSubmit={this.handleOnSubmit}
                    render={({ handleSubmit, submitError}) => (
                        <form onSubmit={handleSubmit}>
                            <Card>
                            <CardContent>
                                <div>
                                    <Field name="name">
                                        {({meta}) => (
                                            <div>
                                                <TextField name="name" label ="Name" onChange={this.handleOnChange} error={!meta.valid} helperText={meta.submitError? meta.error || meta.submitError : ''}/>
                                            </div>
                                        )}
                                    </Field>
                                    <Field name="surname">
                                        {({meta}) => (
                                            <div>
                                                <TextField name="surname" label ="Surname" onChange={this.handleOnChange} error={!meta.valid} helperText={meta.submitError? meta.error || meta.submitError : ''}/>
                                            </div>
                                        )}
                                    </Field>
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
                                    Sign up
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