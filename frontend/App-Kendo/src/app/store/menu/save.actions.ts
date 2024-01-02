
import { Action } from '@ngrx/store';

import { MenuResponse } from './save.models';


export enum Types {
  MENU = '[Menu] Menu: Load',
  MENU_SUCCESS = '[Menu] Menu: Success',
  MENU_ERROR = '[Menu] Menu: Error',
  MENU_EXPANDED = '[Menu] Menu: expanded',
  MENU_EXPANDED_SUCCESS = '[Menu] Menu: expanded Success',


}

//INIT -> EL USUARIO ESTA EN SESION?
export class Menu implements Action{
  readonly type = Types.MENU;
  constructor(){}
}

export class MenuSuccess implements Action{
  readonly type = Types.MENU_SUCCESS;
  constructor(public menus: MenuResponse[] | null){}
}

export class MenuError implements Action{
  readonly type = Types.MENU_ERROR;
  constructor(public error: string){}
}

export class MenuExpanded implements Action{
  readonly type = Types.MENU_EXPANDED;
  constructor(public expand:boolean){}
}

export class MenuExpandedSuccess implements Action{
  readonly type = Types.MENU_EXPANDED_SUCCESS;
  constructor(public expand:boolean){}
}

export type All =
        Menu | MenuSuccess | MenuError
        | MenuExpanded | MenuExpandedSuccess;
