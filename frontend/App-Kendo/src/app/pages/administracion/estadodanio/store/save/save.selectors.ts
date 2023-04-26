
import {createSelector} from '@ngrx/store';
import { getEstadoDanioState , EstadoDanioState} from '../index';

import { ListState } from './save.reducer';


export const getListState = createSelector(
  getEstadoDanioState,
  (state: EstadoDanioState) => state.list
)

export const getLoading = createSelector(
  getListState,
  (state: ListState) => state.loading
)

export const getEstadosDanios = createSelector(
  getListState,
  (state: ListState) => state.estadosdanios
)

export const getEstadoDaniobyid = createSelector(
    getListState,
    (state: ListState) =>  state.estadodanio
  )



