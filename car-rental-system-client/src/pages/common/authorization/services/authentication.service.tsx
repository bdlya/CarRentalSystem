import { AxiosResponse } from 'axios';
import { BehaviorSubject } from 'rxjs';
import { User } from '../../../../types/User';

const currentUserSubject : BehaviorSubject<User | null> = new BehaviorSubject(JSON.parse(localStorage.getItem('currentUser') || 'null'));
const axios = require('axios');

export const authenticationService = {
    login,
    logout,
    getCurrentUserValue,
}

function login(login: string, password: string, push: (path: string) => void){
   axios.post('https://localhost:44337/authentication',{
       Login: login,
       Password: password
   })
   .then((response: AxiosResponse<User>) => {
       const user: User = response.data;
       localStorage.setItem('currentUser', JSON.stringify(user));
       currentUserSubject.next(user);
       push("/home")
   })
   .catch((error: string) =>{
       console.log(error)
   });
}

function logout(){
    localStorage.removeItem('currentUser');
    currentUserSubject.next(null);
}

function getCurrentUserValue(){
    return currentUserSubject.value;
}
