
import { SegmentarTemporada } from '../../../../../models/backend/segmentartemporada';
export { SegmentarTemporada as SegmentarTemporadaResponse } from '../../../../../models/backend/segmentartemporada';

export { SegmentarTemporadas as SegmentarTemporadasResponse } from '../../../../../models/backend/segmentartemporada';

export type SegmentarTemporadasCreaterequest = Omit<SegmentarTemporada, 'temp03llave' | 'temp03activo'>;

