import { Component, OnInit } from '@angular/core';
import { Observable, take } from 'rxjs';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Store, select } from '@ngrx/store';

import * as fromRoot from '../../../../../store';
import * as fromList from '../../store/save';
import { ActivatedRoute, Router } from '@angular/router';
import { RegionesResponse, RegionResponse } from '../../store/save';

@Component({
  selector: 'app-region-edit',
  templateUrl: './region-edit.component.html',
  styleUrls: ['./region-edit.component.scss']
})
export class RegionEditComponent implements OnInit {

  regionModel$ !: Observable<RegionResponse | null>;
  loading$ !: Observable<boolean | null>;
  public regionForm: FormGroup;
  RegionID: string | null;

  region :  RegionResponse  = {
    sist04llave: 0,
    sist04nombre: '',
    sist04descripcion: '',
    sist04orden: 0,
    sist04activo: 0
  }

  constructor(private fb: FormBuilder,
    private store: Store<fromRoot.State>,
    private _routeParams: ActivatedRoute,
    private router: Router,)
  {

  }

  ngOnInit(): void {

    this.regionForm = this.fb.group({
      nombre: ['', Validators.required ],
      descripcion: ['', Validators.required ],
      orden: ['', Validators.required ],
    });

    this._routeParams.paramMap.subscribe(params => {
      this.RegionID = (params.get('id'));

      if(this.RegionID) {
        this.store.dispatch(new fromList.Getbyid(this.RegionID));

      } else {
        this.router.navigate((['/dashboard/region/list/']));
      }
    })

    this.loading$ = this.store.pipe(select(fromList.getLoading))!;
    this.store.pipe(select(fromList.getRegionbyid))
              .subscribe(data => {
                if(data){
                 this.regionForm.setValue({
                    nombre: data.sist04nombre,
                    descripcion: data.sist04descripcion,
                    orden: data.sist04orden
                  })
                } else {
                  this.router.navigate((['/dashboard/region/list/']));
                }
              })




  }


  onguardarNuevo(): void {

    console.log('dentro del onguardar');

    const { nombre, descripcion, orden } = this.regionForm.value;

    this.loading$ = this.store.pipe(select(fromList.getLoading));

        const regionResponse : fromList.RegionResponse = {
          sist04llave : Number(this.RegionID),
          sist04nombre : nombre,
          sist04descripcion : descripcion,
          sist04orden: Number(orden),
          sist04activo : 0
        }

        console.log(`create onguardar ${regionResponse}`);

        this.store.dispatch(new fromList.Update(regionResponse));

  }

}
