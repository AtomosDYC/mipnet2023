import { Component, OnInit } from '@angular/core';

import { FormGroup, Validators, FormBuilder, FormControl } from '@angular/forms';

import { select, Store } from '@ngrx/store';
import { Observable } from 'rxjs';

import * as fromRoot from '../../../../../store';
import * as fromList from '../../store/save';
import { MessageService } from '@progress/kendo-angular-l10n';
import { CustomMessagesService } from 'src/app/services/custom-messages.service';
import { IntlService } from '@progress/kendo-angular-intl';
import { TipoPermisoResponse as Response } from '../../store/save';
import { TipoPermisoCreateRequest as Request } from '../../store/save';
import { ActivatedRoute, Router } from '@angular/router';


@Component({
  selector: 'app-tipopermiso-nuevo',
  templateUrl: './tipopermiso-nuevo.component.html',
  styleUrls: ['./tipopermiso-nuevo.component.scss']
})
export class TipopermisoNuevoComponent implements OnInit {

  loading$ !: Observable<boolean | null>;
  
  public Form: FormGroup;
  public ID: string | null;

  public customMsgService: CustomMessagesService;

  listdata :  Response  = {
    wkf05llave: 0,
    wkf05nombre: '',
    wkf05descripcion: '',
    wkf05activo: 0,
    wkf05sigla: ''
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
        this.store.pipe(select(fromList.getTipoPermisobyid))
          .subscribe(data => {
            if(data){

                this.Form = new FormGroup({
                  txtNombre: new FormControl( data.wkf05nombre , [Validators.required]),
                  txtDescripcion: new FormControl(data.wkf05descripcion, [Validators.required]),
                  txtSigla: new FormControl(data.wkf05sigla, [Validators.required])
                });

            } else {
              
            }
          })
      }

      this.Form = new FormGroup({
        txtNombre: new FormControl( this.listdata.wkf05nombre , [Validators.required]),
        txtDescripcion: new FormControl(this.listdata.wkf05descripcion, [Validators.required]),
        txtSigla: new FormControl(this.listdata.wkf05sigla, [Validators.required])
      });

    });
    
  }

  onguardarNuevo(): void {

    this.Form.markAllAsTouched();

    if(this.Form.valid){

      if(this.ID){

        const { txtNombre, txtDescripcion } = this.Form.value;

        const DataResponse : Response = {
          wkf05llave : Number(this.ID),
          wkf05nombre : String(txtNombre).toLowerCase().replace(/^\w/, (c) => c.toUpperCase()),
          wkf05descripcion: String(txtDescripcion).toLowerCase().replace(/^\w/, (c) => c.toUpperCase()),
          wkf05activo : 0,
          wkf05sigla: String(txtDescripcion).toLowerCase().replace(/^\w/, (c) => c.toUpperCase())
        }

        this.store.dispatch(new fromList.Update(DataResponse));

      } else {
      
        const { txtNombre, txtDescripcion } = this.Form.value;

        this.loading$ = this.store.pipe(select(fromList.getLoading));

          const CreateRequest : Request = {
            wkf05nombre : String(txtNombre).toLowerCase().replace(/^\w/, (c) => c.toUpperCase()),
            wkf05descripcion: String(txtDescripcion).toLowerCase().replace(/^\w/, (c) => c.toUpperCase()),
            wkf05sigla: String(txtDescripcion).toLowerCase().replace(/^\w/, (c) => c.toUpperCase())
          }
          

          
          this.store.dispatch(new fromList.Create(CreateRequest));

      }
    }
  }
}