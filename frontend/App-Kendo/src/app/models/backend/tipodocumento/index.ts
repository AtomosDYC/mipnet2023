export interface TipoDocumento{
    per08llave: number;
    per08nombre: string;
    per08descripcion: string;
    per08activo: number;
  }
  
  export interface TipoDocumentos{
    tipodocumento: TipoDocumento[];
  }