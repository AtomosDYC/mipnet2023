
import {createSelector} from '@ngrx/store';
import { getTipoPermisoState , TipoPermisoState} from '../index';

import { ListState } from './save.reducer';


export const getListState = createSelector(
  getTipoPermisoState,
  (state: TipoPermisoState) => state.list
)

export const getLoading = createSelector(
  getListState,
  (state: ListState) => state.loading
)

export const getTipoPermisos = createSelector(
  getListState,
  (state: ListState) => state.tipopermisos
)

export const getTipoPermisobyid = createSelector(
    getListState,
    (state: ListState) =>  state.tipopermiso
  )



