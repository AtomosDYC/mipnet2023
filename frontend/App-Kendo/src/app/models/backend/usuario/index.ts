export interface usuarioregistro{

    userid: string;
    username: string;
    name: string;
    password: string;
    roleid: string;
    rolename: string;
    per01llave: number;
    per01nombre: string;
    email: string;
    emailconfirmed: string;
    tipodocumentoid: string;
    tipodocumentonombre: string;
    tipopersonaid: string;
    tipopersonanombre: string;
    plantillaid: string;
    plantillanombre: string;
    saludoid: string;
    saludonombre: string;

  }
  
  export interface usuarioregistros{
    usuarioregistros: usuarioregistro[];
  }