import { Injectable } from '@angular/core';

import { Observable, throwError } from 'rxjs'
import { catchError, tap } from 'rxjs/operators'
import { HttpClient, HttpErrorResponse, HttpHeaders, HttpResponse } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { Workflow, Workflows } from '../models/backend/workflow'

@Injectable({
  providedIn: 'root'
})
export class FillWorkflowService {
  
  constructor
  (
    private httpClient: HttpClient
  ) { }

  // Get All Member
  public Getdata()
  {
      return this.httpClient.get<Workflow[]>(`${environment.url}api/workflow`)
        .pipe(tap(data => data),
          //catchError(this.handleError)
      );
  }
  
}
