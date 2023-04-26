export interface Workflow{

        wkf01llave: number; 
        wkf01nombre: string; 
        wkf01descripcion: string; 
        wkf01llavepadre: number;
        wkf01llavepadrenombre: string;
        wkf02llavepadre: number;
        wkf02llavepadrenombre: string;
        wkf03llavepadre: number;
        wkf03llavepadrenombre: string;
        wkf02llave: number;
        wkf02nombre: string;
        wkf03llave: number;
        wkf03nombre: string;
        wkf01esinicio : number;
        wkf01orden : number;
        wkf01prioridad : number;
        wkf01activo : number;
        wkf01directorio: string;  
        wkf01url: string;  
        wkf01iconourl: string;  
        wkf01visiblemenu : number;
        wkf01imagengrande: string;  
        wkf01imagenpequena: string;  
        wkf01estadoregistro: string;  
  }
  
  export interface Workflows{
    workflow: Workflow[];
  }
  