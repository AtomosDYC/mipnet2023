
import {createSelector} from '@ngrx/store';
import { getComunaState , ComunaState} from '../index';

import { ListState } from './save.reducer';


export const getListState = createSelector(
  getComunaState,
  (state: ComunaState) => state.list
)

export const getLoading = createSelector(
  getListState,
  (state: ListState) => state.loading
)

export const getComunas = createSelector(
  getListState,
  (state: ListState) => state.comunas
)

export const getComunabyid = createSelector(
    getListState,
    (state: ListState) =>  state.comuna
  )



