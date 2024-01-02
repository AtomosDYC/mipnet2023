import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';


@Injectable({
  providedIn: 'root'
})
export class MenuService {

  constructor( private http: HttpClient ) { }

  public GetMenu = () => {
    return this.http.get(`${environment.url}api/menu`);
  }


}
