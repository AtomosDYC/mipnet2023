
import {createSelector} from '@ngrx/store';
import { getRegionState , RegionState} from '../index';

import { ListState } from './save.reducer';


export const getListState = createSelector(
  getRegionState,
  (state: RegionState) => state.list
)

export const getLoading = createSelector(
  getListState,
  (state: ListState) => state.loading
)

export const getRegiones = createSelector(
  getListState,
  (state: ListState) => state.regiones
)

export const getRegionbyid = createSelector(
    getListState,
    (state: ListState) =>  state.region
  )



