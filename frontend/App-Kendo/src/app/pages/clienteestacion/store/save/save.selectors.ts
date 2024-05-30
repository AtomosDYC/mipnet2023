
import {createSelector} from '@ngrx/store';
import { getClienteEstacionActivaState , ClienteEstacioActivaState} from '../index';

import { ListState } from './save.reducer';

export const getListState = createSelector(
  getClienteEstacionActivaState,
  (state: ClienteEstacioActivaState) => state.list
)

export const getLoading = createSelector(
  getListState,
  (state: ListState) => state.loading
)

export const getClienteEstacionActiva = createSelector(
  getListState,
  (state: ListState) => state.clienteestacionactivasource
)

export const getClienteEstacionbyid = createSelector(
  getListState,
  (state: ListState) =>  state.clienteestacion
)

export const getSuccess = createSelector(
  getListState,
  (state: ListState) => state.success
)


export const getClienteEstacionbyrut = createSelector(
  getListState,
  (state: ListState) =>  state.clienteestacion
)





