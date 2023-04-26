
 export interface DefaultUser{
    per09llave?: number;
    per09nombre?: string;
    rolid?: number;
    tipodocumentoid?: number;
    tipopersonaid?: number;
    plantillaid?: number;
    saludoid?: number;

    rolnombre?: string;
    tipodocumentonombre?: string;
    tipopersonanombre?: string;
    plantillanombre?: string;
    saludonombre?: string;

  }
  
  export interface DefaultUsers{
    defaultuser: DefaultUser[];
  }