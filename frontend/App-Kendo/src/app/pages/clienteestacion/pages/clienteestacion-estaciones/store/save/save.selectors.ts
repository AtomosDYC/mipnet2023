
import {createSelector} from '@ngrx/store';
import { getEstacionState , EstacionState} from '../index';

import { ListState } from './save.reducer';

export const getListState = createSelector(
  getEstacionState,
  (state: EstacionState) => state.list
)

export const getLoadingEstacion = createSelector(
  getListState,
  (state: ListState) => state.loading
)

export const getSuccess = createSelector(
  getListState,
  (state: ListState) => state.success
)

export const getEstaciones = createSelector(
  getListState,
  (state: ListState) => state.Estacionsource
)

export const getEstacionbyidselector = createSelector(
  getListState,
  (state: ListState) =>  state.Estacion
)
