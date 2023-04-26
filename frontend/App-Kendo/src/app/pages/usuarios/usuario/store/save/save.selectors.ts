
import {createSelector} from '@ngrx/store';
import { getUsuarioregistroState , UsuarioregistroState} from '../index';

import { ListState } from './save.reducer';


export const getListState = createSelector(
  getUsuarioregistroState,
  (state: UsuarioregistroState) => state.list
)

export const getLoading = createSelector(
  getListState,
  (state: ListState) => state.loading
)

export const getUsuarioregistros = createSelector(
  getListState,
  (state: ListState) => state.usuarioregistros
)

export const getUsuarioregistrobyid = createSelector(
    getListState,
    (state: ListState) =>  state.usuarioregistro
  )



