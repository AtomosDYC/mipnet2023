
import { Personacomunicacion } from '../../../../../../models/backend/persona';
export { Personacomunicacion as PersonacomunicacionResponse } from '../../../../../../models/backend/persona';
export { Personacomunicaciones as PersonacomunicacionesResponse } from '../../../../../../models/backend/persona';

export interface dataPersonacomunicacion {
    data : Personacomunicacion[],
    groups: any,
    aggregates: any,
    total: number,
    errors: any
}


export type PersonacomunicacionSource = dataPersonacomunicacion;

export type PersonacomunicacionRequest = Omit<Personacomunicacion, 
'per04nombre'  |
'per03nombre'  |
'sist03nombre' |
'sist04nombre' >;

export type PersonacomunicacionbyidRequest = Omit<Personacomunicacion, 
'per04nombre' |
'per03nombre' |
'per05Direccion' |
'sist03llave' |
'sist03nombre' |
'sist04llave' |
'sist04nombre' |
'per0Casilla' |
'per05TieneCasilla' |
'per05CodigoPostal' |
'per05Email' |
'per05Telefono1' |
'per05Telefono2' |
'per05Celular1' |
'per05Celular2' |
'per05Fax' |
'per05SitioWeb'>;


