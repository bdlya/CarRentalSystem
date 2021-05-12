import { AxiosError, AxiosResponse } from 'axios';
import { BehaviorSubject } from 'rxjs';
import { User } from '../../../../types/User';
import { ApiResult } from '../../../../types/ApiResult';

const currentUserSubject : BehaviorSubject<User | null> = new BehaviorSubject(JSON.parse(localStorage.getItem('currentUser') || 'null'));
const axios = require('axios');

export const authenticationService = {
    login,
    logout,
    getCurrentUserValue,
}

function login(login: string, password: string): Promise<ApiResult>{
   return axios.post('https://localhost:44337/authentication',{
       Login: login,
       Password: password
   })
   .then((response: AxiosResponse<User>) => {
       const user: User = response.data;
       localStorage.setItem('currentUser', JSON.stringify(user));
       currentUserSubject.next(user);
       return {
           ok: true
       }
   })
   .catch((error: AxiosError) =>{
       const result: ApiResult ={
           ok: false,
           errors: {},
           type: '',
       }
       const data = error.response?.data;

       if(error.response?.status === 403){
           result.type = "Form"
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

function logout(){
    localStorage.removeItem('currentUser');
    currentUserSubject.next(null);
}

function getCurrentUserValue(){
    return currentUserSubject.value;
}
