
import { Clienteestacioncomunicacion } from '../../../../../../models/backend/clienteestacion';
export { Clienteestacioncomunicacion as ClienteestacioncomunicacionResponse } from '../../../../../../models/backend/clienteestacion';
export { Clienteestacioncomunicaciones as ClienteestacioncomunicacionesResponse } from '../../../../../../models/backend/clienteestacion';

export interface dataClienteestacioncomunicacion {
    data : Clienteestacioncomunicacion[],
    groups: any,
    aggregates: any,
    total: number,
    errors: any
}


export type ClienteestacioncomunicacionSource = dataClienteestacioncomunicacion;

export type ClienteestacioncomunicacionRequest = Omit<Clienteestacioncomunicacion, 
'cnt10nombre' |
'sist03nombre' |
'sist04nombre' |
'cnt06activo' |
 'createby'>;

export type ClienteestacioncomunicacionbyidRequest = Omit<Clienteestacioncomunicacion, 
'cnt10llave' |
'cnt10nombre' |
'cnt06direccion' |
'sist03llave' |
'sist03nombre' |
'sist04llave' |
'sist04nombre' |
'cnt06casilla' |
'cnt06tienecasilla' |
'cnt06codigopostal' |
'cnt06email' |
'cnt06tipomail' |
'cnt06telefono1' |
'cnt06telefono2' |
'cnt06celular1' |
'cnt06celular2' |
'cnt06fax' |
'cnt06sitioweb' |
'cnt06activo' |
'createby' >;


