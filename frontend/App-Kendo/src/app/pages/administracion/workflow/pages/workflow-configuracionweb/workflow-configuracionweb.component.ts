import { Component, OnInit, QueryList } from '@angular/core';

import { FormGroup, Validators, FormBuilder, FormControl } from '@angular/forms';

import * as fromRoot from '../../../../../store';
import * as fromList from '../../store/save';

import { MessageService } from '@progress/kendo-angular-l10n';
import { CustomMessagesService } from 'src/app/services/custom-messages.service';
import { IntlService } from '@progress/kendo-angular-intl';

import { ActivatedRoute, Router } from '@angular/router';

import { WorkflowConfiguracionwebRequest as Request } from '../../store/save';
import { Observable } from 'rxjs';
import { Store, select } from '@ngrx/store';

@Component({
  selector: 'app-workflow-configuracionweb',
  templateUrl: './workflow-configuracionweb.component.html',
  styleUrls: ['./workflow-configuracionweb.component.scss']
})
export class WorkflowConfiguracionwebComponent implements OnInit {

  loading$ !: Observable<boolean | null>;
  
  public Form: FormGroup = new FormGroup(
    {
      txtUrl: new FormControl( null),
      txtIconomenu: new FormControl(null),
      chkVisiblemenu: new FormControl(null)
    }
  );
  public ID: string | null;
  errorMessage: any;

  public customMsgService: CustomMessagesService;

  constructor(
    private fb: FormBuilder,
    public intl: IntlService, 
    public messages: MessageService,
    private _routeParams: ActivatedRoute,
    private store: Store<fromRoot.State>,
  ) {
    this.customMsgService = this.messages as CustomMessagesService;
   }

  ngOnInit(): void {
    
    this.Form = new FormGroup({
      txtUrl: new FormControl( null),
      txtIconomenu: new FormControl(null),
      chkVisiblemenu: new FormControl(null)
    });

    this._routeParams.paramMap.subscribe(params => {
      this.ID = (params.get('id'));

      if(this.ID) {

        this.store.dispatch(new fromList.Getbyid(this.ID));

        this.loading$ = this.store.pipe(select(fromList.getLoading))!;
        this.store.pipe(select(fromList.getWorkflowbyid))
          .subscribe(data => {
            if(data){

              const esvisible = data.wkf01visiblemenu ? true : false;

              this.Form = new FormGroup({
                txtUrl: new FormControl( data.wkf01url),
                txtIconomenu: new FormControl(data.wkf01iconourl),
                chkVisiblemenu: new FormControl(esvisible),
              });
               
            } else {
              
            }
          })
      } else {

         this.Form = new FormGroup({
          txtUrl: new FormControl( null),
          txtIconomenu: new FormControl(null),
          chkVisiblemenu: new FormControl(null)
        });
      }
    });
    
  }

  

  onguardarNuevoConfiguracion(): void {

    this.Form.markAllAsTouched();

    if(this.Form.valid){

      if(this.ID){

        const { txtUrl, txtIconomenu , chkVisiblemenu  } = this.Form.value;

        const visible = chkVisiblemenu ? 1 : 0

        this.loading$ = this.store.pipe(select(fromList.getLoading));

          const UpdateRequest : Request = {
            
            wkf01llave : Number(this.ID),
            wkf01url: String(txtUrl).toLowerCase(),
            wkf01iconourl: String(txtIconomenu).toLowerCase(),
            wkf01visiblemenu: visible
          }

          this.store.dispatch(new fromList.UpdateConfiguracionweb(UpdateRequest));

      } else {
      
        
      }
    }
  }

}
