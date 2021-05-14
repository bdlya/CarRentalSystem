import { AxiosError, AxiosResponse } from 'axios';
import { ApiResult } from '../../../types/ApiResult';
import Car from '../../../types/Car';
import AdditionalWork from '../../../types/AdditionalWork';
import { getUserToken } from '../../common/authorization/utils/authentication.header'

const axios = require('axios');

export const bookingService = {
    getCar,
    getAdditionalWorks
}

function getCar(id: number) : Promise<ApiResult>{
    return axios.get('https://localhost:44337/booking/car', {
        params: {
            carId: id
        },
        headers: {
            Authorization: 'Bearer ' + getUserToken(),
            ContentType: 'application/json;',
        }
    })
    .then((response: AxiosResponse<Car>) => {
        return{
            ok: true,
            singleData: response.data
        }
    })
    .catch((error: AxiosError) => {
        console.log(error)
        return{
            ok: false
        }
    });
}

function getAdditionalWorks() : Promise<ApiResult> {
    return axios.get('https://localhost:44337/booking/additionalWorks', {
        headers: {
            Authorization: 'Bearer ' + getUserToken(),
            ContentType: 'application/json;',
        },
    })
    .then((response: AxiosResponse<AdditionalWork[]>) => {
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