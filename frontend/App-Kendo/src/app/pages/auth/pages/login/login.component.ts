import { Component, OnInit, ViewChild, QueryList } from '@angular/core';
import { FormGroup, FormBuilder, FormControl } from '@angular/forms';
import { Router } from '@angular/router';
import { ValidatorFn, ValidationErrors, UntypedFormGroup, UntypedFormBuilder, Validators } from '@angular/forms';

import { Store } from '@ngrx/store';
import { LoginValidationServices } from './login-validation-services'

import { Observable } from 'rxjs';

import * as fromRoot from '../../../../store';
import * as fromUser from '../../../../store/user';
import { TextBoxComponent } from '@progress/kendo-angular-inputs';

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
    ) { }

  ngOnInit(): void {
    
  }

  public login(): void {

    this.form.markAllAsTouched();
    if( this.form.invalid) { return; }

    const { username, password } = this.form.value;

    const userLoginResquest: fromUser.EmailPasswordCredentials = {
      email :  username,
      password : password
    }

    this.store.dispatch(new fromUser.SignInEmail(userLoginResquest));

  }


  @ViewChild("password") public textbox: TextBoxComponent;

  public ngAfterViewInit(): void {
    this.textbox.input.nativeElement.type = "password";
  }

  public toggleVisibility(): void {
    const inputEl = this.textbox.input.nativeElement;
    inputEl.type = inputEl.type === "password" ? "text" : "password";
  }

  public form: FormGroup = new FormGroup({
    username: new FormControl(),
    password: new FormControl()
  });

}
