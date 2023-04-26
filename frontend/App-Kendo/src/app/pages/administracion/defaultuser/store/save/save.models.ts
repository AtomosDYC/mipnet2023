
import { DefaultUser } from '../../../../../models/backend/defaultuser';
export { DefaultUser as DefaultUserResponse } from '../../../../../models/backend/defaultuser';

export { DefaultUsers as DefaultUsersResponse } from '../../../../../models/backend/defaultuser';

export type DefaultUserCreateRequest = Omit<DefaultUser, 'per09llave'>;
