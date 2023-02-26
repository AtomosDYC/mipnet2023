import * as fromList from './save/save.reducer';
import { SaveEffects } from './save/save.effects';
import { ActionReducerMap, createFeatureSelector } from '@ngrx/store';


export interface UsuarioState {
  list: fromList.ListState;
}

export const reducers : ActionReducerMap<UsuarioState> = {
  list: fromList.reducer
}

export const effects : any = [
  SaveEffects
]

export const getUsuarioState = createFeatureSelector<UsuarioState>('usuario');
