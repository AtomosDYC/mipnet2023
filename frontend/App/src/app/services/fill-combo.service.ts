import { Injectable } from '@angular/core';

import { Observable, throwError } from 'rxjs'
import { catchError, tap } from 'rxjs/operators'
import { HttpClient, HttpErrorResponse, HttpHeaders, HttpResponse } from '@angular/common/http';
import{environment} from '../../environments/environment';
import { GetSelect, SetSelect } from '../models/backend/getselect'


@Injectable({
  providedIn: 'root'
})
export class FillComboService {

  constructor
  (
    private httpClient: HttpClient
  ) { }

  // Get All Member
  public GetAllSelect(SetSelect: SetSelect )
  {
      return this.httpClient.post<GetSelect>(`${environment.url}api/setselect`, SetSelect)
        .pipe(tap(data => data),
          //catchError(this.handleError)
      );
  }
}
