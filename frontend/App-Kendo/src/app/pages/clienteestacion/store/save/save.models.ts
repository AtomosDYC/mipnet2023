
import { ClienteEstacion } from '../../../../models/backend/clienteestacion/index';
export { ClienteEstacion as ClienteEstacionResponse } from '../../../../models/backend/clienteestacion';
export { ClienteEstaciones as ClienteEstacionesResponse } from '../../../../models/backend/clienteestacion';


export interface dataClienteEstacionActiva {
    data : ClienteEstacion[],
    groups: any,
    aggregates: any,
    total: number,
    errors: any
}


export type ClienteEstacionRequest = Omit<ClienteEstacion, 
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

export type ClienteEstacionRequestUpdate = Omit<ClienteEstacion, 
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

export type clienteestaciondesactivateRequest = Omit<ClienteEstacion,
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

export type ClienteEstacionActivaSource = dataClienteEstacionActiva;
