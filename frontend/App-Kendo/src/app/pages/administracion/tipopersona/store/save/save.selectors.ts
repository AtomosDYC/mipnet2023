
import {createSelector} from '@ngrx/store';
import { getTipoPersonaState , TipoPersonaState} from '../index';

import { ListState } from './save.reducer';


export const getListState = createSelector(
  getTipoPersonaState,
  (state: TipoPersonaState) => state.list
)

export const getLoading = createSelector(
  getListState,
  (state: ListState) => state.loading
)

export const getTipoPersonas = createSelector(
  getListState,
  (state: ListState) => state.tipopersonas
)

export const getTipoPersonabyid = createSelector(
    getListState,
    (state: ListState) =>  state.tipopersona
  )



