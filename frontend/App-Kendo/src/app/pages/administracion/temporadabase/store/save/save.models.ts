

import { TemporadaBase } from '../../../../../models/backend/temporadabase';
import { State as RequestState } from "@progress/kendo-data-query";

export { TemporadaBase as TemporadaBaseResponse } from '../../../../../models/backend/temporadabase';

export { TemporadaBases as TemporadaBasesResponse } from '../../../../../models/backend/temporadabase';

export type TemporadaBasesCreaterequest = Omit<TemporadaBase, 'temp02llave' | 'temp02activo'>;

export interface  TemporadabasedesactivateResponse {
    ids? : TemporadaBase[],
    filtro? : RequestState
}


export interface  TemporadabaseEliminarResponse {
    id? : string,
    filtro? : RequestState
}
