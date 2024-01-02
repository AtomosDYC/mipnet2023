export interface TemporadaBase{
    temp02llave?: number;
    temp02nombre?: string;
    temp02descripcion?: string;
    temp02predeterminada?: number;
    temp02activo?: number;
  }
  
  export interface TemporadaBases{
    temporadabase: TemporadaBase[];
  }
  