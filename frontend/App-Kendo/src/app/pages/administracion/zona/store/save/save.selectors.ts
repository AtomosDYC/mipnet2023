
import {createSelector} from '@ngrx/store';
import { getZonaState , ZonaState} from '../index';

import { ListState } from './save.reducer';


export const getListState = createSelector(
  getZonaState,
  (state: ZonaState) => state.list
)

export const getLoading = createSelector(
  getListState,
  (state: ListState) => state.loading
)

export const getZonas = createSelector(
  getListState,
  (state: ListState) => state.zonas
)

export const getZonabyid = createSelector(
    getListState,
    (state: ListState) =>  state.zona
  )



