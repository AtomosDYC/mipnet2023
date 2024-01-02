export interface User{
  id: string;
  token: string;
  roleid: string;
  rolename: string;
  per01llave: number;
  per01nombre: string;
  prf03llave: number;
  prf03nombre: string;
  username: string;
  email: string;
}

export interface Usuario{
  Id: string;
  userName: string;
  Email: string;
  roleid: string;
  rolename: string;
  per01llave: number;
  per01nombre: string;
  prf03llave: number;
  prf03nombre: string;
}

export interface Usuarios{
  usuarios: Usuario[];
}
