import { Component, OnInit } from '@angular/core';

import { FormGroup, Validators, FormBuilder, FormControl } from '@angular/forms';

import { select, Store } from '@ngrx/store';
import { Observable } from 'rxjs';

import * as fromRoot from '../../../../../store';
import * as fromList from '../../store/save';
import { MessageService } from '@progress/kendo-angular-l10n';
import { CustomMessagesService } from 'src/app/services/custom-messages.service';
import { IntlService } from '@progress/kendo-angular-intl';
import { TipoDocumentoResponse as Response } from '../../store/save';
import { TipoDocumentoCreateRequest as Request } from '../../store/save';
import { ActivatedRoute, Router } from '@angular/router';


@Component({
  selector: 'app-tipodocumento-nuevo',
  templateUrl: './tipodocumento-nuevo.component.html',
  styleUrls: ['./tipodocumento-nuevo.component.scss']
})
export class TipodocumentoNuevoComponent implements OnInit {

  loading$ !: Observable<boolean | null>;
  
  public Form: FormGroup;
  public ID: string | null;

  public customMsgService: CustomMessagesService;

  listdata :  Response  = {
    per08llave: 0,
    per08nombre: '',
    per08descripcion: '',
    per08activo: 0
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
        this.store.pipe(select(fromList.getTipoDocumentobyid))
          .subscribe(data => {
            if(data){

                this.Form = new FormGroup({
                  txtNombre: new FormControl( data.per08nombre , [Validators.required]),
                  txtDescripcion: new FormControl(data.per08descripcion, [Validators.required])
                });

            } else {
              
            }
          })
      }

      this.Form = new FormGroup({
        txtNombre: new FormControl( this.listdata.per08nombre , [Validators.required]),
        txtDescripcion: new FormControl(this.listdata.per08descripcion, [Validators.required])
      });

    });
    
  }

  onguardarNuevo(): void {

    this.Form.markAllAsTouched();

    if(this.Form.valid){

      if(this.ID){

        const { txtNombre, txtDescripcion } = this.Form.value;

        const DataResponse : Response = {
          per08llave : Number(this.ID),
          per08nombre : String(txtNombre).toLowerCase().replace(/^\w/, (c) => c.toUpperCase()),
          per08descripcion: String(txtDescripcion).toLowerCase().replace(/^\w/, (c) => c.toUpperCase()),
          per08activo : 0
        }

        this.store.dispatch(new fromList.Update(DataResponse));

      } else {
      
        const { txtNombre, txtDescripcion } = this.Form.value;

        this.loading$ = this.store.pipe(select(fromList.getLoading));

          const CreateRequest : Request = {
            per08nombre : String(txtNombre).toLowerCase().replace(/^\w/, (c) => c.toUpperCase()),
            per08descripcion: String(txtDescripcion).toLowerCase().replace(/^\w/, (c) => c.toUpperCase()),
          }

          
          this.store.dispatch(new fromList.Create(CreateRequest));

      }
    }
  }
}
  