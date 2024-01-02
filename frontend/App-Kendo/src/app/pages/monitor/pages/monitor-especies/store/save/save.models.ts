
import { Monitorespecie } from '../../../../../../models/backend/monitor';
export { Monitorespecie as MonitorespecieResponse } from '../../../../../../models/backend/monitor';
export { Monitorespecies as MonitorespeciesResponse } from '../../../../../../models/backend/monitor';

export interface dataMonitorespecie {
    data : Monitorespecie[],
    groups: any,
    aggregates: any,
    total: number,
    errors: any
}


export type MonitorespecieSource = dataMonitorespecie;

export type MonitorespecieRequest = Omit<Monitorespecie, 
    'esp01llave' |
    'temp01llave' |
    'esp03llave' |
    'esp03nombre' |
    'esp04llave' |
    'esp04nombre' |
    'esp08llave' |
    'esp08nombre' |
    'temp02llave' |
    'temp02nombre'
>;