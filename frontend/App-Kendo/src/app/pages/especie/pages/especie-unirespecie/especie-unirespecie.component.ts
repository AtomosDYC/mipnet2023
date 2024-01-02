import { Component, OnInit } from '@angular/core';

import { DomSanitizer } from '@angular/platform-browser';

import * as fromRoot from '../../../../store';
import { select, Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { filter, map } from 'rxjs/operators';

import * as fromList from './store/save';
import { UnirEspecieResponse as Response, UnirEspecieRequest as Request } from './store/save';
import { Router, ActivatedRoute } from '@angular/router';

import { IntlService } from '@progress/kendo-angular-intl';
import { MessageService } from '@progress/kendo-angular-l10n';
import { CustomMessagesService } from 'src/app/services/custom-messages.service';

import { FormGroup, FormBuilder, FormControl, Validators } from '@angular/forms';


import { FillComboService } from '../../../../services/fill-combo.service';
import { SetSelect, GetSelect } from '../../../../models/backend/getselect/index';

@Component({
  selector: 'app-especie-unirespecie',
  templateUrl: './especie-unirespecie.component.html',
  styleUrls: ['./especie-unirespecie.component.scss']
})
export class EspecieUnirespecieComponent implements OnInit {

  data$! : Observable<Response[] | null>;
  success$ !: Observable<boolean | null>;
  Error$ !: Observable<string | null>;

  listadatos : any;
  loading$! : Observable<boolean | null>;
  Unirespecielist: any;

  public verNuevo: boolean = false;
  public ID: string | null;
  private _fillcomboservices;

  public FormUnirEspcie: FormGroup = new FormGroup({
    cbxUnirespecie: new FormControl( null , [Validators.required])
  });

  public selectedItems: any;
  public mySelection: string[] = [];
  public filtro:string = '';
  errorMessage: any;

  setUnirespecie: SetSelect = {
    tablename : 'UnirEspecie',
    prm1 : ''
  }

  public customMsgService: CustomMessagesService;

  constructor(
    private fb: FormBuilder,
    private store: Store<fromRoot.State>,
    private _routeParams: ActivatedRoute,
    private _Route: Router,
    public intl: IntlService, 
    public messages: MessageService,
    FillComboService: FillComboService,
    ) {
      this.customMsgService = this.messages as CustomMessagesService;
      this._fillcomboservices = FillComboService;
    }

  onLoadcbx():void {

    this.setUnirespecie.prm1 = String(this.ID);

    this._fillcomboservices.GetAllSelect(this.setUnirespecie).subscribe(
      allrecords => {
        this.Unirespecielist = allrecords
      },
      error => this.errorMessage = <any>error
    );
  }


  ngOnInit(): void {

    

    this._routeParams.paramMap.subscribe(params => {
      this.ID = (params.get('id'));

      if(this.ID) {

        this.onLoadcbx();



        this.store.dispatch(new fromList.GetUnirespeciebyid(this.ID));
        this.loading$ = this.store.pipe(select(fromList.getLoading))!;
        this.data$ =  this.store.pipe(select(fromList.getUnirEspecies));
  

        this.FormUnirEspcie = new FormGroup({
          cbxUnirespecie: new FormControl( null , [Validators.required])
        });

      }
    });
  }

  OnNuevo(){

    this.verNuevo = true;

  }

  onContinuar(){
    if(this.ID) {
      this._Route.navigate(['/dashboard/especies/especies/tiposdatos', this.ID]);
    }

  }

  OnCancelar(){

    this.verNuevo = false;
    
  }

  onguardarUnirespecie(){

    this.FormUnirEspcie.markAllAsTouched();

    if(this.FormUnirEspcie.valid){

      if(this.ID){

        const { cbxUnirespecie } = this.FormUnirEspcie.value;

        this.loading$ = this.store.pipe(select(fromList.getLoading));

          const UpdateRequest : Request = {
            
            esp03llave: Number(this.ID),
            esp03llaveunion: cbxUnirespecie.value

          }

          this.store.dispatch(new fromList.CreateUnirespecie(UpdateRequest));

          this.success$ = this.store.pipe(select(fromList.getSuccess));

          this.success$.subscribe((success) => { 
            if(success) {

              this.verNuevo = false;
              this.onLoadcbx();


            }
          })

      }
    }
  }
  
  OnEliminarUnirEspecie(id: number){
        this.store.dispatch(new fromList.DeleteUnirEspecie(id.toString()));
    
  }
}
