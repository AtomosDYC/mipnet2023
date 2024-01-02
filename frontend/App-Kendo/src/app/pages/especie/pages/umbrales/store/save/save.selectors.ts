
import {createSelector} from '@ngrx/store';
import { getEspecieUmbralState , EspecieUmbralState} from '../index';

import { ListState } from './save.reducer';


export const getListState = createSelector(
  getEspecieUmbralState,
  (state: EspecieUmbralState) => state.list
)

export const getLoading = createSelector(
  getListState,
  (state: ListState) => state.loading
)

export const getSuccess = createSelector(
  getListState,
  (state: ListState) => state.success
)

export const getEspecieUmbrals = createSelector(
  getListState,
  (state: ListState) => state.especieumbrals
)

export const getEspecieUmbralbyid = createSelector(
    getListState,
    (state: ListState) =>  state.especieumbral
  )



