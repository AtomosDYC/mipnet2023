import {createSelector} from '@ngrx/store';
import { getTemporadaState , TemporadaState} from '../index';

import { ListState } from './save.reducer';


export const getListState = createSelector(
  getTemporadaState,
  (state: TemporadaState) => state.list
)

export const getLoading = createSelector(
  getListState,
  (state: ListState) => state.loading
)

export const getTemporadas = createSelector(
  getListState,
  (state: ListState) => state.temporadas
)

export const getTemporadabyid = createSelector(
    getListState,
    (state: ListState) =>  state.temporada
  )



