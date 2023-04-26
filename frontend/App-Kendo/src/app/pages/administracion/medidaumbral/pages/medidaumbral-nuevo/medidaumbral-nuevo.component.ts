import { Component, OnInit } from '@angular/core';

import { FormGroup, Validators, FormBuilder, FormControl } from '@angular/forms';

import { select, Store } from '@ngrx/store';
import { Observable } from 'rxjs';

import * as fromRoot from '../../../../../store';
import * as fromList from '../../store/save';
import { MessageService } from '@progress/kendo-angular-l10n';
import { CustomMessagesService } from 'src/app/services/custom-messages.service';
import { IntlService } from '@progress/kendo-angular-intl';
import { MedidaUmbralResponse as Response } from '../../store/save';
import { MedidaUmbralCreateRequest as Request } from '../../store/save';
import { ActivatedRoute, Router } from '@angular/router';
import { getMedidaUmbralbyid } from '../../store/save/save.selectors';

@Component({
  selector: 'app-medidaumbral-nuevo',
  templateUrl: './medidaumbral-nuevo.component.html',
  styleUrls: ['./medidaumbral-nuevo.component.scss']
})
export class MedidaumbralNuevoComponent implements OnInit {

  loading$ !: Observable<boolean | null>;
  
  public Form: FormGroup;
  public ID: string | null;

  public customMsgService: CustomMessagesService;

  listdata :  Response  = {
    esp06llave: 0,
    esp06nombre: '',
    esp06descripcion: '',
    esp06activo: 0
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
        this.store.pipe(select(fromList.getMedidaUmbralbyid))
          .subscribe(data => {
            if(data){

                this.Form = new FormGroup({
                  txtNombre: new FormControl( data.esp06nombre , [Validators.required]),
                  txtDescripcion: new FormControl(data.esp06descripcion, [Validators.required])
                });

            } else {
              
            }
          })
      }

      this.Form = new FormGroup({
        txtNombre: new FormControl( this.listdata.esp06nombre , [Validators.required]),
        txtDescripcion: new FormControl(this.listdata.esp06descripcion, [Validators.required])
      });

    });
    
  }

  onguardarNuevo(): void {

    this.Form.markAllAsTouched();

    if(this.Form.valid){

      if(this.ID){

        const { txtNombre, txtDescripcion } = this.Form.value;

        const DataResponse : Response = {
          esp06llave : Number(this.ID),
          esp06nombre : String(txtNombre).toLowerCase().replace(/^\w/, (c) => c.toUpperCase()),
          esp06descripcion: String(txtDescripcion).toLowerCase().replace(/^\w/, (c) => c.toUpperCase()),
          esp06activo : 0
        }

        this.store.dispatch(new fromList.Update(DataResponse));

      } else {
      
        const { txtNombre, txtDescripcion } = this.Form.value;

        this.loading$ = this.store.pipe(select(fromList.getLoading));

          const CreateRequest : Request = {
            esp06nombre : String(txtNombre).toLowerCase().replace(/^\w/, (c) => c.toUpperCase()),
            esp06descripcion: String(txtDescripcion).toLowerCase().replace(/^\w/, (c) => c.toUpperCase()),
          }

          
          this.store.dispatch(new fromList.Create(CreateRequest));

      }
    }
  }
}