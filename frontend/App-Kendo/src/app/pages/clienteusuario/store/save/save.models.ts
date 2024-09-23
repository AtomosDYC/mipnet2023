
import { ClienteUsuario } from '../../../../models/backend/clienteusuario/index';

export { ClienteUsuario as ClienteUsuarioResponse } from '../../../../models/backend/clienteusuario';
export { ClienteUsuarios as ClienteUsuariosResponse } from '../../../../models/backend/clienteusuario';
export { MenuEstacion as MenuUsuarioResponse } from '../../../../models/backend/clienteestacion';

export interface dataClienteUsuarioActiva {
    data : ClienteUsuario[],
    groups: any,
    aggregates: any,
    total: number,
    errors: any
}



export type ClienteUsuarioRequest = Omit<ClienteUsuario, 
'cnt01llave' |
'cnt01activo' | 
'cnt01activobool' | 
'cnt02llave' |
'cnt02nombre' |
'rutformato' |
'per03llave' |
'per03nombre' |
'cnt03nombre' |
'per02titulo' |
'per01nombrerazon' |
'cnt08llave' |
'cnt08nombre' |
'cntultimoingreso'
>;

export type ClienteUsuarioRequestUpdate = Omit<ClienteUsuario, 
'cnt01activo' | 
'cnt01activobool' | 
'cnt02llave' |
'cnt02nombre' |
'rutformato' |
'per03llave' |
'per03nombre' |
'cnt03nombre' |
'per02titulo' |
'per01nombrerazon' |
'cnt08llave' |
'cnt08nombre' |
'cntultimoingreso'
>;

export type clienteusuariodesactivateRequest = Omit<ClienteUsuario,
    'cnt01nombre' |
    'cnt01activo' |
    'cnt01activobool' |
    'cnt02llave' |
    'cnt02nombre' |
    'per01llave' |
    'per01rut' |
    'rutformato' |
    'per03llave' |
    'per03nombre' |
    'cnt03llave' |
    'cnt03nombre' |
    'per02llave' |
    'per02titulo' |
    'per01nombrerazon' |
    'per01nombrefantasia' |
    'cnt08llave' |
    'cnt08nombre' |
    'cntultimoingreso'
>;


export type menuclienteusuarioRequest = Omit<ClienteUsuario,
    'cnt01nombre' |
    'cnt01activo' |
    'cnt01activobool' |
    'cnt02llave' |
    'cnt02nombre' |
    'per01llave' |
    'per01rut' |
    'rutformato' |
    'per03llave' |
    'per03nombre' |
    'cnt03llave' |
    'cnt03nombre' |
    'per02llave' |
    'per02titulo' |
    'per01nombrerazon' |
    'per01nombrefantasia' |
    'cnt08llave' |
    'cnt08nombre' |
    'cntultimoingreso'
>;

export type ClienteUsuarioActivaSource = dataClienteUsuarioActiva;
