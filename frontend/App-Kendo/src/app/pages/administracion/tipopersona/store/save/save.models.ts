
import { TipoPersona } from '../../../../../models/backend/tipopersona';
export { TipoPersona as TipoPersonaResponse } from '../../../../../models/backend/tipopersona';

export { TipoPersonas as TipoPersonasResponse } from '../../../../../models/backend/tipopersona';

export type TipoPersonaCreateRequest = Omit<TipoPersona, 'per03llave' | 'per03activo'>;

export type TipoPersonaUpdateRequest = Omit<TipoPersona, 'per03activo'>;
