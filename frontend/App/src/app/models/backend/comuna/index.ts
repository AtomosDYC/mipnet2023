
export interface Comuna{
  sist03llave?: number;
  sist03nombre?: string;
  sist03descripcion?: string;
  sist03capital?: number;
  sist03activo?: number;
  sist04llave?: number;
  sist04nombre?: string;
}

export interface Comunas{
  regiones: Comuna[];
}
