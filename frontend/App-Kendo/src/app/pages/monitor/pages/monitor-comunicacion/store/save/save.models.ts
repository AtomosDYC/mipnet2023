
import { Monitorcomunicacion } from '../../../../../../models/backend/monitor';
export { Monitorcomunicacion as MonitorcomunicacionResponse } from '../../../../../../models/backend/monitor';
export { Monitorcomunicaciones as MonitorcomunicacionesResponse } from '../../../../../../models/backend/monitor';

export interface dataMonitorcomunicacion {
    data : Monitorcomunicacion[],
    groups: any,
    aggregates: any,
    total: number,
    errors: any
}


export type MonitorcomunicacionSource = dataMonitorcomunicacion;

export type MonitorcomunicacionRequest = Omit<Monitorcomunicacion, 
'per04nombre'  |
'per03nombre'  |
'sist03nombre' |
'sist04nombre' >;

export type MonitorcomunicacionbyidRequest = Omit<Monitorcomunicacion, 
'per04nombre' |
'per03nombre' |
'per05Direccion' |
'sist03llave' |
'sist03nombre' |
'sist04llave' |
'sist04nombre' |
'per05Casilla' |
'per05TieneCasilla' |
'per05CodigoPostal' |
'per05Email' |
'per05Telefono1' |
'per05Telefono2' |
'per05Celular1' |
'per05Celular2' |
'per05Fax' |
'per05SitioWeb'>;


