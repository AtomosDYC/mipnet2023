
export interface TipoFlujo{
  wkf02llave: number;
  wkf02nombre: string;
  wkf02descripcion: string;
  wkf02orden: number;
  wkf02activo: number;
}

export interface TipoFlujos{
  tiposflujos: TipoFlujo[];
}
