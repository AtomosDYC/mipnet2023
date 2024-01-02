export interface Persona{
    per01llave: number;
    per01rut: number;
    per03llave: number;
    per03nombre: string;
    per08llave: number;
    per08nombre: string;
    per02llave: number;
    per02nombre: string;
    per01nombrerazon: string;
    per01nombrefantasia: string;
    per01giro: string;
    per01cargo: string;
    per01fechanacimiento: Date;
    per01anioingreso: number;
    per01activo: number;
  }
  
  export interface Personas{
    personas: Persona[];
  }
  

  export interface Personacomunicacion{
    per01llave : number;
    per04llave : number;
    per04nombre : string;
    per03llave : number;
    per03nombre : string;
    per05Direccion : string;
    sist03llave : number;
    sist03nombre : string;
    sist04llave : number;
    sist04nombre : string;
    per0Casilla : string;
    per05TieneCasilla : number;
    per05CodigoPostal : string;
    per05Email : string;
    per05Telefono1 : string;
    per05Telefono2 : string;
    per05Celular1 : string;
    per05Celular2 : string;
    per05Fax : string;
    per05SitioWeb : string;
  }

  export interface Personacomunicaciones{
    personacomunicaciones: Personacomunicacion[];
  }


  export interface PersonaAcceso 
  {
    per07llave : number;
    per01llave : number;
    per01nombrerazon : string;
    userid : string;
    username : string;
    per07activo : number;
  }

  export interface PersonaAccesoRequest 
  {
    per01llave : number;
    username : string;
    password : string;
  }

  export interface PersonaBuscarRut
  {  
    per01rut: number;
    per08llave: number;
  }

  

