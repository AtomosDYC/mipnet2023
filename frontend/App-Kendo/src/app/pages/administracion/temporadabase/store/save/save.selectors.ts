
import {createSelector} from '@ngrx/store';
import { getTemporadaBaseState , TemporadaBaseState} from '../index';

import { ListState } from './save.reducer';

export const getListState = createSelector(
  getTemporadaBaseState,
  (state: TemporadaBaseState) => state.list
)

export const getLoading = createSelector(
  getListState,
  (state: ListState) => state.loading
)

export const getTemporadaBases = createSelector(
  getListState,
  (state: ListState) => state.temporadabasesource
)

export const getTemporadaBasebyid = createSelector(
  getListState,
  (state: ListState) =>  state.temporadabase
)

export const getSuccess = createSelector(
  getListState,
  (state: ListState) => state.success
)


