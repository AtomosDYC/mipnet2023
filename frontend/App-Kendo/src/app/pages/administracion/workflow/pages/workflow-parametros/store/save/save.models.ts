
import { WorkflowParametro } from '../../../../../../../models/backend/workflowparametro';
export { WorkflowParametro as WorkflowParametroResponse } from '../../../../../../../models/backend/workflowparametro';

export { WorkflowParametros as WorkflowParametrosResponse } from '../../../../../../../models/backend/workflowparametro';

export type WorkflowParametroRequest = Omit<WorkflowParametro, 
'wkf09llave' |
'wkf10nombre' |
'wkf09activo'
>;
