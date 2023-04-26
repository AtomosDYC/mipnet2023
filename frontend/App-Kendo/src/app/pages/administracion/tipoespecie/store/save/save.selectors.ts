
import {createSelector} from '@ngrx/store';
import { getTipoEspecieState , TipoEspecieState} from '../index';

import { ListState } from './save.reducer';


export const getListState = createSelector(
  getTipoEspecieState,
  (state: TipoEspecieState) => state.list
)

export const getLoading = createSelector(
  getListState,
  (state: ListState) => state.loading
)

export const getTipoEspecies = createSelector(
  getListState,
  (state: ListState) => state.tipoespecies
)

export const getTipoEspeciebyid = createSelector(
    getListState,
    (state: ListState) =>  state.tipoespecie
  )



