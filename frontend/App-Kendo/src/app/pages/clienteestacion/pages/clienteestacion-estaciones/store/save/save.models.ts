
import { Estacion } from '../../../../../../models/backend/estacion';
export { Estacion as EstacionResponse } from '../../../../../../models/backend/estacion';
export { Estaciones as EstacionesResponse } from '../../../../../../models/backend/estacion';


export interface dataEstacion {
    data : Estacion[],
    groups: any,
    aggregates: any,
    total: number,
    errors: any
}

export type EstacionSource = dataEstacion;

export type EstacionRequest = Omit<Estacion, 
  'cnt07nombre' |
  'cnt21nombre' |
  'sist03nombre' |
  'sist04llave' |
  'sist04nombre'
>;

export type EstacionbyidRequest = Omit<Estacion, 

  'cnt07llave' |
  'cnt07nombre' |
  'cnt21llave' |
  'cnt21nombre' |
  'cnt08nombre' |
  'cnt08llavePadre' | 
  'sist03llave' |
  'sist03nombre' |
  'sist04llave' |
  'sist04nombre' |
  'cnt08activo' 

>;


