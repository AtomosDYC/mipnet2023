
import { Region } from '../../../../../models/backend/region';
export { Region as RegionResponse } from '../../../../../models/backend/region';

export { Regiones as RegionesResponse } from '../../../../../models/backend/region';

export type RegionCreateRequest = Omit<Region, 'sist04llave' | 'sist04activo'>;

export type RegionUpdateRequest = Omit<Region, 'sisT04Activo'>;
