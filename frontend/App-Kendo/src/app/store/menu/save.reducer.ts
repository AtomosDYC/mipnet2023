import { MenuResponse } from "./save.models";
import * as fromActions from './save.actions';

export interface MenuState {
  menus: MenuResponse[] | null;
  menu: MenuResponse | null;
  loading: boolean | null;
  error: string | null;
  expand: boolean | null;
}

export const initialState: MenuState = {
  menus: null,
  menu: null,
  loading: null,
  error: null,
  expand: true,
}

export function reducer(state: MenuState = initialState, action: fromActions.All | any) {

    switch(action.type) {
        //init
        case fromActions.Types.MENU: {
          return {...state, loading: true, error: null}
        }
  
        case fromActions.Types.MENU_SUCCESS: {
          return {...state, loading: false, menus: action.menus}
        }
  
        case fromActions.Types.MENU_ERROR: {
          return  {...state, loading: false, error: action.error}
        }

        case fromActions.Types.MENU_EXPANDED: {
          return {...state,}
        }

        case fromActions.Types.MENU_EXPANDED_SUCCESS: {
          return {...state, expand: action.expand}
        }


        default: {
          return state;
        }

        
    }
}
