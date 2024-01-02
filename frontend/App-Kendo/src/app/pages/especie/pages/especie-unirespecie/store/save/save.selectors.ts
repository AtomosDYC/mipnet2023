
import {createSelector} from '@ngrx/store';
import { getUnirEspecieState , UnirEspecieState} from '../index';

import { ListState } from './save.reducer';


export const getListState = createSelector(
  getUnirEspecieState,
  (state: UnirEspecieState) => state.list
)

export const getLoading = createSelector(
  getListState,
  (state: ListState) => state.loading
)

export const getSuccess = createSelector(
  getListState,
  (state: ListState) => state.success
)

export const getUnirEspecies = createSelector(
  getListState,
  (state: ListState) => state.unirespecies
)

export const getUnirEspeciebyid = createSelector(
    getListState,
    (state: ListState) =>  state.unirespecie
  )



