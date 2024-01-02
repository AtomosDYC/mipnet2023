
import { MonitorSincronizacion } from '../../../../../../models/backend/monitor';
export { MonitorSincronizacion as MonitorSincronizacionResponse } from '../../../../../../models/backend/monitor';
export { MonitorSincronizaciones as MonitorSincronizacionesResponse } from '../../../../../../models/backend/monitor';

export interface dataMonitorSincronizacion {
    data : MonitorSincronizacion[],
    groups: any,
    aggregates: any,
    total: number,
    errors: any
}


export type dataMonitorSincronizacionSource = dataMonitorSincronizacion;

export type MonitorSincronizacionRequest = Omit<dataMonitorSincronizacion, 
    'userid'
>;