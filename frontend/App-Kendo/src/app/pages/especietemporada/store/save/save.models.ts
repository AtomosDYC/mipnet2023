
import { EspecieTemporada } from '../../../../models/backend/especietemporada';

export { EspecieTemporada } from '../../../../models/backend/especietemporada';

export { EspecieTemporada as EspecieTemporadaResponse } from '../../../../models/backend/especietemporada';

export { EspecieTemporadas as EspecieTemporadasResponse } from '../../../../models/backend/especietemporada';


export type EspecieTemporadaRequest = Omit<EspecieTemporada, 
'esp02llave' |
'esp03llave' |
'esp03nombre' |
'esp04llave' |
'temp02llave' |
'esp04nombre' |
'esp08llave' |
'esp08nombre' | 
'temp02nombre' |
'esp02activo' 
>;

export type EspecieTemporadaRequestUpdate = Omit<EspecieTemporada, 

'esp03llave' |
'esp03nombre' |
'esp04llave' |
'esp04nombre' |
'esp08llave' |
'esp08nombre' | 
'temp02llave' |
'temp02nombre' |
'esp02activo' 
>;

export type EspecieTemporadaRequestActivate = Omit<EspecieTemporada, 

'esp01llave' |
'esp03llave' |
'esp03nombre' |
'esp04llave' |
'esp04nombre' |
'esp08llave' |
'esp08nombre' |
'temp01llave' |
'temp02llave' |
'temp02nombre' |
'esp02iniciotemporada' |
'esp02terminotemporada' |
'esp02sag' |
'esp02mexico' 


>;


export interface dataMonitor {
    data : EspecieTemporada[],
    groups: any,
    aggregates: any,
    total: number,
    errors: any
}
