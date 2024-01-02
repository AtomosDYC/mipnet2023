
import { Temporada } from '../../../../models/backend/temporada';
export { Temporada as TemporadaResponse } from '../../../../models/backend/temporada';

export { Temporadas as TemporadasResponse } from '../../../../models/backend/temporada';

export type TemporadaCreaterequest = Omit<Temporada, 
'temp01llave' 
| 'temp01activo'
| 'temp02nombre'
| 'temp03nombre'
>;

