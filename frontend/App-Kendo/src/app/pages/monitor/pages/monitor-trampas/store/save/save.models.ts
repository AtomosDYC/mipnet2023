
import { MonitorTrampa } from '../../../../../../models/backend/monitor';
import { AsignarTrampa } from '../../../../../../models/backend/monitor/index';
export { MonitorTrampa as MonitortrampaResponse } from '../../../../../../models/backend/monitor';
export { MonitorTrampas as MonitortrampasResponse } from '../../../../../../models/backend/monitor';
export { AsignarTrampa as MonitortrampaRequest } from '../../../../../../models/backend/monitor/index';

export interface dataMonitortrampa {
    data : MonitorTrampa[],
    groups: any,
    aggregates: any,
    total: number,
    errors: any
}

export interface dataMonitorbuscartrampa {
    data : MonitorTrampa[],
    groups: any,
    aggregates: any,
    total: number,
    errors: any
}


export type MonitortrampaSource = dataMonitortrampa;