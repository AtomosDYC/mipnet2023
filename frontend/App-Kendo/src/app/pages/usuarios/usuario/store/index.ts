import * as fromList from './save/save.reducer';
import { SaveEffects } from './save/save.effects';
import { ActionReducerMap, createFeatureSelector } from '@ngrx/store';


export interface UsuarioregistroState {
  list: fromList.ListState;
}

export const reducers : ActionReducerMap<UsuarioregistroState> = {
  list: fromList.reducer
}

export const effects : any = [
  SaveEffects
]

export const getUsuarioregistroState = createFeatureSelector<UsuarioregistroState>('usuarioregistro');
