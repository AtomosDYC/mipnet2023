
import { Rol } from '../../../../../models/backend/rol';
export { Rol as RolResponse } from '../../../../../models/backend/rol';

export { Roles as RolesResponse } from '../../../../../models/backend/rol';

export type RolCreateRequest = Omit<Rol, 'Id'>;
