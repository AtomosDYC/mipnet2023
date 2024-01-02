
import { Monitor } from '../../../../models/backend/monitor';

export { Monitor as MonitorResponse } from '../../../../models/backend/monitor';

export { Monitores as MonitoresResponse } from '../../../../models/backend/monitor';

export  { PersonaBuscarRut as PersonaBuscarRutRequest } from '../../../../models/backend/persona';
export  { Persona as PersonaResponse } from '../../../../models/backend/persona';


export type MonitorRequest = Omit<Monitor, 
'mnt01llave' | 
'mnt04nombre' | 
'mnt01Iniciolabores' |
'mnt01activo' |
'per03nombre' |
'per08nombre' |
'per02nombre' |
'per01nombrefantasia' |
'per01giro' |
'per01cargo' |
'per01fechanacimiento' |
'per01anioingreso' |
'per01activo'
>;

export type MonitorRequestUpdate = Omit<Monitor, 
'mnt04nombre' | 
'mnt01Iniciolabores' |
'mnt01activo' |
'per03nombre' |
'per08nombre' |
'per02nombre' |
'per01nombrefantasia' |
'per01giro' |
'per01cargo' |
'per01fechanacimiento' |
'per01anioingreso' |
'per01activo'
>;

export type monitordesactivateRequest = Omit<Monitor, 
'per01llave' |
    'mnt04llave' |
    'mnt04nombre' |
    'mnt01Cargo' |
    'mnt01Iniciolabores' |
    'mnt01activo' |

    'per01rut' |
    'per03llave' |
    'per03nombre' |
    'per08llave' |
    'per08nombre' |
    'per02llave' |
    'per02nombre' |
    'per01nombrerazon' |
    'per01nombrefantasia' |
    'per01giro' |
    'per01cargo' |
    'per01fechanacimiento' |
    'per01anioingreso' |
    'per01activo' 
>;

export interface dataMonitor {
    data : Monitor[],
    groups: any,
    aggregates: any,
    total: number,
    errors: any
}
