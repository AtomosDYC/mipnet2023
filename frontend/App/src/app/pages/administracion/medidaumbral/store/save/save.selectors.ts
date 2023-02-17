
import {createSelector} from '@ngrx/store';
import { getMedidaUmbralState , MedidaUmbralState} from '../index';

import { ListState } from './save.reducer';


export const getListState = createSelector(
  getMedidaUmbralState,
  (state: MedidaUmbralState) => state.list
)

export const getLoading = createSelector(
  getListState,
  (state: ListState) => state.loading
)

export const getMedidaUmbrales = createSelector(
  getListState,
  (state: ListState) => state.medidaumbrales
)

export const getMedidaUmbralbyid = createSelector(
    getListState,
    (state: ListState) =>  state.medidaumbral
  )



