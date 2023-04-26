
import { TipoDocumento } from '../../../../../models/backend/tipodocumento';
export { TipoDocumento as TipoDocumentoResponse } from '../../../../../models/backend/tipodocumento';

export { TipoDocumentos as TipoDocumentosResponse } from '../../../../../models/backend/tipodocumento';

export type TipoDocumentoCreateRequest = Omit<TipoDocumento, 'per08llave' | 'per08activo'>;

export type TipoDocumentoUpdateRequest = Omit<TipoDocumento, 'per08activo'>;
