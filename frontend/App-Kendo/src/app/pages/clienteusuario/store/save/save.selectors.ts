
import {createSelector} from '@ngrx/store';
import {  getClienteUsuarioActivaState, ClienteUsuarioActivaState,  } from '../index';

import { ListState } from './save.reducer';

export const getListState = createSelector(
  getClienteUsuarioActivaState,
  (state: ClienteUsuarioActivaState) => state.list
)

export const getLoading = createSelector(
  getListState,
  (state: ListState) => state.loading
)

export const getClienteUsuarioActiva = createSelector(
  getListState,
  (state: ListState) => state.clienteusuarioactivasource
)

export const getClienteUsuarioInactiva = createSelector(
  getListState,
  (state: ListState) => state.clienteusuarioinactivasource
)

export const getSuccess = createSelector(
  getListState,
  (state: ListState) => state.success
)


export const getClienteUsuariobyid = createSelector(
  getListState,
  (state: ListState) =>  state.clienteusuarioactiva
)

export const getClienteUsuariobyrut = createSelector(
  getListState,
  (state: ListState) =>  state.clienteusuarioactiva
)

export const getmenuClienteUsuario_selector = createSelector(
  getListState,
  (state: ListState) =>  state.MenuUsuario
)





