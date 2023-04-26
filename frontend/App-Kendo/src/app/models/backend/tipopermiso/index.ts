export interface TipoPermiso
{
  wkf05llave: number;
  wkf05nombre: string;
  wkf05descripcion: string;
  wkf05sigla: string;
  wkf05activo: number;
}

export interface TipoPermisos{
  tipopermisos: TipoPermiso[];
}
