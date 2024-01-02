
import { EspecieUmbral } from '../../../../../../models/backend/especie';
export { EspecieUmbral as EspecieUmbralResponse } from '../../../../../../models/backend/especie';

export { EspecieUmbrals as EspecieUmbralsResponse } from '../../../../../../models/backend/especie';

export type EspecieUmbralRequest = Omit<EspecieUmbral, 
'esp05llave' |
'esp03llave' |
'esp03nombre' | 
'esp04llave' |
'esp04nombre' |
'esp09nombre' |
'esp05activo'
>;
