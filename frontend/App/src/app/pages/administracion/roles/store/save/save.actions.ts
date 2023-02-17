import {Action} from '@ngrx/store';
import { RolResponse, RolesResponse } from './save.models';


export enum Types {
  READ = '[ROLES] Read',
  READ_SUCCESS = '[ROLES] Read:Success',
  READ_ERROR = '[ROLES] Read:Error',

}

export class Read implements Action {
  readonly type = Types.READ;
  constructor(){}
}

export class ReadSuccess implements Action {
  readonly type = Types.READ_SUCCESS;
  constructor(public roles: RolResponse[]){}
}

export class ReadError implements Action {
  readonly type = Types.READ_ERROR;
  constructor(public error: string){}
}


export type All =
  Read | ReadSuccess | ReadError

