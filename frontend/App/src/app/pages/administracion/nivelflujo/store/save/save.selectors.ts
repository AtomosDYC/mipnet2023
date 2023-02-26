
import {createSelector} from '@ngrx/store';
import { getNivelFlujoState , NivelFlujoState} from '../index';

import { ListState } from './save.reducer';


export const getListState = createSelector(
  getNivelFlujoState,
  (state: NivelFlujoState) => state.list
)

export const getLoading = createSelector(
  getListState,
  (state: ListState) => state.loading
)

export const getNivelFlujos = createSelector(
  getListState,
  (state: ListState) => state.nivelflujos
)

export const getNivelFlujobyid = createSelector(
    getListState,
    (state: ListState) =>  state.nivelflujo
  )



