import {Action} from '@ngrx/store';
import { UsuarioResponse } from './save.models';


export enum Types {
  READ = '[COMUNA] Read',
  READ_SUCCESS = '[COMUNA] Read:Success',
  READ_ERROR = '[COMUNA] Read:Error',

}

export class Read implements Action {
  readonly type = Types.READ;
  constructor(){}
}

export class ReadSuccess implements Action {
  readonly type = Types.READ_SUCCESS;
  constructor(public usuarios: UsuarioResponse[]){}
}

export class ReadError implements Action {
  readonly type = Types.READ_ERROR;
  constructor(public error: string){}
}



export type All =
  Read | ReadSuccess | ReadError

