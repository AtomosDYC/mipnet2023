
import {createSelector} from '@ngrx/store';
import { getSaludoState , SaludoState} from '../index';

import { ListState } from './save.reducer';


export const getListState = createSelector(
  getSaludoState,
  (state: SaludoState) => state.list
)

export const getLoading = createSelector(
  getListState,
  (state: ListState) => state.loading
)

export const getSaludos = createSelector(
  getListState,
  (state: ListState) => state.saludos
)

export const getSaludobyid = createSelector(
    getListState,
    (state: ListState) =>  state.saludo
  )



