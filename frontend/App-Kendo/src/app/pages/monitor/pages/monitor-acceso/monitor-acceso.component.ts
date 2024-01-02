import { Component, OnInit, ViewChild } from '@angular/core';

import { FormGroup, Validators, FormBuilder, FormControl } from '@angular/forms';

import { select, Store } from '@ngrx/store';
import { Observable } from 'rxjs';

import * as fromRoot from '../../../../store';
import * as fromList from './store/save';
import * as fromMenu from '../../../../store/menu';

import { MonitorAccesoResponse as Response, MonitorAccesoRequest as Request } from './store/save';

import { MessageService } from '@progress/kendo-angular-l10n';
import { CustomMessagesService } from 'src/app/services/custom-messages.service';
import { IntlService } from '@progress/kendo-angular-intl';

import { ActivatedRoute, Router } from '@angular/router';
import { MustMatch } from '../../../../_helpers/must-match.validator';
import { PasswordValidator  } from '../../../../_helpers/password-validation.validator';


@Component({
  selector: 'app-monitor-acceso',
  templateUrl: './monitor-acceso.component.html',
  styleUrls: ['./monitor-acceso.component.scss']
})
export class MonitorAccesoComponent implements OnInit {

  loading$ !: Observable<boolean | null>;
  
  public Form: FormGroup;
  public ID: string | null;
  public isloged : boolean = false;
  public customMsgService: CustomMessagesService;
  public isDisabledContinuarMonimotorAcceso : boolean = true;

  constructor(private FormBuilder: FormBuilder,
    private store: Store<fromRoot.State>,
    public intl: IntlService, 
    public messages: MessageService,
    private _routeParams: ActivatedRoute,
    private _Route: Router,
    )
  {
    this.customMsgService = this.messages as CustomMessagesService;
  }

  ngOnInit(): void {

    this.Form = this.FormBuilder.group({
      email: [null, Validators.compose([Validators.required, Validators.email])],
      password: [null, Validators.compose([Validators.required, PasswordValidator.strong])],
      confirmpassword: [null, [Validators.required]],
    }, {
      validator: MustMatch('password', 'confirmpassword')
    });

    this._routeParams.paramMap.subscribe(params => {
      this.ID = (params.get('id'));

      if(this.ID) {

        var dato = this.store.dispatch(new fromList.GetMonitorAcceso(this.ID));

        //console.log('GetMonitorAcceso', dato);

        this.loading$ = this.store.pipe(select(fromList.getLoadingAcceso))!;

        this.store.pipe(select(fromList.GetMonitorAccesobyid))
          .subscribe(data => {
            if(data){
              
              this.Form.patchValue({
                email: data.username
             });
             
             this.isloged = true;

            } else {
              
            }
          })
      } 
    });
    
  }

  onguardarNuevo(): void {

    
    this.Form.markAllAsTouched();
    // stop here if form is invalid

    if(this.Form.valid){
    
      const { email, password } = this.Form.value;

      this.loading$ = this.store.pipe(select(fromList.getLoadingAcceso));

      const CreateRequest : Request = {
        per01llave: Number(this.ID),
        password: password,
        username : String(email).toLowerCase()
      }

      //console.log('CreateRequest',CreateRequest);
    
      this.store.dispatch(new fromList.CreateMonitorAcceso(CreateRequest));


      
    }
 
  }

  onContinuarMonitoracceso() {
    if(this.ID){
      this._Route.navigate(['/dashboard/monitor/especiesasignadas/', this.ID]);
    }
  }

  OnFinalizarDatosGenerales() 
  {
    this.store.dispatch(new fromMenu.MenuExpanded(true));
    this._Route.navigate(['/dashboard/monitor/list']);

  }
  
}
