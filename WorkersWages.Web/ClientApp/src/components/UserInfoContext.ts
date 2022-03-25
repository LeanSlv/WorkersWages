import { createContext } from 'react';
import { AuthorizationUserInfoResponse } from '../services/WorkersWagesWebLocalApiClient';

export class UserInfo extends AuthorizationUserInfoResponse {}
export const UserInfoContext = createContext<UserInfo | undefined>(undefined);