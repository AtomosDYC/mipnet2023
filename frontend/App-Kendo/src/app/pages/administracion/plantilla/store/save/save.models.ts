
import { Plantilla } from '../../../../../models/backend/plantilla';
export { Plantilla as PlantillaResponse } from '../../../../../models/backend/plantilla';

export { Plantillas as PlantillasResponse } from '../../../../../models/backend/plantilla';

export type PlantillaCreateRequest = Omit<Plantilla, 'prf03llave' | 'prf03activo'>;

export type PlantillaUpdateRequest = Omit<Plantilla, 'prf03Activo'>;
