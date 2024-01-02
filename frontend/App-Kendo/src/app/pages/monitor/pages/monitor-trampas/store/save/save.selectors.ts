
import {createSelector} from '@ngrx/store';
import { getMonitortrampaState , MonitortrampaState} from '../index';

import { ListState } from './save.reducer';

export const getListState = createSelector(
  getMonitortrampaState,
  (state: MonitortrampaState) => state.list
)

export const getLoadingMonitorTrampa = createSelector(
  getListState,
  (state: ListState) => state.loading
)

export const getSuccess = createSelector(
  getListState,
  (state: ListState) => state.success
)

export const getMonitortrampas = createSelector(
  getListState,
  (state: ListState) => state.monitortrampasource
)

export const getMonitorbuscartrampas = createSelector(
  getListState,
  (state: ListState) => state.monitorbuscartrampasource
)

export const getMonitortrampabyid = createSelector(
  getListState,
  (state: ListState) =>  state.monitortrampa
)



