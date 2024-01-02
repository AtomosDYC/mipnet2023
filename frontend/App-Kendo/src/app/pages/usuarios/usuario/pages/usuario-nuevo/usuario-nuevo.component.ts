import { Component, OnInit, ViewChild } from '@angular/core';

import { FormGroup, Validators, FormBuilder, FormControl } from '@angular/forms';

import { select, Store } from '@ngrx/store';
import { Observable } from 'rxjs';

import * as fromRoot from '../../../../../store';
import * as fromList from '../../store/save';
import { MessageService } from '@progress/kendo-angular-l10n';
import { CustomMessagesService } from 'src/app/services/custom-messages.service';
import { IntlService } from '@progress/kendo-angular-intl';
import { UsuarioResponse as Response, UsuarioRegistroCreateRequest as request } from '../../store/save';
import { ActivatedRoute, Router } from '@angular/router';
import { MustMatch } from '../../../../../_helpers/must-match.validator';
import { PasswordValidator  } from '../../../../../_helpers/password-validation.validator';
import { TextBoxComponent } from "@progress/kendo-angular-inputs";

@Component({
  selector: 'app-usuario-nuevo',
  templateUrl: './usuario-nuevo.component.html',
  styleUrls: ['./usuario-nuevo.component.scss']
})
export class UsuarioNuevoComponent implements OnInit {

  @ViewChild("password") public textbox: TextBoxComponent;

  loading$ !: Observable<boolean | null>;
  
  public Form: FormGroup;
  public ID: string | null;

  public customMsgService: CustomMessagesService;


  constructor(private FormBuilder: FormBuilder,
    private store: Store<fromRoot.State>,
    public intl: IntlService, 
    public messages: MessageService,
    private _routeParams: ActivatedRoute,
    )
  {
    this.customMsgService = this.messages as CustomMessagesService;
  }

  ngOnInit(): void {

    this.Form = this.FormBuilder.group({
      txtNombre: [null, Validators.required],
      email: [null, Validators.compose([Validators.required, Validators.email])],
      password: [null, Validators.compose([Validators.required, PasswordValidator.strong])],
      confirmpassword: [null, [Validators.required]],
  }, {
      validator: MustMatch('password', 'confirmpassword')
  });
    
  }

  onguardarNuevo(): void {

    this.Form.markAllAsTouched();
    // stop here if form is invalid

    if(this.Form.valid){
    
      const { txtNombre, email, password } = this.Form.value;

      this.loading$ = this.store.pipe(select(fromList.getLoading));

      const CreateRequest : request = {
        name : String(txtNombre).toLowerCase().replace(/^\w/, (c) => c.toUpperCase()),
        password: password,
        username : String(email).toLowerCase()
      }

      //console.log('CreateRequest',CreateRequest);
    
      this.store.dispatch(new fromList.Create(CreateRequest));

    }

  }
}