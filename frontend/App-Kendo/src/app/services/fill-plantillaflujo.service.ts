import { Injectable } from '@angular/core';

import { Observable, throwError } from 'rxjs'
import { catchError, tap } from 'rxjs/operators'
import { HttpClient, HttpErrorResponse, HttpHeaders, HttpParams, HttpResponse } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { Workflow, Workflows } from '../models/backend/workflow'
import { CustomEncoder } from '../_helpers/custom-encoder';


@Injectable({
  providedIn: 'root'
})
export class FillPlantillaflujoService {

  constructor
  (
    private httpClient: HttpClient
  ) { }

  // Get All Member
  public Getdata(LLaveID: number)
  {

    let params = new HttpParams({ encoder: new CustomEncoder() })
      params = params.append('Id', LLaveID);
      

      return this.httpClient.get<Workflow[]>(`${environment.url}api/plantillaflujo`, { params: params })
        .pipe(tap(data => data),
          //catchError(this.handleError)
      );
  }

}
