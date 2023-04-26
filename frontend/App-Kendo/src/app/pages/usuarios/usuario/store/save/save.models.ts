
import { usuarioregistro } from '../../../../../models/backend/usuario';
export { usuarioregistro as UsuarioResponse } from '../../../../../models/backend/usuario';

export { usuarioregistro as UsuariosResponse } from '../../../../../models/backend/usuario';

export type UsuarioRegistroCreateRequest = Omit<usuarioregistro, 
'userid' |
'roleid' |
'rolename' |
'per01llave' |
'per01nombre' |
'prf03llave' |
'prf03nombre'
>;

export type UsuarioRegistroCreateResponse = Omit<usuarioregistro,
'name' 
>;
