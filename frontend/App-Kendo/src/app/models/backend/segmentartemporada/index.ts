export interface SegmentarTemporada{
  temp03llave?: number;
  temp03nombre?: string;
  temp03descripcion?: string;
  temp03numeromeses?: number;
  temp03numerosegmentostotal?: number;
  temp03activo?: number;
  }
  
  export interface SegmentarTemporadas{
    segmentartemporada: SegmentarTemporada[];
  }
  