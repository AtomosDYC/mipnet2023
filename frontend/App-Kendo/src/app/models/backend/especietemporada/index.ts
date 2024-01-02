export interface EspecieTemporada
{
    
    esp02llave: number;
    esp01llave: number;
    esp03llave: number;
    esp03nombre: string;
    esp04llave: number;
    esp04nombre: string;
    esp08llave: string;
    esp08nombre: string;
    temp01llave: number;
    temp02llave: number;
    temp02nombre: string;
    esp02iniciotemporada: Date;
    esp02terminotemporada: Date;
    esp02sag: number;
    esp02mexico: number;
    esp02activo: number;

}
  
  export interface EspecieTemporadas{
    especietemporada: EspecieTemporada[];
  }