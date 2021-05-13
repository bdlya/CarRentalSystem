import { AxiosError, AxiosResponse } from 'axios';
import { ApiResult } from '../../../types/ApiResult';
import Car from '../../../types/Car';
import { getUserToken } from '../../common/authorization/utils/authentication.header'

const axios = require('axios');

export const carService = {
    getFreeCars,
    filterCars
}

function getFreeCars(pointId: number) : Promise<ApiResult>{
    return axios.get('https://localhost:44337/search/point/cars', {
        params: {
            id: pointId

        },
        headers: {
            Authorization: 'Bearer ' + getUserToken(),
            ContentType: 'application/json;',
        },
    })
    .then((response: AxiosResponse<Car[]>) => {
        return{
            ok: true,
            data: response.data
        }
    })
    .catch((error: AxiosError) => {
        console.log(error)
        return{
            ok: false
        }
    });
}

function filterCars(pointId: number, brand: string, transmission: string, numberOfSeats: number): Promise<ApiResult>{
    return axios.get('https://localhost:44337/search/point/cars', {
        params: {
            id: pointId,
            Brand: brand,
            TransmissionType: transmission,
            NumberOfSeats: numberOfSeats
        },
        headers: {
            Authorization: 'Bearer ' + getUserToken(),
            ContentType: 'application/json;',
        },
    })
    .then((response: AxiosResponse<Car[]>) => {
        return{
            ok: true,
            data: response.data
        }
    })
    .catch((error: AxiosError) => {
        console.log(error)
        return{
            ok: false
        }
    });
}
