
import {createSelector} from '@ngrx/store';
import { getEspecieTemporadaState , EspecieTemporadaState} from '../index';

import { ListState } from './save.reducer';

export const getListState = createSelector(
  getEspecieTemporadaState,
  (state: EspecieTemporadaState) => state.list
)

export const getLoadingespecietemporada = createSelector(
  getListState,
  (state: ListState) => state.loading
)

export const getEspeciesTemporadaSuccess = createSelector(
  getListState,
  (state: ListState) => state.success
)


export const getEspeciesTemporadas = createSelector(
  getListState,
  (state: ListState) => state.especietemporadasource
)

export const getEspecieTemporadabyid = createSelector(
  getListState,
  (state: ListState) =>  state.especietemporada
)




