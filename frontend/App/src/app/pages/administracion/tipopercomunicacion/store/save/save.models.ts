
import { TipoPerComunicacion } from '../../../../../models/backend/tipopercomunicacion';
export { TipoPerComunicacion as TipoPerComunicacionResponse } from '../../../../../models/backend/tipopercomunicacion';

export { TipoPerComunicaciones as TipoPerComunicacionesResponse } from '../../../../../models/backend/tipopercomunicacion';

export type TipoPerComunicacionCreateRequest = Omit<TipoPerComunicacion, 'per04nombre' | 'per03nombre'>;
