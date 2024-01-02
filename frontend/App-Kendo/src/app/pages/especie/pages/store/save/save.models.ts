
import { Especie } from '../../../../../models/backend/especie';
export { Especie as EspecieResponse } from '../../../../../models/backend/especie';

export { Especies as EspeciesResponse } from '../../../../../models/backend/especie';

export type EspecieDatosgeneralesRequest = Omit<Especie, 
'esp03llave' | 
'esp08nombre' |
'esp03ImgGrande' | 
'esp03ImgPequenia' |
'esp03activo' |
'esp03EstadoRegistro'>;

export type EspecieDatosgeneralesUpdateRequest = Omit<Especie, 
'esp08nombre' |
'esp03ImgGrande' | 
'esp03ImgPequenia' |
'esp03activo' |
'esp03EstadoRegistro'>;


