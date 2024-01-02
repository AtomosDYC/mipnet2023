
import {createSelector} from '@ngrx/store';
import { getMonitorsincronizacionState , MonitorsincronizacionState } from '../index';

import { ListState } from './save.reducer';

export const getListState = createSelector(
  getMonitorsincronizacionState,
  ( state: MonitorsincronizacionState ) => state.list
)

export const getLoadingMonitorSincronizacion = createSelector(
  getListState,
  (state: ListState) => state.loading
)

export const getSuccess = createSelector(
  getListState,
  (state: ListState) => state.success
)

export const getMonitorsincronicaciones = createSelector(
  getListState,
  (state: ListState) => state.monitorsincronizacionsource
)

export const getMonitorsincronizacionbyid = createSelector(
  getListState,
  (state: ListState) =>  state.monitorsincronizacion
)


