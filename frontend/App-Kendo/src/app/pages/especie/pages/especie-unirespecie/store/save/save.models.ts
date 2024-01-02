
import { UnirEspecie } from '../../../../../../models/backend/especie';
export { UnirEspecie as UnirEspecieResponse } from '../../../../../../models/backend/especie';

export { UnirEspecies as UnirEspeciesResponse } from '../../../../../../models/backend/especie';

export type UnirEspecieRequest = Omit<UnirEspecie, 
'esp03nombre' |
'esp03nombreunion'
>;
