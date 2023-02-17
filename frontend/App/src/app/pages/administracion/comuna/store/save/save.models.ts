
import { Comuna } from '../../../../../models/backend/Comuna';
export { Comuna as ComunaResponse } from '../../../../../models/backend/Comuna';

export { Comunas as ComunasResponse } from '../../../../../models/backend/Comuna';

export type ComunaCreateRequest = Omit<Comuna, 'sist03llave' | 'sist03activo' | 'sist04nombre' >;

export type ComunaUpdateRequest = Omit<Comuna, 'sist03Activo' | 'sist04nombre'>;
