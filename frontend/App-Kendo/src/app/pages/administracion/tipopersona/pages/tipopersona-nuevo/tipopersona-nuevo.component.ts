import { Component, OnInit } from '@angular/core';

import { FormGroup, Validators, FormBuilder, FormControl } from '@angular/forms';

import { select, Store } from '@ngrx/store';
import { Observable } from 'rxjs';

import * as fromRoot from '../../../../../store';
import * as fromList from '../../store/save';
import { MessageService } from '@progress/kendo-angular-l10n';
import { CustomMessagesService } from 'src/app/services/custom-messages.service';
import { IntlService } from '@progress/kendo-angular-intl';
import { TipoPersonaResponse as Response } from '../../store/save';
import { TipoPersonaCreateRequest as Request } from '../../store/save';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-tipopersona-nuevo',
  templateUrl: './tipopersona-nuevo.component.html',
  styleUrls: ['./tipopersona-nuevo.component.scss']
})
export class TipopersonaNuevoComponent implements OnInit {

  loading$ !: Observable<boolean | null>;
  
  public Form: FormGroup;
  public ID: string | null;

  public customMsgService: CustomMessagesService;

  listdata :  Response  = {
    per03llave: 0,
    per03nombre: '',
    per03descripcion: '',
    per03activo: 0
  }

  constructor(private fb: FormBuilder,
    private store: Store<fromRoot.State>,
    public intl: IntlService, 
    public messages: MessageService,
    private _routeParams: ActivatedRoute,
    )
  {
    this.customMsgService = this.messages as CustomMessagesService;
  }

  ngOnInit(): void {

    this._routeParams.paramMap.subscribe(params => {
      this.ID = (params.get('id'));

      if(this.ID) {

        this.store.dispatch(new fromList.Getbyid(this.ID));

        this.loading$ = this.store.pipe(select(fromList.getLoading))!;
        this.store.pipe(select(fromList.getTipoPersonabyid))
          .subscribe(data => {
            if(data){

                this.Form = new FormGroup({
                  txtNombre: new FormControl( data.per03nombre , [Validators.required]),
                  txtDescripcion: new FormControl(data.per03descripcion, [Validators.required])
                });

            } else {
              
            }
          })
      }

      this.Form = new FormGroup({
        txtNombre: new FormControl( this.listdata.per03nombre , [Validators.required]),
        txtDescripcion: new FormControl(this.listdata.per03descripcion, [Validators.required])
      });

    });
    
  }

  onguardarNuevo(): void {

    
  }
}