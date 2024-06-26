import * as fromList from './save/save.reducer';
import { SaveEffects } from './save/save.effects';
import { ActionReducerMap, createFeatureSelector } from '@ngrx/store';

export interface ClienteestacioncontactoState {
  list: fromList.ListState;
}

export const reducers : ActionReducerMap<ClienteestacioncontactoState> = {
  list: fromList.reducer
}

export const effects : any = [
  SaveEffects
]

export const getClienteestacioncontactoState = createFeatureSelector<ClienteestacioncontactoState>('clienteestacioncontacto');
