
import { DanioEspecie } from '../../../../../../models/backend/especie';
export { DanioEspecie as DanioEspecieResponse } from '../../../../../../models/backend/especie';

export { DanioEspecies as DanioEspeciesResponse } from '../../../../../../models/backend/especie';

export type DanioEspecieRequest = Omit<DanioEspecie, 
'esp01llave' |
'esp03nombre' |
'esp04nombre' |
'esp01activo' 
>;
