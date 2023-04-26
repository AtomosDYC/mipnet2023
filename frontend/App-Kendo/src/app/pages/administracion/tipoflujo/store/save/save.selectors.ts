
import {createSelector} from '@ngrx/store';
import { getTipoFlujoState , TipoFlujoState} from '../index';

import { ListState } from './save.reducer';


export const getListState = createSelector(
  getTipoFlujoState,
  (state: TipoFlujoState) => state.list
)

export const getLoading = createSelector(
  getListState,
  (state: ListState) => state.loading
)

export const getTipoFlujos = createSelector(
  getListState,
  (state: ListState) => state.tipoflujos
)

export const getTipoFlujobyid = createSelector(
    getListState,
    (state: ListState) =>  state.tipoflujo
  )



