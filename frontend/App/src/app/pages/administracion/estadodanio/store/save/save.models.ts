
import { EstadoDanio } from '../../../../../models/backend/estadodanio';
export { EstadoDanio as EstadoDanioResponse } from '../../../../../models/backend/estadodanio';

export { EstadosDanios as EstadosDaniosResponse } from '../../../../../models/backend/estadodanio';

export type EstadoDanioCreateRequest = Omit<EstadoDanio, 'esp04llave' | 'esp04activo' | 'esp06nombre'>;

export type EstadoDanioUpdateRequest = Omit<EstadoDanio, 'esp06Activo' | 'esp06nombre'>;
