import { authenticationService } from '../services/starting/authentication.service';

export function authHeader(){
    const currentUser = authenticationService.getCurrentUserValue();
    if(currentUser && currentUser.token){
        return {Authorization: `Bearer ${currentUser.token}`};
    }
    else {
        return {};
    }
}