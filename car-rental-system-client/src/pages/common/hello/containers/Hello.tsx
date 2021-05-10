import React from 'react';
import { BrowserRouter as Route, Link } from "react-router-dom";
import '../../../../index.css';
import { AppBar, Toolbar, Typography } from "@material-ui/core";
import { styled } from '@material-ui/core/styles';
import DirectionsCarIcon from '@material-ui/icons/DirectionsCar';
import { DiDotnet } from 'react-icons/di';
import { DiReact } from 'react-icons/di';
import { SiMaterialUi } from 'react-icons/si';


const HelloLink = styled(Link)({
    marginRight: 10,
    fontFamily: 'roboto',
    textDecoration: 'none',
    color: "#bdbdbd",
    '&:hover': {
        color: '#b30000'
    }
})

const CarIcon = styled(DirectionsCarIcon)({
    fontSize: 40,
    marginRight: 10,
    color: "#bdbdbd"
})

const AppBarTypography = styled(Typography)({
    flex: 1,
    fontFamily: 'roboto',
    color: "#bdbdbd",
})

export default class Hello extends React.Component {
    render(){
        return(
            <React.Fragment>
                <div className='backgroundContainer'>
                    <AppBar style = {{background:'transparent'}}>
                        <Toolbar>
                            <CarIcon />
                            <AppBarTypography>WELCOME</AppBarTypography>
                            <HelloLink to="/registration">REGISTRATION</HelloLink>
                            <HelloLink to="/authorization">AUTHORIZATION</HelloLink>
                        </Toolbar>
                    </AppBar>
                    <div className="textContainer">
                        <Typography variant="h1">CAR RENTAL SYSTEM</Typography>
                        <Typography variant="h5" style ={{padding: 20}}>This web application is a training project for the development of a car booking system. Select one of the suggested options in the upper-left corner of the screen to continue.</Typography>
                    </div>

                    <div className="bottomTextContainer">
                        <Typography variant="body2">MADE WITH: </Typography>
                        <div style={{fontSize: 30}}>
                            <DiDotnet />
                            <DiReact />
                            <SiMaterialUi />
                        </div>
                        
                    </div>
                </div>
            </React.Fragment>
        );
    }
}