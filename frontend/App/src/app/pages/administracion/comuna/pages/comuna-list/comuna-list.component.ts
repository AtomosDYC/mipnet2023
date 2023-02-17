import { Component, OnInit } from '@angular/core';

import { DomSanitizer } from '@angular/platform-browser';

import * as fromRoot from '../../../../../store';
import { select, Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import * as fromList from '../../store/save';
import { ComunaResponse } from '../../store/save';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-comuna-list',
  templateUrl: './comuna-list.component.html',
  styleUrls: ['./comuna-list.component.scss']
})
export class ComunaListComponent implements OnInit {

  Comunas$! : Observable<ComunaResponse[] | null>;
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
      key: 'sist03llave',
      label: 'Llave',
      _style: { width: '10%' }
    },
    {
      key: 'sist03nombre',
      label: 'Nombre',
      _style: { width: '20%' }
    },
    {
      key: 'sist03descripcion',
      label: 'descripción',
      _style: { width: '30%' }
    },
    {
      key: 'sist04nombre',
      label: 'Región',
      _style: { width: '30%' }
    },
    {
      key: 'sist03activo',
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
    this.Comunas$ = this.store.pipe(select(fromList.getComunas));
  }

  checkSelected = (selectedItems: any) => {

    this.selectedItems = [].concat(selectedItems);

  };

  onEditar(id: number): void {
    console.log('dentro del click editar');
    this._Route.navigate(['/dashboard/comuna/edit/', id.toString()]);
  }

  onEliminar(id: number, estado : number): void {

    if(estado == 0){
      if (confirm("Esta seguro de eliminar esta comuna?"))
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


  OndisableComuna():void {

    console.log('ondiableComuna');

    if(this.selectedItems){

      console.log(this.selectedItems);

      this.store.dispatch(new fromList.Desactivate(this.selectedItems!));
    }

  }

  onactivateComuna():void {

    if(this.selectedItems){
      this.store.dispatch(new fromList.Activate(this.selectedItems!));
    }

  }

}
