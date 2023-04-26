
import { NivelPermiso } from '../../../../../models/backend/nivelpermiso';
export { NivelPermiso as NivelPermisoResponse } from '../../../../../models/backend/nivelpermiso';

export { NivelPermisos as NivelPermisosResponse } from '../../../../../models/backend/nivelpermiso';

export type NivelPermisoCreateRequest = Omit<NivelPermiso, 'wkf04llave' | 'wkf03nombre' | 'wkf05nombre' | 'wkf04activo'>;

export type NivelPermisoUpdateRequest = Omit<NivelPermiso, 'wkf04llave'>;
