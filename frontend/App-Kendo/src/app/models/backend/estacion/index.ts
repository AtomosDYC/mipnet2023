export interface Estacion {

    cnt08llave?: number;
    cnt01llave?: number;
    cnt07llave?: number;
    cnt07nombre?: string;
    cnt21llave?: number;
    cnt21nombre?: string;
    cnt08nombre?: string;
    cnt08llavePadre?: number;
    sist03llave?: number;
    sist03nombre?: string;
    sist04llave?: number;
    sist04nombre?: string;
    cnt08activo?: number;

}

export interface Estaciones{
    estaciones: Estacion[];
  }




