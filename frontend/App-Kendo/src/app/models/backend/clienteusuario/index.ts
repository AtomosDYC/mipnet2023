
export interface ClienteUsuario{
    cnt01llave?: number;
    cnt01nombre?: string;
    cnt01activo?: number;
    cnt01activobool?: string;
    cnt02llave?: number;
    cnt02nombre?: string;

    per01llave?: number;
    per01rut?: number;
    rutformato?: string;
    per01nombrerazon?: string;
    per01nombrefantasia?: string;

    per03llave?: number;
    per03nombre?: string;
    cnt03llave?: number;
    cnt03nombre?: string;
    per02llave?: number;
    per02titulo?: string;
    
    cnt08llave?: number;
    cnt08nombre?: string;
    cntultimoingreso?: string;
  }
          
  export interface ClienteUsuarios{
    clienteusuario: ClienteUsuario[];
  }
    