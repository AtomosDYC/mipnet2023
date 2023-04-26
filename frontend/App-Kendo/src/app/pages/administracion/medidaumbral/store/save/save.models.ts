
import { MedidaUmbral } from '../../../../../models/backend/medidaumbral';
export { MedidaUmbral as MedidaUmbralResponse } from '../../../../../models/backend/medidaumbral';

export { MedidaUmbrales as MedidaUmbralesResponse } from '../../../../../models/backend/medidaumbral';

export type MedidaUmbralCreateRequest = Omit<MedidaUmbral, 'esp06llave' | 'esp06activo'>;

export type MedidaUmbralUpdateRequest = Omit<MedidaUmbral, 'esp06Activo'>;
