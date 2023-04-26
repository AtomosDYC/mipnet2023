import { Component, OnInit } from '@angular/core';

import { FormGroup, Validators, FormBuilder, FormControl } from '@angular/forms';

import { select, Store } from '@ngrx/store';
import { Observable } from 'rxjs';

import * as fromRoot from '../../../../../store';
import * as fromList from '../../store/save';
import { MessageService } from '@progress/kendo-angular-l10n';
import { CustomMessagesService } from 'src/app/services/custom-messages.service';
import { IntlService } from '@progress/kendo-angular-intl';
import { ComunaResponse as Response } from '../../store/save';
import { ComunaCreateRequest as Request } from '../../store/save';
import { ActivatedRoute, Router } from '@angular/router';

import { FillComboService } from '../../../../../services/fill-combo.service';
import { SetSelect, GetSelect } from '../../../../../models/backend/getselect/index';


@Component({
  selector: 'app-comuna-nuevo',
  templateUrl: './comuna-nuevo.component.html',
  styleUrls: ['./comuna-nuevo.component.scss']
})
export class ComunaNuevoComponent implements OnInit {

  loading$ !: Observable<boolean | null>;
  
  public Form: FormGroup;
  public ID: string | null;
  private _fillcomboservices;

  Regionlist :Observable<GetSelect[] | null>;
  errorMessage: any;

  setRegion: SetSelect = {
    tablename : 'region'
  }

  public customMsgService: CustomMessagesService;

  listdata :  Response  = {
    sist03llave: 0,
    sist03activo: 0,
    sist03nombre: '',
    sist03descripcion: '',
    sist03capital: 0,
    sist04llave: 0,
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
        this.store.pipe(select(fromList.getComunabyid))
          .subscribe(data => {
            if(data){

              const capital = data.sist03capital ? true : false

                this.Form = new FormGroup({
                  txtNombre: new FormControl( data.sist03nombre , [Validators.required]),
                  txtDescripcion: new FormControl(data.sist03descripcion, [Validators.required]),
                  cbxRegion: new FormControl({ text: data.sist04nombre, value: data.sist04llave }, [Validators.required]),
                  chxEscapital: new FormControl(capital),
                });

            } else {
              
            }
          })
      }

      this.Form = new FormGroup({
        txtNombre: new FormControl( this.listdata.sist03nombre , [Validators.required]),
        txtDescripcion: new FormControl(this.listdata.sist03descripcion, [Validators.required]),
        cbxRegion: new FormControl({ text: this.listdata.sist04nombre, value: this.listdata.sist04llave }, [Validators.required]),
        chxEscapital: new FormControl(this.listdata.sist03activo),
      });

    });
    
  }

  onLoadcbx():void {

    this._fillcomboservices.GetAllSelect(this.setRegion).subscribe(
      allrecords => {
        this.Regionlist = allrecords
      },
      error => this.errorMessage = <any>error
    );

  }

  onguardarNuevo(): void {

    this.Form.markAllAsTouched();

    if(this.Form.valid){

      if(this.ID){

        const { txtNombre, txtDescripcion, cbxRegion , chxEscapital } = this.Form.value;

        const capital = chxEscapital ? 1 : 0


        const DataResponse : Response = {
          sist03llave : Number(this.ID),
          sist03nombre : String(txtNombre).toLowerCase().replace(/^\w/, (c) => c.toUpperCase()),
          sist03descripcion: String(txtDescripcion).toLowerCase().replace(/^\w/, (c) => c.toUpperCase()),
          sist04llave: cbxRegion.value,
          sist03capital : capital,
          sist03activo: 1
        }

        this.store.dispatch(new fromList.Update(DataResponse));

      } else {
      
        const { txtNombre, txtDescripcion, cbxRegion, chxEscapital } = this.Form.value;

        const capital = chxEscapital ? 1 : 0

        this.loading$ = this.store.pipe(select(fromList.getLoading));

          const CreateRequest : Request = {
            sist03nombre : String(txtNombre).toLowerCase().replace(/^\w/, (c) => c.toUpperCase()),
            sist03descripcion: String(txtDescripcion).toLowerCase().replace(/^\w/, (c) => c.toUpperCase()),
            sist04llave: cbxRegion.value,
            sist03capital : capital,
          }

          
          this.store.dispatch(new fromList.Create(CreateRequest));

      }
    }
  }
}