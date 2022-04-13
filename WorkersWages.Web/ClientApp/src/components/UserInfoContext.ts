import { createContext } from 'react';

export class UserInfo {
    displayName?: string | undefined;
    email?: string | undefined;
    reloadDataTime?: number | undefined;
}
export const UserInfoContext = createContext<UserInfo | undefined>(undefined);