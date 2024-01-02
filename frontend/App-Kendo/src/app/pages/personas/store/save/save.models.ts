
import { Persona } from '../../../../models/backend/persona';
export { Persona as PersonaResponse } from '../../../../models/backend/persona';
export { Personas as PersonasResponse } from '../../../../models/backend/persona';


export interface dataPersona {
    data : Persona[],
    groups: any,
    aggregates: any,
    total: number,
    errors: any
}


export type PersonaSource = dataPersona;

export type PersonaRequest = Omit<Persona, 
'per01llave' | 
'per03nombre' |
'per08nombre' | 
'per02nombre' |
'per01activo' >;

export type PersonaRequestUpdate = Omit<Persona, 
'per03nombre' |
'per08nombre' |
'per02nombre' |
'per01anioingreso' |
'per01activo' >;




