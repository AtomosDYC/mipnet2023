
import { Saludo } from '../../../../../models/backend/saludo';
export { Saludo as SaludoResponse } from '../../../../../models/backend/saludo';

export { Saludos as SaludosResponse } from '../../../../../models/backend/saludo';

export type SaludoCreateRequest = Omit<Saludo, 'per02llave' | 'per02activo'>;

export type SaludoUpdateRequest = Omit<Saludo, 'per02Activo'>;
