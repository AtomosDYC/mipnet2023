import { Component, OnInit } from '@angular/core';

import { FormGroup, Validators, FormBuilder, FormControl } from '@angular/forms';

import { select, Store } from '@ngrx/store';
import { Observable } from 'rxjs';

import * as fromRoot from '../../../../../store';
import * as fromList from '../../store/save';
import { MessageService } from '@progress/kendo-angular-l10n';
import { CustomMessagesService } from 'src/app/services/custom-messages.service';
import { IntlService } from '@progress/kendo-angular-intl';
import { NivelFlujoResponse as Response } from '../../store/save';
import { NivelFlujoCreateRequest as Request } from '../../store/save';
import { ActivatedRoute, Router } from '@angular/router';

import { FillComboService } from '../../../../../services/fill-combo.service';
import { SetSelect, GetSelect } from '../../../../../models/backend/getselect/index';
import { getTipoFlujobyid } from '../../../tipoflujo/store/save/save.selectors';
import { getNivelFlujobyid } from '../../store/save/save.selectors';

@Component({
  selector: 'app-nivelflujo-nuevo',
  templateUrl: './nivelflujo-nuevo.component.html',
  styleUrls: ['./nivelflujo-nuevo.component.scss']
})
export class NivelflujoNuevoComponent implements OnInit {

  loading$ !: Observable<boolean | null>;
  
  public Form: FormGroup;
  public ID: string | null;
  private _fillcomboservices;

  TipoFlujolist :Observable<GetSelect[] | null>;
  errorMessage: any;

  setTipoFlujo: SetSelect = {
    tablename : 'tipo_flujo'
  }

  public customMsgService: CustomMessagesService;

  listdata :  Response  = {
    wkf03llave: 0,
    wkf03activo: 1,
    wkf03nombre: '',
    wkf03descripcion: '',
    wkf03nivel1: 0,
    wkf02llave: 0,
    wkf02nombre: ''

  }

  constructor(private fb: FormBuilder,
    private store: Store<fromRoot.State>,
    public intl: IntlService, 
    public messages: MessageService,
    private _routeParams: ActivatedRoute,
    FillComboService: FillComboService,
    )
  {
    this.customMsgService = this.messages as CustomMessagesService;
    this._fillcomboservices = FillComboService;
  }

  ngOnInit(): void {

    this.onLoadcbx();

    this._routeParams.paramMap.subscribe(params => {
      this.ID = (params.get('id'));

      if(this.ID) {

        this.store.dispatch(new fromList.Getbyid(this.ID));

        this.loading$ = this.store.pipe(select(fromList.getLoading))!;
        this.store.pipe(select(fromList.getNivelFlujobyid))
          .subscribe(data => {
            if(data){
              

              this.Form = new FormGroup({
                  txtNombre: new FormControl( data.wkf03nombre , [Validators.required]),
                  txtDescripcion: new FormControl(data.wkf03descripcion, [Validators.required]),
                  cbxTipoFlujo: new FormControl({ text: data.wkf02nombre, value: data.wkf02llave }, [Validators.required]),
                  txtNivel: new FormControl(data.wkf03nivel1, [Validators.required]),
                });

            } else {
              
            }
          })
      }

      this.Form = new FormGroup({
        txtNombre: new FormControl( this.listdata.wkf03nombre , [Validators.required]),
        txtDescripcion: new FormControl(this.listdata.wkf03descripcion, [Validators.required]),
        cbxTipoFlujo: new FormControl({ text: this.listdata.wkf02nombre, value: this.listdata.wkf02llave }, [Validators.required]),
        txtNivel: new FormControl(this.listdata.wkf03nivel1, [Validators.required]),
      });

    });
    
  }

  onLoadcbx():void {

    this._fillcomboservices.GetAllSelect(this.setTipoFlujo).subscribe(
      allrecords => {
        this.TipoFlujolist = allrecords
      },
      error => this.errorMessage = <any>error
    );

  }

  onguardarNuevo(): void {

    this.Form.markAllAsTouched();

    if(this.Form.valid){

      if(this.ID){

        const { txtNombre, txtDescripcion, cbxTipoFlujo , txtNivel } = this.Form.value;

        const DataResponse : Response = {
          wkf03llave : Number(this.ID),
          wkf03nombre : String(txtNombre).toLowerCase().replace(/^\w/, (c) => c.toUpperCase()),
          wkf03descripcion: String(txtDescripcion).toLowerCase().replace(/^\w/, (c) => c.toUpperCase()),
          wkf02llave: cbxTipoFlujo.value,
          wkf03nivel1 : txtNivel,
          wkf03activo: 1,
          wkf02nombre:''
        }

        this.store.dispatch(new fromList.Update(DataResponse));

      } else {
      
        const { txtNombre, txtDescripcion, cbxTipoFlujo, txtNivel } = this.Form.value;

        this.loading$ = this.store.pipe(select(fromList.getLoading));

          const CreateRequest : Request = {
            wkf03nombre : String(txtNombre).toLowerCase().replace(/^\w/, (c) => c.toUpperCase()),
            wkf03descripcion: String(txtDescripcion).toLowerCase().replace(/^\w/, (c) => c.toUpperCase()),
            wkf02llave: cbxTipoFlujo.value,
            wkf03nivel1 : txtNivel,
          }

          
          this.store.dispatch(new fromList.Create(CreateRequest));

      }
    }
  }
}