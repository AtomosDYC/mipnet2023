
import {createSelector} from '@ngrx/store';
import { getMonitorespecieState , MonitorespecieState} from '../index';

import { ListState } from './save.reducer';

export const getListState = createSelector(
  getMonitorespecieState,
  (state: MonitorespecieState) => state.list
)

export const getLoadingMonitorEspecie = createSelector(
  getListState,
  (state: ListState) => state.loading
)

export const getSuccess = createSelector(
  getListState,
  (state: ListState) => state.success
)

export const getMonitorespecies = createSelector(
  getListState,
  (state: ListState) => state.monitorespeciesource
)

export const getMonitorespeciebyid = createSelector(
  getListState,
  (state: ListState) =>  state.monitorespecie
)


