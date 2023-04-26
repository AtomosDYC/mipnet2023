
import {createSelector} from '@ngrx/store';
import { getDefaultUserState , DefaultUserState} from '../index';

import { ListState } from './save.reducer';


export const getListState = createSelector(
  getDefaultUserState,
  (state: DefaultUserState) => state.list
)

export const getLoading = createSelector(
  getListState,
  (state: ListState) => state.loading
)

export const getDefaultUsers = createSelector(
  getListState,
  (state: ListState) => state.defaultuser
)

export const getDefaultUserbyid = createSelector(
    getListState,
    (state: ListState) =>  state.defaultuser
  )



