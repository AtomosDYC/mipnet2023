
import { MonitorAcceso } from '../../../../../../models/backend/monitor';
export { MonitorAcceso as MonitorAccesoResponse } from '../../../../../../models/backend/monitor';
export { MonitorAccesoRequest as MonitorAccesoRequest } from '../../../../../../models/backend/monitor';


export interface dataMonitorAcceso {
    data : MonitorAcceso[],
    groups: any,
    aggregates: any,
    total: number,
    errors: any
}






