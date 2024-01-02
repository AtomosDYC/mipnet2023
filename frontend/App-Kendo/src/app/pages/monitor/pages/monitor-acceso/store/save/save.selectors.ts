
import {createSelector} from '@ngrx/store';
import { getMonitorAccesoState , MonitorAccesoState} from '../index';

import { ListState } from './save.reducer';

export const getListState = createSelector(
  getMonitorAccesoState,
  (state: MonitorAccesoState) => state.list
)

export const getLoadingAcceso = createSelector(
  getListState,
  (state: ListState) => state.loading
)


export const GetMonitorAccesobyid = createSelector(
  getListState,
  (state: ListState) =>  state.monitoracceso
)


