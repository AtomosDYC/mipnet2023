
import { Injectable } from '@angular/core';

import { HttpClient, HttpParams } from '@angular/common/http';
import { Subject } from 'rxjs';
import { CustomEncoder } from '../_helpers/custom-encoder';
import { ForgotPasswordDto} from '../models/backend/resetPassword/forgotPasswordDto.model';
import { ResetPasswordDto } from '../models/backend/resetPassword/resetPasswordDto.model';

import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {
  
  constructor(
    private http: HttpClient, 
    ) { }

    public confirmEmail = (token: string, email: string) => {
      let params = new HttpParams({ encoder: new CustomEncoder() })
      params = params.append('token', token);
      params = params.append('email', email);
      
      return this.http.get(`${environment.url}api/userauth/EmailConfirmation`, { params: params });
    }

  
  public forgotPassword = (route: string, body: ForgotPasswordDto) => {

    //console.log('body', body);
    return this.http.post(`${environment.url}api/UserAuth/ForgotPassword`, body);
  }

  public resetPassword = (body: ResetPasswordDto) => {
    return this.http.post(`${environment.url}api/UserAuth/ResetPassword`, body);
  }

/*  

  public sendAuthStateChangeNotification = (isAuthenticated: boolean) => {
    this.authChangeSub.next(isAuthenticated);
  }
*/
  public logout = () => {
    localStorage.removeItem("token");
    
  }
/*
  public isUserAuthenticated = (): boolean => {
    const token = localStorage.getItem("token");
 
    return token && !this.jwtHelper.isTokenExpired(token);
  }

  public isUserAdmin = (): boolean => {
    const token = localStorage.getItem("token");
    const decodedToken = this.jwtHelper.decodeToken(token);
    const role = decodedToken['http://schemas.microsoft.com/ws/2008/06/identity/claims/role']
    
    return role === 'Administrator';
  }

  private createCompleteRoute = (route: string, envAddress: string) => {
    return `${envAddress}/${route}`;
  }
  */
}
