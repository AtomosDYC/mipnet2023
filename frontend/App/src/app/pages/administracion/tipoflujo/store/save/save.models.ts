
import { TipoFlujo } from '../../../../../models/backend/tipoflujo';
export { TipoFlujo as TipoFlujoResponse } from '../../../../../models/backend/tipoflujo';

export { TipoFlujos as TipoFlujosResponse } from '../../../../../models/backend/tipoflujo';

export type TipoFlujoCreateRequest = Omit<TipoFlujo, 'wkf02llave' | 'wkf02activo'>;

export type TipoFlujoUpdateRequest = Omit<TipoFlujo, 'wkf024Activo'>;
