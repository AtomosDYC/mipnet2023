
import {createSelector} from '@ngrx/store';
import { getTipoParametroState , TipoParametroState} from '../index';

import { ListState } from './save.reducer';


export const getListState = createSelector(
  getTipoParametroState,
  (state: TipoParametroState) => state.list
)

export const getLoading = createSelector(
  getListState,
  (state: ListState) => state.loading
)

export const getTipoParametros = createSelector(
  getListState,
  (state: ListState) => state.tipoparametros
)

export const getTipoParametrobyid = createSelector(
    getListState,
    (state: ListState) =>  state.tipoparametro
  )



