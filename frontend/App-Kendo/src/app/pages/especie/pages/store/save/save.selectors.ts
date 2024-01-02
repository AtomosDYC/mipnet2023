
import {createSelector} from '@ngrx/store';
import { getEspecieState , EspecieState} from '../index';

import { ListState } from './save.reducer';

export const getListState = createSelector(
  getEspecieState,
  (state: EspecieState) => state.list
)

export const getLoading = createSelector(
  getListState,
  (state: ListState) => state.loading
)

export const getEspecies = createSelector(
  getListState,
  (state: ListState) => state.especies
)

export const getEspeciebyid = createSelector(
  getListState,
  (state: ListState) =>  state.especie
)


