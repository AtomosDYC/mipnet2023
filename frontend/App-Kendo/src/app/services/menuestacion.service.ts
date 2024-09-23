import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class MenuestacionService {

  constructor( private http: HttpClient ) { }

  public GetMenuEstacion = (cliente: string, encoid: string ) => {

    if (cliente == null){
      cliente = '';
    }
    if (encoid == null){
      encoid = '';
    }
    return this.http.get(`${environment.url}api/clienteusuario/getmenuestaciones/${cliente}/${encodeURIComponent(encoid)}`);

  }
}
