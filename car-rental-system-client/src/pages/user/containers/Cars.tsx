import React from 'react';
import { RouteComponentProps, RouterProps, WithRouterProps } from 'react-router';
import Car from '../../../types/Car';
import { Layout } from '../../common/home/components/Layout';
import { carService } from '../services/car.service';
import { Button, ButtonBase, Card, CardContent, TextField } from '@material-ui/core';
import Autocomplete from '@material-ui/lab/Autocomplete';

type CarProps = RouteComponentProps<{
    id: string
}>

type CarsState ={
    cars: Car[]
    brands: string[]
    brand: string,
    transmission: string,
    numberOfSeats: number
}

export default class Cars extends React.Component<CarProps>{
    constructor(props: CarProps){
        super(props)

        this.handleOnChange = this.handleOnChange.bind(this);
        this.filterCars = this.filterCars.bind(this);
        this.nextPath = this.nextPath.bind(this);
    }

    state: CarsState = {
        cars: [],
        brands: [],
        brand: '',
        transmission: '',
        numberOfSeats: 0
    }

    componentDidMount(){
        this.getCars(+this.props.match.params.id);
    }

    componentWillReceiveProps(props: CarProps){
        this.getCars(+props.match.params.id);
    }

    getCars(pointId: number){
        carService.getFreeCars(pointId)
        .then((res) => {
            if(res.ok){
                this.setState({
                    cars: res.data
                })
                this.setState({
                    brands: this.state.cars?.map((car) => car.brand).filter(function(elem, index, self) {return index === self.indexOf(elem)}) || []
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

    filterCars(){
        carService.filterCars(+this.props.match.params.id, this.state.brand, this.state.transmission, this.state.numberOfSeats)
        .then((res) => {
            if(res.ok){
                this.setState({
                    cars: res.data
                })
            }
        })
    }

    nextPath(path: string){
        this.props.history.push(path);
    }

    render(){
        const cars = this.state.cars;
        return(
            <React.Fragment>
               <Layout props={this.props}>
               <Card>
                       <CardContent>
                       <Autocomplete options={this.state.brands} id ="brand" freeSolo onInputChange={(event, value) => this.handleOnChange(event, value)} renderInput={(params) => 
                           <TextField {...params} InputProps = {{ ...params.InputProps, endAdornment : null }} label="Brand"/>
                       }/>
                       <Autocomplete options={["Mechanic", "Automatic"]} id ="transmission" onInputChange={(event, value) => this.handleOnChange(event, value)} renderInput={(params) => 
                           <TextField {...params} InputProps = {{ ...params.InputProps, endAdornment : null }} label="Transmission"/>
                       }/>
                       <TextField label="Number of seats" id="numberOfSeats" onChange={(event) => this.handleOnChange(event, event.target.value)}/>
                       </CardContent>
                       <CardContent>
                           <Button onClick={this.filterCars}>Search</Button>
                       </CardContent>
                    </Card>
               {cars?.map((car) => (
                   <Card>
                       <ButtonBase onClick={() => this.nextPath(`/booking/${ car.id }`)}>
                           <CardContent>
                           {car.id} {car.brand} {car.averageFuelConsumption} {car.costPerHour} {car.numberOfSeats} {car.transmissionType}
                           </CardContent>
                       </ButtonBase>
                      </Card>
                   ))}
               </Layout>
            </React.Fragment>
        )
    }
}