
import { TipoParametro } from '../../../../../models/backend/tipoparametro';
export { TipoParametro as TipoParametroResponse } from '../../../../../models/backend/tipoparametro';

export { TipoParametros as TipoParametrosResponse } from '../../../../../models/backend/tipoparametro';

export type TipoParametroCreateRequest = Omit<TipoParametro, 'wkf10llave' | 'wkf10activo'>;

export type TipoParametroUpdateRequest = Omit<TipoParametro, 'wkf10Activo'>;
