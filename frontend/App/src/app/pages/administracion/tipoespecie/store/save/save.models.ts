
import { TipoEspecie } from '../../../../../models/backend/tipoespecie';
export { TipoEspecie as TipoEspecieResponse } from '../../../../../models/backend/tipoespecie';

export { TipoEspecies as TipoEspeciesResponse } from '../../../../../models/backend/tipoespecie';

export type TipoEspecieCreateRequest = Omit<TipoEspecie, 'esp08llave' | 'esp08activo'>;

export type TipoEspecieUpdateRequest = Omit<TipoEspecie, 'esp08Activo'>;
