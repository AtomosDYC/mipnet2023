
import {createSelector} from '@ngrx/store';
import { getUsuarioState , UsuarioState} from '../index';

import { ListState } from './save.reducer';


export const getListState = createSelector(
  getUsuarioState,
  (state: UsuarioState) => state.list
)

export const getLoading = createSelector(
  getListState,
  (state: ListState) => state.loading
)

export const getUsuarios = createSelector(
  getListState,
  (state: ListState) => state.usuarios
)

export const getUsuariobyid = createSelector(
    getListState,
    (state: ListState) =>  state.usuario
  )



