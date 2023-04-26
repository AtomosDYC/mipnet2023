
import { Zona } from '../../../../../models/backend/Zona';
export { Zona as ZonaResponse } from '../../../../../models/backend/Zona';

export { Zonas as ZonasResponse } from '../../../../../models/backend/Zona';

export type ZonaCreateRequest = Omit<Zona, 'sist02llave' | 'sist02activo' >;

export type ZonaUpdateRequest = Omit<Zona, 'sist02Activo'>;
