
import { TipoComPersona } from '../../../../../models/backend/tipocompersona';
export { TipoComPersona as TipoComPersonaResponse } from '../../../../../models/backend/tipocompersona';

export { TipoComPersonas as TipoComPersonasResponse } from '../../../../../models/backend/tipocompersona';

export type TipoComPersonaCreateRequest = Omit<TipoComPersona, 'per04llave' | 'per04activo'>;

export type TipoComPersonaUpdateRequest = Omit<TipoComPersona, 'per04Activo'>;
