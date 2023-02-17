
export interface TipoEspecie{
  esp08llave: number;
  esp08nombre: string;
  esp08descripcion: string;
  esp08activo: number;
}

export interface TipoEspecies{
  regiones: TipoEspecie[];
}
