import * as fromList from './save/save.reducer';
import { SaveEffects } from './save/save.effects';
import { ActionReducerMap, createFeatureSelector } from '@ngrx/store';

export interface ClienteestacioncomunicacionState {
  list: fromList.ListState;
}

export const reducers : ActionReducerMap<ClienteestacioncomunicacionState> = {
  list: fromList.reducer
}

export const effects : any = [
  SaveEffects
]

export const getClienteestacioncomunicacionState = createFeatureSelector<ClienteestacioncomunicacionState>('clienteestacioncomunicacion');
