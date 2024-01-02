
import { Comuna } from '../../../../../models/backend/comuna/index';

export { Comuna as ComunaResponse } from '../../../../../models/backend/comuna';

export { Comunas as ComunasResponse } from '../../../../../models/backend/comuna';

export type ComunaCreateRequest = Omit<Comuna, 'sist03llave' | 'sist03activo' | 'sist04nombre' >;

export type ComunaUpdateRequest = Omit<Comuna, 'sist03Activo' | 'sist04nombre'>;
