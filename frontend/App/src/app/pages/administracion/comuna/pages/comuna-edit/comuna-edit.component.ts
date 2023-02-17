import { Component, OnInit } from '@angular/core';
import { Observable, take } from 'rxjs';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Store, select } from '@ngrx/store';

import * as fromRoot from '../../../../../store';
import * as fromList from '../../store/save';
import { ActivatedRoute, Router } from '@angular/router';
import {  ComunaResponse } from '../../store/save';
import { GetSelect, SetSelect } from 'app/models/backend/getselect';
import { FillComboService } from '../../../../../services/fill-combo.service';

@Component({
  selector: 'app-comuna-edit',
  templateUrl: './comuna-edit.component.html',
  styleUrls: ['./comuna-edit.component.scss']
})
export class ComunaEditComponent implements OnInit {

  ComunaModel$ !: Observable<ComunaResponse | null>;
  loading$ !: Observable<boolean | null>;
  public comunaForm: FormGroup;
  ComunaID: string | null;

  comuna :  ComunaResponse  = {
    sist03llave: 0,
    sist03nombre: '',
    sist03descripcion: '',
    sist04llave: 0,
    sist03capital: 0,
    sist03activo: 0,
    sist04nombre:''
  }

  private _fillcomboservices;
  regionList :GetSelect[];
  setRegion: SetSelect = {
    tablename : 'region'
  }
  errorMessage: any;

  constructor
  (
    private fb: FormBuilder,
    private store: Store<fromRoot.State>,
    private _routeParams: ActivatedRoute,
    private router: Router,
    FillComboService: FillComboService,
  )
  {
    this._fillcomboservices = FillComboService;
  }

  ngOnInit(): void {

    this.comunaForm = this.fb.group({
      nombre: ['', Validators.required ],
      descripcion: ['', Validators.required ],
      region: ['Seleccione Región', Validators.required ],
      escapital: [''],
    });

    this._fillcomboservices.GetAllSelect(this.setRegion).subscribe(
      allrecords => {
        this.regionList = allrecords
      },
      error => this.errorMessage = <any>error
    );



    this._routeParams.paramMap.subscribe(params => {
      this.ComunaID = (params.get('id'));

      if(this.ComunaID) {
        this.store.dispatch(new fromList.Getbyid(this.ComunaID));

      } else {
        this.router.navigate((['/dashboard/comuna/list/']));
      }
    })

    this.loading$ = this.store.pipe(select(fromList.getLoading))!;
    this.store.pipe(select(fromList.getComunabyid))
              .subscribe(data => {
                if(data){
                 this.comunaForm.setValue({
                    nombre: data.sist03nombre,
                    descripcion: data.sist03descripcion,
                    region: data.sist04llave,
                    escapital: data.sist03capital,
                  })
                } else {
                  this.router.navigate((['/dashboard/comuna/list/']));
                }
              })




  }


  onguardarNuevo(): void {

    console.log('dentro del onguardar');

    const { nombre, descripcion, region, escapital  } = this.comunaForm.value;
    const capital = escapital ? 1 : 0

    console.log(nombre, descripcion, region, escapital);

    this.loading$ = this.store.pipe(select(fromList.getLoading));

        const comunaResponse : fromList.ComunaResponse = {
          sist03llave : Number(this.ComunaID),
          sist03nombre : nombre,
          sist03descripcion : descripcion,
          sist04llave: region,
          sist03capital : capital
        }



        console.log(`create onguardar ${comunaResponse}`);

        this.store.dispatch(new fromList.Update(comunaResponse));

  }

}
