import { AppBar, Toolbar, Typography } from '@material-ui/core'
import { render } from '@testing-library/react'
import React from 'react'

export const Footer = (props: any) =>{
    return(
            <Toolbar>
                <Typography>
                    Footer
                </Typography>
            </Toolbar>
    )
}