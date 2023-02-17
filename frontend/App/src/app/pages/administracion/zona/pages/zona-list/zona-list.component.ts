import { Component, OnInit } from '@angular/core';

import * as fromRoot from '../../../../../store';
import { select, Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import * as fromList from '../../store/save';
import { ZonaResponse } from '../../store/save';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-zona-list',
  templateUrl: './zona-list.component.html',
  styleUrls: ['./zona-list.component.scss']
})
export class ZonaListComponent implements OnInit {

  Zonas$! : Observable<ZonaResponse[] | null>;
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
      key: 'sist02nombre',
      label: 'Nombre',
      _style: { width: '40%' }
    },
    {
      key: 'sist02descripcion',
      label: 'Descripción',
      _style: { width: '40%' }
    },
    {
      key: 'sist02activo',
      label:'',
      _style: { width: '80px' },
      filter: false,
      sorter: false
    },

  ];

  constructor(
    private store: Store<fromRoot.State>,
    private _Route: Router,
    ) {

    }

  ngOnInit(): void {

    console.log('list');
    this.store.dispatch(new fromList.Read());
    this.loading$ = this.store.pipe(select(fromList.getLoading))!;
    this.Zonas$ = this.store.pipe(select(fromList.getZonas));
    console.log('zonas');
  }

  checkSelected = (selectedItems: any) => {

    this.selectedItems = [].concat(selectedItems);

  };

  onEditar(id: number): void {
    console.log('dentro del click editar');
    this._Route.navigate(['/dashboard/zona/edit/', id.toString()]);
  }

  onEliminar(id: number, estado : number): void {

    if(estado == 0){
      if (confirm("Esta seguro de eliminar esta Zona?"))
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


  OndisableZona():void {

    if(this.selectedItems){
      this.store.dispatch(new fromList.Desactivate(this.selectedItems!));
    }

  }

  onactivateZona():void {

    if(this.selectedItems){
      this.store.dispatch(new fromList.Activate(this.selectedItems!));
    }

  }

}
