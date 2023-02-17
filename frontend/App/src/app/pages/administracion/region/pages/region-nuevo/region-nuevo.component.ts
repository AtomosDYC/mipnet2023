import { Component, OnInit } from '@angular/core';

import { FormGroup, Validators, FormBuilder } from '@angular/forms';

import { select, Store } from '@ngrx/store';
import { Observable } from 'rxjs';

import * as fromRoot from '../../../../../store';
import * as fromList from '../../store/save';

@Component({
  selector: 'app-region-nuevo',
  templateUrl: './region-nuevo.component.html',
  styleUrls: ['./region-nuevo.component.scss']
})
export class RegionNuevoComponent implements OnInit {
  loading$ !: Observable<boolean | null>;
  public regionForm: FormGroup;

  constructor(private fb: FormBuilder,
    private store: Store<fromRoot.State>)
  {

  }

  ngOnInit(): void {
    this.regionForm = this.fb.group({
      nombre: ['', Validators.required ],
      descripcion: ['', Validators.required ],
      orden: ['', Validators.required ],
    });
  }

  onguardarNuevo(): void {


    console.log('dentro del onguardar');

    const { nombre, descripcion, orden } = this.regionForm.value;



    this.loading$ = this.store.pipe(select(fromList.getLoading));

        const regionCreateRequest : fromList.RegionCreateRequest = {
          sist04nombre : nombre,
          sist04descripcion : descripcion,
          sist04orden: Number(orden),
        }

        console.log(`create onguardar ${regionCreateRequest}`);

        this.store.dispatch(new fromList.Create(regionCreateRequest));

  }

}
