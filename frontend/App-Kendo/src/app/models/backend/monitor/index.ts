export interface Monitor{
    mnt01llave: number;
    per01llave: number;
    mnt04llave: number;
    mnt04nombre: string;
    mnt01Cargo: string;
    mnt01Iniciolabores: string;
    mnt01activo: number;

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
    per01fechanacimiento: string;
    per01anioingreso: string;
    per01activo: number;
  
  }
  
  export interface Monitores{
    monitor: Monitor[];
  }

  export interface Monitorcomunicacion{
    mnt01llave: number;
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
    per05Casilla : string;
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

  export interface Monitorcomunicaciones{
    personacomunicaciones: Monitorcomunicacion[];
  }

  export interface MonitorAcceso 
  {
    per07llave : number;
    per01llave : number;
    per01nombrerazon : string;
    userid : string;
    username : string;
    per07activo : number;
  }

  export interface MonitorAccesoRequest 
  {
    per01llave : number;
    username : string;
    password : string;
  }

  export interface Monitorespecie {
    mnt01llave : number;
    esp02llave : number;
    esp01llave : number;
    temp01llave : number;
    esp03llave  : number;
    esp03nombre  : string;
    esp04llave  : number;
    esp04nombre  : string;
    esp08llave  : number;
    esp08nombre  : string;
    temp02llave  : number;
    temp02nombre  : string;
  }

  export interface Monitorespecies{
    monitorespecie: Monitorespecie[];
  }

  export interface MonitorSincronizacion {
    mnt01llave : number;
    per01llave : number;
    userid : number;
    per01nombrerazon: string;
    nombreTabla: string;
    aliastabla: string;
    fechaultimaactualizacion: Date;
    ultimaactualizacion: Date;
    urlimg: string;
  }

  export interface MonitorSincronizaciones{
    monitorsincronizacion: MonitorSincronizacion[];
  }

  export interface MonitorTrampa {
    Mnt01llave : number;
    per01llave : number;
    per01nombrerazon : string;  
    Trp01llave : number;
    cnt08llave : number;  
    cnt08nombre : string;
    esp01llave : number;
    esp03llave : number;
    esp03nombre : string;
    esp04llave : number;
    esp04nombre : string;
    Temp02llave : number;
    temp02nombre : string;
    Mnt03activo : number;
  }

  export interface MonitorTrampas { 
    monitortrampa : MonitorTrampa[];
  }

  export interface AsignarTrampa {
    mnt01llave : number;
    trp01llave : number;
    temp02llave : number;
  }

  