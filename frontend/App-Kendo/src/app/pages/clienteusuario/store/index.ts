import * as fromList from './save/save.reducer';
import { SaveEffects } from './save/save.effects';
import { ActionReducerMap, createFeatureSelector } from '@ngrx/store';

export interface ClienteUsuarioActivaState {
  list: fromList.ListState;
}

export const reducers : ActionReducerMap<ClienteUsuarioActivaState> = {
  list: fromList.reducer
}

export const effects : any = [
  SaveEffects
]

export const getClienteUsuarioActivaState = createFeatureSelector<ClienteUsuarioActivaState>('clienteusuario');
