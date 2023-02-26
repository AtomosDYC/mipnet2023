
import { TipoPermiso } from '../../../../../models/backend/tipopermiso';
export { TipoPermiso as TipoPermisoResponse } from '../../../../../models/backend/tipopermiso';

export { TipoPermisos as TipoPermisosResponse } from '../../../../../models/backend/tipopermiso';

export type TipoPermisoCreateRequest = Omit<TipoPermiso, 'wkf02llave' | 'wkf02activo'>;

export type TipoPermisoUpdateRequest = Omit<TipoPermiso, 'wkf024Activo'>;
