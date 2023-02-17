
export interface Zona{
  sist02llave?: number;
  sist02nombre?: string;
  sist02descripcion?: string;
  sist02estadoregistro?: string;
  sist02activo?: number;
}

export interface Zonas{
  zonas: Zona[];
}
