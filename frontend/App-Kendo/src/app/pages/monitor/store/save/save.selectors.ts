
import {createSelector} from '@ngrx/store';
import { getMonitorState , MonitorState} from '../index';

import { ListState } from './save.reducer';

export const getListState = createSelector(
  getMonitorState,
  (state: MonitorState) => state.list
)

export const getLoading = createSelector(
  getListState,
  (state: ListState) => state.loading
)

export const getMonitores = createSelector(
  getListState,
  (state: ListState) => state.monitorsource
)

export const getMonitorbyid = createSelector(
  getListState,
  (state: ListState) =>  state.monitor
)

export const getSuccess = createSelector(
  getListState,
  (state: ListState) => state.success
)


export const getMonitorbyrut = createSelector(
  getListState,
  (state: ListState) =>  state.monitor
)


