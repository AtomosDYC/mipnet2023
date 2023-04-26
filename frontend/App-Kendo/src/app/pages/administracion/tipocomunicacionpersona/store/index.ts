import * as fromList from './save/save.reducer';
import { SaveEffects } from './save/save.effects';
import { ActionReducerMap, createFeatureSelector } from '@ngrx/store';


export interface TipoComPersonaState {
  list: fromList.ListState;
}

export const reducers : ActionReducerMap<TipoComPersonaState> = {
  list: fromList.reducer
}

export const effects : any = [
  SaveEffects
]

export const getTipoComPersonaState = createFeatureSelector<TipoComPersonaState>('tipocompersona');




