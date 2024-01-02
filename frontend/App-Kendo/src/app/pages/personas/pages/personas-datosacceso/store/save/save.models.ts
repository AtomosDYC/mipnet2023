
import { PersonaAcceso } from '../../../../../../models/backend/persona';
export { PersonaAcceso as PersonaAccesoResponse } from '../../../../../../models/backend/persona';
export { PersonaAccesoRequest as PersonaAccesoRequest } from '../../../../../../models/backend/persona';


export interface dataPersonaAcceso {
    data : PersonaAcceso[],
    groups: any,
    aggregates: any,
    total: number,
    errors: any
}






