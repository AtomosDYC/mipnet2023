export interface Especie{
    esp03llave: number;
    esp03nombre: string;
    esp03descripcion: string;
    esp08llave: number;
    esp08nombre: string;
    esp03ImgGrande: string;
    esp03ImgPequenia: string;
    esp03Union: number;
    esp03EstadoRegistro: string;
    esp03activo: number;
  
  }
  
  export interface Especies{
    especies: Especie[];
  }

  export interface UnirEspecie{
    esp03llave: number;
    esp03nombre: string;
    esp03llaveunion: number;
    esp03nombreunion: string;
  }

  export interface UnirEspecies{
    unirespecies: UnirEspecie[];
  }

  export interface DanioEspecie{
    esp01llave: number;
    esp03llave: number;
    esp03nombre: string;
    esp04llave: number;
    esp04nombre: string;
    esp01activo: number;
  }

  export interface DanioEspecies{
    danioespecies: DanioEspecie[];
  }

  export interface EspecieUmbral{
    esp05llave: number;
    esp01llave: number;
    esp03llave: number;
    esp03nombre: string;
    esp04llave: number;
    esp04nombre: string;
    esp05minumbral: number;
    esp05maxumbral: number;
    esp05color: string;
    esp09llave: number;
    esp09nombre: string;
    esp05activo: number;
  }

  export interface EspecieUmbrals{
    especieumbrals: EspecieUmbral[];
  }

  

