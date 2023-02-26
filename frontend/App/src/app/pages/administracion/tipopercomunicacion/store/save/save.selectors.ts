
import {createSelector} from '@ngrx/store';
import { getTipoPerComunicacionState , TipoPerComunicacionState} from '../index';

import { ListState } from './save.reducer';


export const getListState = createSelector(
  getTipoPerComunicacionState,
  (state: TipoPerComunicacionState) => state.list
)

export const getLoading = createSelector(
  getListState,
  (state: ListState) => state.loading
)

export const getTipoPerComunicaciones = createSelector(
  getListState,
  (state: ListState) => state.tipopercomunicaciones
)

export const getTipoPerComunicacionbyid = createSelector(
    getListState,
    (state: ListState) =>  state.tipopercomunicacion
  )



