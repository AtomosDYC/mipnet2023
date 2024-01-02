import { ILoader } from "./loader.models";
import * as fromActions from './loader.action';

export const initialState: ILoader = {
  success: false
}

export function reducer(state: ILoader = initialState, action: fromActions.All | any) {

    switch(action.type) {
        //init
        case fromActions.Types.LOAD: {
          return {...state, success: false}
        }
  
        case fromActions.Types.LOAD_SUCCESS: {
          return {...state, success: true}
        }
  
        case fromActions.Types.LOAD_ERROR: {
          return  {...state, success: false}
        }

        case fromActions.Types.ON_SUCCESS: {
          return  {...state, success: true}
        }

        case fromActions.Types.CAMBIAR_ESTADO: {
          return  {...state, success: false}
        }

        default: {
          return state;
        }

        
    }
}
