import { AxiosError, AxiosResponse } from 'axios';
import { resolveProjectReferencePath } from 'typescript';
import { ApiResult } from '../../../../types/ApiResult';

const axios = require('axios');

export const registrationService = {
    register
}

function register(name: string, surname: string, login: string, password: string): Promise<ApiResult>{
    return axios.post('https://localhost:44337/registration',{
       Name: name,
       Surname: surname, 
       Login: login,
       Password: password
   })
   .then((response: AxiosResponse) => {
       if(response.status == 201)
       {
        return {
            ok: true
        }
       }
   })
   .catch((error: AxiosError) =>{
       const result: ApiResult ={
           ok: false,
           errors: {},
           type: '',
           message: ''
       }
       const data = error.response?.data;

       if(typeof data == 'string'){
           result.message = String(data.split(',')[2].split('=')[1]);
           result.type = "Form";
       }
       else{
        for (let prop in data) {
            if (data.hasOwnProperty(prop)) {
              result.errors[prop] = data[prop].toString();
            }
          }
       }
      return result;
   });

}