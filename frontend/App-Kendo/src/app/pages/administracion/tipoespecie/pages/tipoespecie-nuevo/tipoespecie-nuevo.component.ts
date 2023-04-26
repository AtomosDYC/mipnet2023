import { Component, OnInit } from '@angular/core';

import { FormGroup, Validators, FormBuilder, FormControl } from '@angular/forms';

import { select, Store } from '@ngrx/store';
import { Observable } from 'rxjs';

import * as fromRoot from '../../../../../store';
import * as fromList from '../../store/save';
import { MessageService } from '@progress/kendo-angular-l10n';
import { CustomMessagesService } from 'src/app/services/custom-messages.service';
import { IntlService } from '@progress/kendo-angular-intl';
import { TipoEspecieResponse as Response } from '../../store/save';
import { TipoEspecieCreateRequest as Request } from '../../store/save';
import { ActivatedRoute, Router } from '@angular/router';
import { getTipoEspeciebyid } from '../../store/save/save.selectors';

@Component({
  selector: 'app-tipoespecie-nuevo',
  templateUrl: './tipoespecie-nuevo.component.html',
  styleUrls: ['./tipoespecie-nuevo.component.scss']
})
export class TipoespecieNuevoComponent implements OnInit {

  loading$ !: Observable<boolean | null>;
  
  public Form: FormGroup;
  public ID: string | null;

  public customMsgService: CustomMessagesService;

  listdata :  Response  = {
    esp08llave: 0,
    esp08nombre: '',
    esp08descripcion: '',
    esp08activo: 0
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
        this.store.pipe(select(fromList.getTipoEspeciebyid))
          .subscribe(data => {
            if(data){

                this.Form = new FormGroup({
                  txtNombre: new FormControl( data.esp08nombre , [Validators.required]),
                  txtDescripcion: new FormControl(data.esp08descripcion, [Validators.required])
                });

            } else {
              
            }
          })
      }

      this.Form = new FormGroup({
        txtNombre: new FormControl( this.listdata.esp08nombre , [Validators.required]),
        txtDescripcion: new FormControl(this.listdata.esp08descripcion, [Validators.required])
      });

    });
    
  }

  onguardarNuevo(): void {

    this.Form.markAllAsTouched();

    if(this.Form.valid){

      if(this.ID){

        const { txtNombre, txtDescripcion } = this.Form.value;

        const DataResponse : Response = {
          esp08llave : Number(this.ID),
          esp08nombre : String(txtNombre).toLowerCase().replace(/^\w/, (c) => c.toUpperCase()),
          esp08descripcion: String(txtDescripcion).toLowerCase().replace(/^\w/, (c) => c.toUpperCase()),
          esp08activo : 0
        }

        this.store.dispatch(new fromList.Update(DataResponse));

      } else {
      
        const { txtNombre, txtDescripcion } = this.Form.value;

        this.loading$ = this.store.pipe(select(fromList.getLoading));

          const CreateRequest : Request = {
            esp08nombre : String(txtNombre).toLowerCase().replace(/^\w/, (c) => c.toUpperCase()),
            esp08descripcion: String(txtDescripcion).toLowerCase().replace(/^\w/, (c) => c.toUpperCase()),
          }

          
          this.store.dispatch(new fromList.Create(CreateRequest));

      }
    }
  }
}