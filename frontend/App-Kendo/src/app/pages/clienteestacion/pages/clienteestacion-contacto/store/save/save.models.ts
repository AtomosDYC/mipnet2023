
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
'cnt10llave'
>;


