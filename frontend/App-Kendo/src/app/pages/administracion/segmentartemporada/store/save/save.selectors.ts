
import {createSelector} from '@ngrx/store';
import { getSegmentarTemporadaState , SegmentarTemporadaState} from '../index';

import { ListState } from './save.reducer';


export const getListState = createSelector(
  getSegmentarTemporadaState,
  (state: SegmentarTemporadaState) => state.list
)

export const getLoading = createSelector(
  getListState,
  (state: ListState) => state.loading
)

export const getSegmentarTemporadas = createSelector(
  getListState,
  (state: ListState) => state.segmentartemporadas
)

export const getSegmentarTemporadabyid = createSelector(
    getListState,
    (state: ListState) =>  state.segmentartemporada
  )



