
import { NivelFlujo } from '../../../../../models/backend/nivelflujo';
export { NivelFlujo as NivelFlujoResponse } from '../../../../../models/backend/nivelflujo';

export { NivelFlujos as NivelFlujosResponse } from '../../../../../models/backend/nivelflujo';

export type NivelFlujoCreateRequest = Omit<NivelFlujo, 'wkf03llave' | 'wkf03activo' | 'wkf02nombre'>;

export type NivelFlujoUpdateRequest = Omit<NivelFlujo, 'wkf03Activo'>;
