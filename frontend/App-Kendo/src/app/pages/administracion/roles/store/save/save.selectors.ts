
import {createSelector} from '@ngrx/store';
import { getRolState , RolState} from '../index';

import { ListState } from './save.reducer';


export const getListState = createSelector(
  getRolState,
  (state: RolState) => state.list
)

export const getLoading = createSelector(
  getListState,
  (state: ListState) => state.loading
)

export const getRoles = createSelector(
  getListState,
  (state: ListState) => state.roles
)



