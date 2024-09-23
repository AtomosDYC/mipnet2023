
import { Clienteestacioncontacto } from '../../../../../../models/backend/clienteestacion';
export { Clienteestacioncontacto as ClienteestacioncontactoResponse } from '../../../../../../models/backend/clienteestacion';
export { Clienteestacioncontactos as ClienteestacioncontactosResponse } from '../../../../../../models/backend/clienteestacion';

export  { PersonaBuscarRut as PersonaBuscarRutRequest } from '../../../../../../models/backend/persona';
export  { Persona as PersonaResponse } from '../../../../../../models/backend/persona';

export interface dataClienteestacioncontacto {
    data : Clienteestacioncontacto[],
    groups: any,
    aggregates: any,
    total: number,
    errors: any
}


export type ClienteestacioncontactoSource = dataClienteestacioncontacto;

export type ClienteestacioncontactoRequest = Omit<Clienteestacioncontacto, 
  'cnt05nombre' |
  'per02titulo' |
  'per03nombre' |
  'per08nombre' |
  'sist03nombre' |
  'sist04nombre' |
  'createby'
>;



export type ClienteestacioncontactobyidRequest = Omit<Clienteestacioncontacto, 

'cnt05llave' |
'cnt05nombre' |
'per01llave' |
'per02llave' |
'per02titulo' |
'per03llave' |
'per03nombre' |
'per08llave' |
'per08nombre' |
'per01rut' |
'per01nombrerazon' |
'per01activo' |
'per05direccion' |
'sist03llave' |
'sist03nombre' |
'sist04llave' |
'sist04nombre' |
'per05casilla' |
'per05tienecasilla' |
'per05codigopostal' |
'per05email' |
'per05telefono1' |
'per05telefono2' |
'per05celular1' |
'per05celular2' |
'per05fax' |
'per05sitioWeb' |
'createby'
>;


