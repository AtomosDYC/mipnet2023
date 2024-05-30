
import {createSelector} from '@ngrx/store';
import { getClienteestacioncomunicacionState , ClienteestacioncomunicacionState} from '../index';

import { ListState } from './save.reducer';

export const getListState = createSelector(
  getClienteestacioncomunicacionState,
  (state: ClienteestacioncomunicacionState) => state.list
)

export const getLoadingComunicacion = createSelector(
  getListState,
  (state: ListState) => state.loading
)

export const getSuccess = createSelector(
  getListState,
  (state: ListState) => state.success
)

export const getClienteestacioncomunicaciones = createSelector(
  getListState,
  (state: ListState) => state.clienteestacioncomunicacionsource
)

export const getClienteestacioncomunicacionbyidselector = createSelector(
  getListState,
  (state: ListState) =>  state.clienteestacioncomunicacion
)




