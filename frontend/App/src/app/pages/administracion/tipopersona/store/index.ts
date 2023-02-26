import * as fromList from './save/save.reducer';
import { SaveEffects } from './save/save.effects';
import { ActionReducerMap, createFeatureSelector } from '@ngrx/store';


export interface TipoPersonaState {
  list: fromList.ListState;
}

export const reducers : ActionReducerMap<TipoPersonaState> = {
  list: fromList.reducer
}

export const effects : any = [
  SaveEffects
]

export const getTipoPersonaState = createFeatureSelector<TipoPersonaState>('tipopersona');




