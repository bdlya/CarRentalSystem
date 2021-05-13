import { AxiosError, AxiosResponse } from 'axios';
import { ApiResult } from '../../../types/ApiResult';
import Point from '../../../types/Point';
import { getUserToken } from '../../common/authorization/utils/authentication.header'

const axios = require('axios');

export const pointService = {
    getAllPoints,
    filterPoints
}

function getAllPoints() : Promise<ApiResult>{
    return axios.get('https://localhost:44337/search/points', {
        headers: {
            Authorization: 'Bearer ' + getUserToken(),
            ContentType: 'application/json;',
        },
    })
    .then((response: AxiosResponse<Point[]>) => {
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

function filterPoints(country: string, city: string, date: Date) : Promise<ApiResult>{
    return axios.get('https://localhost:44337/search/points', {
        params:{
            Country: country,
            City: city,
            DateOfOrder: date
        },
        headers: {
            Authorization: 'Bearer ' + getUserToken(),
            ContentType: 'application/problem+json;charset=utf-8'
        }
        
    })
    .then((response: AxiosResponse<Point[]>) => {
        return{
            ok: true,
            data: response.data
        }
    })
    .catch((error: AxiosError) => {
        return{
            ok: false
        }
    });
}
