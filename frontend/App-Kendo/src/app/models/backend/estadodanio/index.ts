
export interface EstadoDanio{
  esp04llave: number;
  esp04nombre: string
  esp04descripcion: string;
  esp06llave: number;
  esp04activo: number;
  esp06nombre: string;

}

export interface EstadosDanios{
  estadosdanios: EstadoDanio[];
}
