import { Component, OnInit } from '@angular/core';

import { DomSanitizer } from '@angular/platform-browser';

import * as fromRoot from '../../../../../store';
import { select, Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import * as fromList from '../../store/save';
import { RegionResponse } from '../../store/save';
import { Router, ActivatedRoute } from '@angular/router';


@Component({
  selector: 'app-region-list',
  templateUrl: './region-list.component.html',
  styleUrls: ['./region-list.component.scss']
})
export class RegionListComponent implements OnInit {

  regiones$! : Observable<RegionResponse[] | null>;
  listadatos : any;
  loading$! : Observable<boolean | null>;
  public selectedItems: any;

  loadingData = false;

  columns = [

    {
      key: 'show',
      label: '',
      _style: { width: '7%' },
      filter: false,
      sorter: false
    },
    {
      key: 'sist04nombre',
      label: 'Nombre',
      _style: { width: '40%' }
    },
    {
      key: 'sist04descripcion',
      label: 'descripción',
      _style: { width: '40%' }
    },
    {
      key: 'sist04orden',
      label: 'orden',
      _style: { width: '40%' }
    },
    {
      key: 'sist04activo',
      label:'',
      _style: { width: '80px' },
      filter: false,
      sorter: false
    },

  ];

  constructor(
    private store: Store<fromRoot.State>,
    private sanitizer: DomSanitizer,
    private _Route: Router,
    private route: ActivatedRoute,
    ) {

    }

  ngOnInit(): void {
    this.store.dispatch(new fromList.Read());
    this.loading$ = this.store.pipe(select(fromList.getLoading))!;
    this.regiones$ = this.store.pipe(select(fromList.getRegiones));
  }

  checkSelected = (selectedItems: any) => {

    this.selectedItems = [].concat(selectedItems);

  };

  onEditar(id: number): void {
    this._Route.navigate(['/dashboard/region/edit/', id.toString()]);
  }

  onEliminar(id: number, estado : number): void {

    if(estado == 0){
      if (confirm("Esta seguro de eliminar esta región?"))
      {
        this.store.dispatch(new fromList.Delete(id.toString()));
      }
    } else {
      this.store.dispatch(new fromList.Delete(id.toString()));
    }

  }

  getBadge(status: number) : string {
    switch (status) {
      case 1:
        return 'success';
      case 0:
        return 'danger';
      default:
          return 'success';
    }
  }

  getBadgeestado(status: number) : string {
    switch (status) {
      case 1:
        return 'Activo';
      case 0:
        return 'Desactivado';
      default:
        return 'Activo';
    }
  }


  OndisableRegion():void {

    console.log('ondiableregion');

    if(this.selectedItems){

      console.log(this.selectedItems);

      this.store.dispatch(new fromList.Desactivate(this.selectedItems!));
    }

  }

  onactivateRegion():void {

    if(this.selectedItems){
      this.store.dispatch(new fromList.Activate(this.selectedItems!));
    }

  }


}
