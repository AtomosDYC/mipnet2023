
import { TemporadaBase } from '../../../../../models/backend/temporadabase';
export { TemporadaBase as TemporadaBaseResponse } from '../../../../../models/backend/temporadabase';

export { TemporadaBases as TemporadaBasesResponse } from '../../../../../models/backend/temporadabase';

export type TemporadaBasesCreaterequest = Omit<TemporadaBase, 'temp02llave' | 'temp02activo'>;

