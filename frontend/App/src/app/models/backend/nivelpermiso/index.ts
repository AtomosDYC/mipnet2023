export interface NivelPermiso{
  wkf04llave: number;
  wkf03llave: number;
  wkf03nombre: string;
  wkf05llave: number;
  wkf05nombre: string;
  wkf04activo: number;
}

export interface NivelPermisos{
  nivelpermisos: NivelPermiso[];
}
