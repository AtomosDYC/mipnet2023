import {Action} from '@ngrx/store';
import { DefaultUserCreateRequest, DefaultUserResponse, DefaultUsersResponse } from './save.models';


export enum Types {
  READ = '[DefaultUser] Read',
  READ_SUCCESS = '[DefaultUser] Read:Success',
  READ_ERROR = '[DefaultUser] Read:Error',

  GET_DEFAULTUSER = '[GET] Get_defaultuser',
  GET_DEFAULTUSER_SUCCESS = '[GET] Get_defaultuser:Success',
  GET_DEFAULTUSER_ERROR = '[GET] Get_defaultuser:Error',

  CREATE_DEFAULTUSER = '[CREATE] Create_DefaultUser',
  CREATE_DEFAULTUSER_SUCCESS = '[CREATE] Create_DefaultUser:Success',
  CREATE_DEFAULTUSER_ERROR = '[CREATE] Create_DefaultUser:Error',


  UPDATE_DEFAULTUSER = '[UPDATE] DefaultUser',
  UPDATE_DEFAULTUSER_SUCCESS = '[UPDATE] Game Success',
  UPDATE_DEFAULTUSER_ERROR = '[UPDATE] Game Error',


}

export class Read implements Action {
  readonly type = Types.READ;
  constructor(){}
}

export class ReadSuccess implements Action {
  readonly type = Types.READ_SUCCESS;
  constructor(public defaultuser: DefaultUserResponse){}
}

export class ReadError implements Action {
  readonly type = Types.READ_ERROR;
  constructor(public error: string){}
}

export class Getbyid implements Action {
  readonly type = Types.GET_DEFAULTUSER;
  constructor(public id: string){}
}

export class GetbyidSuccess implements Action {
  readonly type = Types.GET_DEFAULTUSER_SUCCESS;
  constructor(public defaultuser: DefaultUserResponse){}
}

export class GetbyidError implements Action {
  readonly type = Types.GET_DEFAULTUSER_ERROR;
  constructor(public error: string){}
}

export class Create implements Action {
  readonly type = Types.CREATE_DEFAULTUSER;
  constructor(public defaultuser: DefaultUserCreateRequest){}
}

export class CreateSuccess implements Action {
  readonly type = Types.CREATE_DEFAULTUSER_SUCCESS;
  constructor(public defaultuser: DefaultUserResponse){}
}

export class CreateError implements Action {
  readonly type = Types.CREATE_DEFAULTUSER_ERROR;
  constructor(public error: string) {}
}

export class Update implements Action {
  readonly type = Types.UPDATE_DEFAULTUSER;
  constructor(public defaultuser: DefaultUserResponse){}
}

export class UpdateSuccess implements Action {
  readonly type = Types.UPDATE_DEFAULTUSER_SUCCESS;
  constructor(public defaultuser: DefaultUserResponse){}
}

export class UpdateError implements Action {
  readonly type = Types.UPDATE_DEFAULTUSER_ERROR;
  constructor(public error: string) {}
}


export type All =
  Read | ReadSuccess | ReadError
| Getbyid | GetbyidSuccess | GetbyidError
| Create | CreateSuccess | CreateError
| Update | UpdateSuccess | UpdateError

