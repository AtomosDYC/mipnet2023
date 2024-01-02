import { Component, OnInit, ViewChild, QueryList } from '@angular/core';
import { FormGroup, FormBuilder, FormControl } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
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
  private returnUrl: string;
  loading$ !: Observable<boolean | null>;
  customStylesValidated:any;
  showSpinner: boolean = false;

  constructor(
    private router: Router,
    private store:Store<fromRoot.State>,
    private route: ActivatedRoute
    ) { }

  ngOnInit(): void {
    this.loginForm = new FormGroup({
      username: new FormControl("", [Validators.required]),
      password: new FormControl("", [Validators.required])
    })
    this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
  }

  public login(): void {

    this.loginForm.markAllAsTouched();
    if( this.loginForm.invalid) { return; }

    const { username, password } = this.loginForm.value;

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
