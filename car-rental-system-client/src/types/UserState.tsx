import React from 'react';
import { User } from './User';

export interface UserState{
    currentUser: User | null,
    isAdmin: boolean,
    isAdminOwner: boolean,
}