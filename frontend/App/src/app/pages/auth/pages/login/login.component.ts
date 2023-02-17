import { Component, OnInit, ViewChild, QueryList } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';
import { Router } from '@angular/router';
import { ValidatorFn, ValidationErrors, UntypedFormGroup, UntypedFormBuilder, Validators } from '@angular/forms';

import { Store } from '@ngrx/store';
import { LoginValidationServices } from './login-validation-services'

import { Observable } from 'rxjs';

import * as fromRoot from '../../../../store';
import * as fromUser from '../../../../store/user';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  loginForm: FormGroup;

  loading$ !: Observable<boolean | null>;
  customStylesValidated:any;
  showSpinner: boolean = false;

  constructor(
    private router: Router,
    private store:Store<fromRoot.State>,
    private fb: FormBuilder
    ) { }

  ngOnInit(): void {
    this.loginForm = this.fb.group({
      email: ['', [Validators.required, Validators.email]],
      password: ['', Validators.required],
    })
  }

  LoginUsuario(){

    if( this.loginForm.invalid) { return; }

    const { email, password } = this.loginForm.value;

    const userLoginResquest: fromUser.EmailPasswordCredentials = {
      email :  email,
      password : password
    }
    console.log('userLoginResquest',userLoginResquest);

    this.store.dispatch(new fromUser.SignInEmail(userLoginResquest));

  }



}
