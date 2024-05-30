import * as fromList from './save/save.reducer';
import { SaveEffects } from './save/save.effects';
import { ActionReducerMap, createFeatureSelector } from '@ngrx/store';

export interface ClienteEstacioActivaState {
  list: fromList.ListState;
}

export const reducers : ActionReducerMap<ClienteEstacioActivaState> = {
  list: fromList.reducer
}

export const effects : any = [
  SaveEffects
]

export const getClienteEstacionActivaState = createFeatureSelector<ClienteEstacioActivaState>('clienteestacion');
