
import {createSelector} from '@ngrx/store';
import { getTipoComPersonaState , TipoComPersonaState} from '../index';

import { ListState } from './save.reducer';


export const getListState = createSelector(
  getTipoComPersonaState,
  (state: TipoComPersonaState) => state.list
)

export const getLoading = createSelector(
  getListState,
  (state: ListState) => state.loading
)

export const getTipoComPersonas = createSelector(
  getListState,
  (state: ListState) => state.tipocompersonas
)

export const getTipoComPersonabyid = createSelector(
    getListState,
    (state: ListState) =>  state.tipocompersona
  )



