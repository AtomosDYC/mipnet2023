
import {createSelector} from '@ngrx/store';
import { getTipoDocumentoState , TipoDocumentoState} from '../index';

import { ListState } from './save.reducer';


export const getListState = createSelector(
  getTipoDocumentoState,
  (state: TipoDocumentoState) => state.list
)

export const getLoading = createSelector(
  getListState,
  (state: ListState) => state.loading
)

export const getTipoDocumentos = createSelector(
  getListState,
  (state: ListState) => state.tipodocumentos
)

export const getTipoDocumentobyid = createSelector(
    getListState,
    (state: ListState) =>  state.tipodocumento
  )



