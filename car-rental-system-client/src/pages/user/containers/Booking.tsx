import { Card, CardContent } from '@material-ui/core';
import React from 'react';
import { RouteComponentProps } from 'react-router';
import AdditionalWork from '../../../types/AdditionalWork';
import Car from '../../../types/Car';
import { Layout } from '../../common/home/components/Layout';
import { bookingService } from '../services/booking.servise';
import { carService } from '../services/car.service';

type BookingProps = RouteComponentProps<{
    id: string
}>

type BookingState = {
    car: Car | null,
    additionalWorks: AdditionalWork[]
}

export default class Booking extends React.Component<BookingProps>{
    state: BookingState = {
        car: null,
        additionalWorks: []
    }

    componentDidMount(){
        bookingService.getCar(+this.props.match.params.id)
        .then(res => {
            if(res.ok){
                this.setState({
                    car: res.singleData
                })
            }
        })
        bookingService.getAdditionalWorks()
        .then(res => {
            if(res.ok){
                this.setState({
                    additionalWorks: res.data
                })
            }
        })
    }

    render(){
        const {car, additionalWorks} = this.state
        return(
            <React.Fragment>
               <Layout props={this.props}>
                   <Card>
                       <CardContent>
                           {car?.brand} {car?.costPerHour} {car?.numberOfSeats} {car?.transmissionType} {car?.averageFuelConsumption}
                       </CardContent>
                   </Card>
                   <Card>
                       {additionalWorks.map((work) => (
                           <CardContent>
                               {work.name} {work.cost}
                           </CardContent>
                       ))}
                   </Card>
               </Layout>
            </React.Fragment>
        )
    }
}