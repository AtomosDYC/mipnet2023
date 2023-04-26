import { Component, OnInit } from '@angular/core';

import { FormGroup, Validators, FormBuilder, FormControl } from '@angular/forms';

import { select, Store } from '@ngrx/store';
import { Observable } from 'rxjs';

import * as fromRoot from '../../../../../store';
import * as fromList from '../../store/save';
import { MessageService } from '@progress/kendo-angular-l10n';
import { CustomMessagesService } from 'src/app/services/custom-messages.service';
import { IntlService } from '@progress/kendo-angular-intl';
import { TipoFlujoResponse as Response } from '../../store/save';
import { TipoFlujoCreateRequest as Request } from '../../store/save';
import { ActivatedRoute, Router } from '@angular/router';
import { getTipoFlujobyid } from '../../store/save/save.selectors';

@Component({
  selector: 'app-tipoflujo-nuevo',
  templateUrl: './tipoflujo-nuevo.component.html',
  styleUrls: ['./tipoflujo-nuevo.component.scss']
})
export class TipoflujoNuevoComponent implements OnInit {

  loading$ !: Observable<boolean | null>;
  
  public Form: FormGroup;
  public ID: string | null;

  public customMsgService: CustomMessagesService;

  listdata :  Response  = {
    wkf02llave: 0,
    wkf02nombre: '',
    wkf02descripcion: '',
    wkf02orden:0,
    wkf02activo: 0
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
        this.store.pipe(select(fromList.getTipoFlujobyid))
          .subscribe(data => {
            if(data){

                this.Form = new FormGroup({
                  txtNombre: new FormControl( data.wkf02nombre , [Validators.required]),
                  txtDescripcion: new FormControl(data.wkf02descripcion, [Validators.required]),
                  txtOrden: new FormControl(data.wkf02orden, [Validators.required])
                });

            } else {
              
            }
          })
      }

      this.Form = new FormGroup({
        txtNombre: new FormControl( this.listdata.wkf02nombre , [Validators.required]),
        txtDescripcion: new FormControl(this.listdata.wkf02descripcion, [Validators.required]),
        txtOrden: new FormControl(this.listdata.wkf02orden, [Validators.required])
      });

    });
    
  }

  onguardarNuevo(): void {

    this.Form.markAllAsTouched();

    if(this.Form.valid){

      if(this.ID){

        const { txtNombre, txtDescripcion, txtOrden } = this.Form.value;

        const DataResponse : Response = {
          wkf02llave : Number(this.ID),
          wkf02nombre : String(txtNombre).toLowerCase().replace(/^\w/, (c) => c.toUpperCase()),
          wkf02descripcion: String(txtDescripcion).toLowerCase().replace(/^\w/, (c) => c.toUpperCase()),
          wkf02orden: txtOrden,
          wkf02activo : 0
        }

        this.store.dispatch(new fromList.Update(DataResponse));

      } else {
      
        const { txtNombre, txtDescripcion, txtOrden } = this.Form.value;

        this.loading$ = this.store.pipe(select(fromList.getLoading));

          const CreateRequest : Request = {
            wkf02nombre : String(txtNombre).toLowerCase().replace(/^\w/, (c) => c.toUpperCase()),
            wkf02descripcion: String(txtDescripcion).toLowerCase().replace(/^\w/, (c) => c.toUpperCase()),
            wkf02orden: txtOrden
          }

          
          this.store.dispatch(new fromList.Create(CreateRequest));

      }
    }
  }
}
