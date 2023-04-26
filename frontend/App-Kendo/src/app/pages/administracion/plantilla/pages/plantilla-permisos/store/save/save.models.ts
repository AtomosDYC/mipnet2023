
import { Plantillaflujo } from '../../../../../../../models/backend/plantillaflujo';
export { Plantillaflujo as PlantillaflujoResponse } from '../../../../../../../models/backend/plantillaflujo';

export { Plantillaflujos as PlantillasflujosResponse } from '../../../../../../../models/backend/plantillaflujo';

export type PlantillaflujoCreateRequest = Omit<Plantillaflujo, 'Prf04Llave' | 'prf03nombre' | 'wkf01nombre' | 'wkf01llavepadre'>;

export type PlantillaflujoUpdateRequest = Omit<Plantillaflujo, 'Prf04Llave' | 'prf03nombre' | 'wkf01nombre' | 'wkf01llavepadre'>;
