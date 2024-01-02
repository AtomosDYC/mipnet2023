import { Component, OnInit } from '@angular/core';

import { FormGroup, Validators, FormBuilder, FormControl } from '@angular/forms';

import { select, Store } from '@ngrx/store';
import { Observable } from 'rxjs';

import * as fromRoot from '../../../../../store';
import * as fromList from '../../store/save';
import { MessageService } from '@progress/kendo-angular-l10n';
import { CustomMessagesService } from 'src/app/services/custom-messages.service';
import { IntlService } from '@progress/kendo-angular-intl';
import { TemporadaBaseResponse as Response } from '../../store/save';
import { TemporadaBasesCreaterequest as Request } from '../../store/save';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-temporadabase-nuevo',
  templateUrl: './temporadabase-nuevo.component.html',
  styleUrls: ['./temporadabase-nuevo.component.scss']
})
export class TemporadabaseNuevoComponent implements OnInit {

  loading$ !: Observable<boolean | null>;
  
  public Form: FormGroup;
  public ID: string | null;

  public customMsgService: CustomMessagesService;

  listdata :  Response  = {
    temp02llave: 0,
    temp02nombre: '',
    temp02descripcion: '',
    temp02activo: 0,
    temp02predeterminada	: 0
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
        this.store.pipe(select(fromList.getTemporadaBasebyid))
          .subscribe(data => {
            if(data){

              const predeterminada = data.temp02predeterminada ? true : false

                this.Form = new FormGroup({
                  txtNombre: new FormControl( data.temp02nombre , [Validators.required]),
                  txtDescripcion: new FormControl(data.temp02descripcion, [Validators.required]),
                  chxPredeterminada: new FormControl(predeterminada)
                });

            } else {
              
            }
          })
      }



      this.Form = new FormGroup({
        txtNombre: new FormControl( this.listdata.temp02nombre , [Validators.required]),
        txtDescripcion: new FormControl(this.listdata.temp02descripcion, [Validators.required]),
        chxPredeterminada: new FormControl(null)
      });

    });
    
  }

  onguardarNuevo(): void {

    this.Form.markAllAsTouched();

    if(this.Form.valid){

      if(this.ID){

        const { txtNombre, txtDescripcion, chxPredeterminada } = this.Form.value;

        const predeterminada = chxPredeterminada ? 1 : 0

        const DataResponse : Response = {
          temp02llave : Number(this.ID),
          temp02nombre : String(txtNombre).toLowerCase().replace(/^\w/, (c) => c.toUpperCase()),
          temp02descripcion: String(txtDescripcion).toLowerCase().replace(/^\w/, (c) => c.toUpperCase()),
          temp02predeterminada: Number(predeterminada),
          temp02activo : 0
        }

        this.store.dispatch(new fromList.Update(DataResponse));

      } else {
      
        const { txtNombre, txtDescripcion, chxPredeterminada } = this.Form.value;

        const predeterminada = chxPredeterminada ? 1 : 0

        

        this.loading$ = this.store.pipe(select(fromList.getLoading));

          const CreateRequest : Request = {
            temp02nombre : String(txtNombre).toLowerCase().replace(/^\w/, (c) => c.toUpperCase()),
            temp02descripcion: String(txtDescripcion).toLowerCase().replace(/^\w/, (c) => c.toUpperCase()),
            temp02predeterminada: Number(predeterminada)
          }
        
          //console.log('predeterminada', CreateRequest );
          
          this.store.dispatch(new fromList.Create(CreateRequest));

      }
    }
  }

}
