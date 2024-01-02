import { Component, OnInit } from '@angular/core';

import { HttpErrorResponse } from '@angular/common/http';
import { ResetPasswordDto } from './../../../../models/backend/resetPassword/resetPasswordDto.model';
import { ActivatedRoute } from '@angular/router';

import { AuthenticationService } from './../../../../services/authentication.service';
import { MustMatch } from '../../../../_helpers/must-match.validator';
import { PasswordValidator  } from '../../../../_helpers/password-validation.validator';
import { TextBoxComponent } from "@progress/kendo-angular-inputs";
import { FormGroup, FormControl, Validators, FormBuilder } from '@angular/forms';

@Component({
  selector: 'app-reset-password',
  templateUrl: './reset-password.component.html',
  styleUrls: ['./reset-password.component.scss']
})
export class ResetPasswordComponent implements OnInit {

  resetPasswordForm: FormGroup;
  showSuccess: boolean;
  showError: boolean;
  errorMessage: string;

  private token: string;
  private email: string;

  constructor(
    private authService: AuthenticationService, 
    private FormBuilder: FormBuilder,
    private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.resetPasswordForm = new FormGroup({
      password: new FormControl("", [Validators.required, PasswordValidator.strong]),
      confirm: new FormControl("", [Validators.required]),
    }), {
      validator: MustMatch('password', 'confirmpassword')
  };

    this.token = this.route.snapshot.queryParams['token'];
    this.email = this.route.snapshot.queryParams['email'];
  }

  public resetPassword = (resetPasswordFormValue) => {
    this.showError = this.showSuccess = false;
    const resetPass = { ...resetPasswordFormValue };

    const resetPassDto: ResetPasswordDto = {
      password: resetPass.password,
      confirmPassword: resetPass.confirm,
      token: this.token,
      email: this.email
    }

    this.authService.resetPassword(resetPassDto)
      .subscribe({
        next: (_) => this.showSuccess = true,
        error: (err: HttpErrorResponse) => {
          this.showError = true;
          this.errorMessage = err.message;
        }
      })
  }

}
