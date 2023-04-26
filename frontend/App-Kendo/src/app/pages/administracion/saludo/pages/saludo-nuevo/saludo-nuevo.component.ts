import { Component, OnInit } from '@angular/core';

import { FormGroup, Validators, FormBuilder, FormControl } from '@angular/forms';

import { select, Store } from '@ngrx/store';
import { Observable } from 'rxjs';

import * as fromRoot from '../../../../../store';
import * as fromList from '../../store/save';
import { MessageService } from '@progress/kendo-angular-l10n';
import { CustomMessagesService } from 'src/app/services/custom-messages.service';
import { IntlService } from '@progress/kendo-angular-intl';
import { SaludoResponse as Response } from '../../store/save';
import { SaludoCreateRequest as Request } from '../../store/save';
import { ActivatedRoute, Router } from '@angular/router';


@Component({
  selector: 'app-saludo-nuevo',
  templateUrl: './saludo-nuevo.component.html',
  styleUrls: ['./saludo-nuevo.component.scss']
})
export class SaludoNuevoComponent implements OnInit {

  loading$ !: Observable<boolean | null>;
  
  public Form: FormGroup;
  public ID: string | null;

  public customMsgService: CustomMessagesService;

  listdata :  Response  = {
    per02llave: 0,
    per02titulo: 'Titulo',
    per02orden: 0,
    per02activo: 0
  }

  constructor(private fb: FormBuilder,
    private store: Store<fromRoot.State>,
    public intl: IntlService, 
    public messages: MessageService,
    private _routeParams: ActivatedRoute,
    private router: Router
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
        this.store.pipe(select(fromList.getSaludobyid))
          .subscribe(data => {
            if(data){

                this.Form = new FormGroup({
                  txtTitulo: new FormControl( data.per02titulo , [Validators.required]),
                  txtOrden: new FormControl(data.per02orden, [Validators.required])
                });

            } else {
              
            }
          })
      }

      this.Form = new FormGroup({
        txtTitulo: new FormControl( this.listdata.per02titulo , [Validators.required]),
        txtOrden: new FormControl(this.listdata.per02orden, [Validators.required])
      });

    });
    
  }

  onguardarNuevo(): void {

    this.Form.markAllAsTouched();

    if(this.Form.valid){

      if(this.ID){

        const { txtTitulo, txtOrden } = this.Form.value;

        const DataResponse : Response = {
          per02llave : Number(this.ID),
          per02titulo : txtTitulo,
          per02orden: Number(txtOrden),
          per02activo : 0
        }

        this.store.dispatch(new fromList.Update(DataResponse));

      } else {
      
        const { txtTitulo, txtOrden } = this.Form.value;

        this.loading$ = this.store.pipe(select(fromList.getLoading));

          const CreateRequest : Request = {
            per02titulo : txtTitulo,
            per02orden: Number(txtOrden),
          }

          
          this.store.dispatch(new fromList.Create(CreateRequest));

      }
    }
  }
}