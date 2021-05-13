import { authenticationService } from '../services/authentication.service';

export function getUserToken(){
    const currentUser = authenticationService.getCurrentUserValue();
    if(currentUser && currentUser.token){
        return currentUser.token
    }
    else {
        return {};
    }
}