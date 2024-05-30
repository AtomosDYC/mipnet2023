
export interface ClienteEstacion{
  cnt01llave?: number;
  cnt01nombre?: string;
  cnt01activo?: number;
  cnt01activobool?: string;
  cnt02llave?: number;
  cnt02nombre?: string;
  per01llave?: number;
  per01rut?: number;
  rutformato?: string;
  per03llave?: number;
  per03nombre?: string;
  cnt03llave?: number;
  cnt03nombre?: string;
  per02llave?: number;
  per02titulo?: string;
  per01nombrerazon?: string;
  per01nombrefantasia?: string;
  cnt08llave?: number;
  cnt08nombre?: string;
  cntultimoingreso?: string;
}
        
export interface ClienteEstaciones{
  clienteestaciones: ClienteEstacion[];
}
  

export interface Clienteestacioncomunicacion{

  cnt06llave : number;
  cnt01llave : number;
  cnt10llave : number;
  cnt10nombre : string;
  cnt06direccion : string;
  sist03llave : number;
  sist03nombre : string;
  sist04llave : number;
  sist04nombre : string;
  cnt06casilla : string;
  cnt06tienecasilla : number;
  cnt06codigopostal : string;
  cnt06email : string;
  cnt06tipomail : number;
  cnt06telefono1 : string;
  cnt06telefono2 : string;
  cnt06celular1 : string;
  cnt06celular2 : string;
  cnt06fax : string;
  cnt06sitioweb : string;
  cnt06activo : number;
  createby : string;
  
}

export interface Clienteestacioncomunicaciones{
  clienteestacioncomunicaciones: Clienteestacioncomunicacion[];
}

export interface Clienteestacioncontacto{
  cnt01llave : number;
  cnt04llave : number;
  cnt05llave : number;
  cnt05nombre : string;
  per01llave : number;
  per02llave : number;
  per02titulo : string;
  per03llave : number;
  per03nombre : string;
  per08llave : number;
  per08nombre : string;
  per01rut : number;
  per01nombrerazon : string;
  per01activo : number;
  per05direccion : string;
  sist03llave : number;
  sist03nombre : string;
  sist04llave : number;
  sist04nombre : string;
  per05casilla : string;
  per05tienecasilla : number;
  per05codigopostal : string;
  per05email : string;
  per05telefono1 : string;
  per05telefono2 : string;
  per05celular1 : string;
  per05celular2 : string;
  per05fax : string;
  per05sitioWeb : string;
  createby : string;

}

export interface Clienteestacioncontactos{
  clienteestacioncontactos: Clienteestacioncontacto[];
}