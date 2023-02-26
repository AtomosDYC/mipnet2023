
import {createSelector} from '@ngrx/store';
import { getNivelPermisoState , NivelPermisoState} from '../index';

import { ListState } from './save.reducer';


export const getListState = createSelector(
  getNivelPermisoState,
  (state: NivelPermisoState) => state.list
)

export const getLoading = createSelector(
  getListState,
  (state: ListState) => state.loading
)

export const getNivelPermisos = createSelector(
  getListState,
  (state: ListState) => state.nivelpermisos
)

export const getNivelPermisobyid = createSelector(
    getListState,
    (state: ListState) =>  state.nivelpermiso
  )



