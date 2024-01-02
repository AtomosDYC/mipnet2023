import { HttpErrorResponse } from '@angular/common/http';
import { ForgotPasswordDto } from './../../../../models/backend/resetPassword/forgotPasswordDto.model';
import { AuthenticationService } from './../../../../services/authentication.service';
import { FormGroup, FormBuilder, FormControl, Validators } from '@angular/forms';
import { Component, OnInit } from '@angular/core';



@Component({
  selector: 'app-forgot-password',
  templateUrl: './forgot-password.component.html',
  styleUrls: ['./forgot-password.component.css']
})
export class ForgotPasswordComponent implements OnInit {
  forgotPasswordForm: FormGroup
  successMessage: string;
  errorMessage: string;
  showSuccess: boolean;
  showError: boolean;
  
  constructor(private _authService: AuthenticationService) { }
  
  ngOnInit(): void {
    this.forgotPasswordForm = new FormGroup({
      email: new FormControl("", [Validators.required])
    })
  }


  public validateControl = (controlName: string) => {
    return this.forgotPasswordForm.get(controlName)!.invalid && this.forgotPasswordForm.get(controlName)!.touched
  }

  public hasError = (controlName: string, errorName: string) => {
    return this.forgotPasswordForm.get(controlName)!.hasError(errorName)
  }

  public forgotPassword = (forgotPasswordFormValue) => {
    this.showError = this.showSuccess = false;
    const forgotPass = { ...forgotPasswordFormValue };

    const forgotPassDto: ForgotPasswordDto = {
      email: forgotPass.email,
      clientURI: 'http://localhost:5201/user/resetpassword'
    }

    this._authService.forgotPassword('api/accounts/forgotpassword', forgotPassDto)
    .subscribe({
      next: (_) => {
      this.showSuccess = true;
      this.successMessage = 'Se ha enviado un e-mail para recuperar tu contraseña, por favor revisa tu E-mail.'
    },
    error: (err: HttpErrorResponse) => {
      this.showError = true;
      this.errorMessage = err.message;
    }})
  }
}
