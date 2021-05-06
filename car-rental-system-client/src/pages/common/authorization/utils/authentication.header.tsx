import { authenticationService } from '../services/authentication.service';

export function authHeader(){
    const currentUser = authenticationService.getCurrentUserValue();
    if(currentUser && currentUser.token){
        return {Authorization: `Bearer ${currentUser.token}`};
    }
    else {
        return {};
    }
}