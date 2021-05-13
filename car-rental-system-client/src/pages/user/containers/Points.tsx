import { Button, ButtonBase, Card, CardContent, TextField } from '@material-ui/core';
import React, { useState } from 'react';
import { RouteComponentProps } from 'react-router';
import Point from '../../../types/Point';
import { Layout } from '../../common/home/components/Layout';
import { pointService } from '../services/point.service';
import Autocomplete from '@material-ui/lab/Autocomplete';

type PointsState = {
    points: Point[] | null,
    countries: string[]
    cities: string[],
    country: string,
    city: string,
    date: Date
}

export default class Points extends React.Component<RouteComponentProps>{
    constructor(props: RouteComponentProps){
        super(props)

        this.filterPoints = this.filterPoints.bind(this);
        this.handleOnChange = this.handleOnChange.bind(this);
        this.nextPath = this.nextPath.bind(this)
    }

    state: PointsState = {
        points: null,
        countries: [],
        cities: [],
        country: "",
        city: "",
        date: new Date()
    }

    componentDidMount(){
       pointService.getAllPoints()
       .then((res) => {
           if(res.ok){
            this.setState({
                points: res.data,
            })
            this.setState({
                countries: this.state.points?.map((point) => point.country).filter(function(elem, index, self) {return index === self.indexOf(elem)}) || [],
                cities: this.state.points?.map((point) => point.city).filter(function(elem, index, self) {return index === self.indexOf(elem)}) || []
            })
           }
       })
    }

    filterPoints(){
        const {country, city, date} = this.state
        pointService.filterPoints(country, city, date)
        .then((res) => {
            if(res.ok){
                this.setState({
                    points: res.data
                })
            }
        })
    }

    handleOnChange(event: any, value: string | null){
        const id = event.target.id.split('-')[0];
            this.setState({
                [id]: value
            })
    }

    nextPath(path: string){
        this.props.history.push(path);
    }

    render(){
        const { points } = this.state;
        return(
            <React.Fragment>
               <Layout props={this.props}>
                   <Card>
                       <CardContent>
                       <Autocomplete options={this.state.countries} id ="country" freeSolo onInputChange={(event, value) => this.handleOnChange(event, value)} renderInput={(params) => 
                           <TextField {...params} InputProps = {{ ...params.InputProps, endAdornment : null }} label="Country"/>
                       }/>
                       <Autocomplete options={this.state.cities} id ="city" freeSolo onInputChange={(event, value) => this.handleOnChange(event, value)} renderInput={(params) => 
                           <TextField {...params} InputProps = {{ ...params.InputProps, endAdornment : null }} label="City"/>
                       }/>
                       </CardContent>
                       <CardContent>
                           <Button onClick={this.filterPoints}>Search</Button>
                       </CardContent>
                    </Card>
                   {points?.map((point) => (
                   <Card>
                       <ButtonBase onClick={() => this.nextPath(`/cars/${ point.id }`)}>
                           <CardContent>
                           {point.id} {point.name} {point.country} {point.city} {point.address}
                           </CardContent>
                       </ButtonBase>
                      </Card>
                   ))}
               </Layout>
            </React.Fragment>
        )
    }
}