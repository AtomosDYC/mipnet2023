
import { usuarioregistro } from '../../../../../models/backend/usuario';
export { usuarioregistro as UsuarioResponse } from '../../../../../models/backend/usuario';

export { usuarioregistro as UsuariosResponse } from '../../../../../models/backend/usuario';

export type UsuarioRegistroCreateRequest = Omit<usuarioregistro, 
'userid' |
'roleid' |
'rolename' |
'per01llave' |
'per01nombre' |
'email' |
'emailconfirmed' |
'tipodocumentoid' |
'tipodocumentonombre' |
'tipopersonaid' |
'tipopersonanombre' |
'plantillaid' |
'plantillanombre' |
'saludoid' |
'saludonombre'

>;


export type UsuarioRegistroUpdateRequest = Omit<usuarioregistro, 
'rolename' | 
'name' | 
'password' | 
'emailconfirmed' |
'per01llave' |
'tipodocumentonombre' |
'tipopersonanombre' |
'plantillanombre' |
'saludonombre'

>;

export type UsuarioRegistroCreateResponse = Omit<usuarioregistro,
'name' 
>;
