export interface Temporada{
    temp01llave?: number;
    temp01nombre?: string;
    temp01descripcion?: string;
    temp02llave?: number;
    temp02nombre?: string;
    temp03llave?: number;
    temp03nombre?: string;
    temp01minfecha?: Date;
    temp01maxfecha?: Date;
    temp01minmes?: number;
    temp01maxmes?: number;
    temp01periodo?: number;
    temp01activo?: number;

  }
  
  export interface Temporadas{
    temporada: Temporada[];
  }
  