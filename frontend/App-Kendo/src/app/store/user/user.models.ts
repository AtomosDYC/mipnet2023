import { User } from '../../models/backend/user/index';
export { User as UserResponse } from '../../models/backend/user';

export interface EmailPasswordCredentials {
  email: string;
  password: string;
}

export interface UserRequest extends User {
  password: string;
}

export type UserCreateRequest = Omit<UserRequest, 
  'token' 
| 'id' 
| 'roleid'
| 'rolename'
| 'per01llave'
| 'per01nombre'
| 'prf03llave'
| 'prf03nombre' >;

