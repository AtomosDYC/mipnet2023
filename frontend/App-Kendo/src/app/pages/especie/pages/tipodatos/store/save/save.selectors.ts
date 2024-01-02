
import {createSelector} from '@ngrx/store';
import { getDanioEspecieState , DanioEspecieState} from '../index';

import { ListState } from './save.reducer';


export const getListState = createSelector(
  getDanioEspecieState,
  (state: DanioEspecieState) => state.list
)

export const getLoading = createSelector(
  getListState,
  (state: ListState) => state.loading
)

export const getSuccess = createSelector(
  getListState,
  (state: ListState) => state.success
)

export const getDanioEspecies = createSelector(
  getListState,
  (state: ListState) => state.danioespecies
)

export const getDanioEspeciebyid = createSelector(
    getListState,
    (state: ListState) =>  state.danioespecie
  )



