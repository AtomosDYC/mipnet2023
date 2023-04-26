export interface usuarioregistro{
    userid: string;
    username: string;
    name:string;
    password:string;
    roleid: string;
    rolename: string;
    per01llave: number;
    per01nombre: string;
    prf03llave: number;
    prf03nombre: string;
  }
  
  export interface usuarioregistros{
    usuarioregistros: usuarioregistro[];
  }