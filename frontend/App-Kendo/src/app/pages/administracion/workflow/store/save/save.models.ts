
import { Workflow } from '../../../../../models/backend/workflow';
export { Workflow as WorkflowResponse } from '../../../../../models/backend/workflow';

export { Workflows as WorkflowsResponse } from '../../../../../models/backend/workflow';

export type WorkflowDatosgeneralesRequest = Omit<Workflow, 
'wkf01llave' | 
'wkf01directorio' |
'wkf01llavepadrenombre' | 
'wkf02llavepadre' |
'wkf02llavepadrenombre' |
'wkf03llavepadre' |
'wkf03llavepadrenombre' |
'wkf03nombre' | 
'wkf02llave' | 
'wkf02nombre' | 
'wkf01url' | 
'wkf01iconourl' | 
'wkf01visiblemenu' | 
'wkf01imagengrande' | 
'wkf01imagenpequena' | 
'wkf01estadoregistro'>;

export type WorkflowDatosgeneralesUpdateRequest = Omit<Workflow, 
'wkf01directorio' |
'wkf03nombre' | 
'wkf02llave' | 
'wkf02nombre' |
'wkf01llavepadrenombre' | 
'wkf02llavepadre' |
'wkf02llavepadrenombre' |
'wkf03llavepadre' |
'wkf03llavepadrenombre' |
'wkf01url' | 
'wkf01iconourl' | 
'wkf01visiblemenu' | 
'wkf01imagengrande' | 
'wkf01imagenpequena' | 
'wkf01estadoregistro'>;

export type WorkflowNodopadreRequest = Omit<Workflow, 
'wkf01nombre' | 
'wkf01descripcion' |
'wkf01llavepadrenombre' | 
'wkf02llavepadre' |
'wkf02llavepadrenombre' |
'wkf03llavepadre' |
'wkf03llavepadrenombre' | 
'wkf03llave' | 
'wkf03nombre' |
'wkf02llave' | 
'wkf02nombre' |
'wkf01esinicio' | 
'wkf01orden' | 
'wkf01prioridad' | 
'wkf01activo' | 
'wkf01directorio' | 
'wkf01url' | 
'wkf01iconourl' | 
'wkf01visiblemenu' | 
'wkf01imagengrande' | 
'wkf01imagenpequena' | 
'wkf01estadoregistro'
>;

export type WorkflowConfiguracionwebRequest = Omit<Workflow, 
'wkf01nombre' | 
'wkf01descripcion' |
'wkf01llavepadre' |
'wkf01llavepadrenombre' | 
'wkf02llavepadre' |
'wkf02llavepadrenombre' |
'wkf03llavepadre' |
'wkf03llavepadrenombre' | 
'wkf03llave' | 
'wkf03nombre' |
'wkf02llave' | 
'wkf02nombre' |
'wkf01esinicio' | 
'wkf01orden' | 
'wkf01prioridad' | 
'wkf01activo' | 
'wkf01directorio' |  
'wkf01imagengrande' | 
'wkf01imagenpequena' | 
'wkf01estadoregistro'
>;

export type WorkflowUpdateRequest = Omit<Workflow, 'wkf01activo'>;
