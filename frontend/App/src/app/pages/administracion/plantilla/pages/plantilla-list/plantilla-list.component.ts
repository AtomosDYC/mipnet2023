import { Component, OnInit } from '@angular/core';
import * as fromRoot from '../../../../../store';
import { select, Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import * as fromList from '../../store/save';
import { PlantillaResponse } from '../../store/save';

import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-plantilla-list',
  templateUrl: './plantilla-list.component.html',
  styleUrls: ['./plantilla-list.component.scss']
})
export class PlantillaListComponent implements OnInit {

  plantillas$! : Observable<PlantillaResponse[] | null>;
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
      key: 'prf03nombre',
      label: 'Nombre',
      _style: { width: '40%' }
    },
    {
      key: 'prf03descripcion',
      label: 'descripción',
      _style: { width: '40%' }
    },
    {
      key: 'prf03activo',
      label:'',
      _style: { width: '80px' },
      filter: false,
      sorter: false
    },

  ];

  constructor(
    private store: Store<fromRoot.State>,
    private _Route: Router,
    private route: ActivatedRoute,
    ) {

    }

  ngOnInit(): void {
    this.store.dispatch(new fromList.Read());
    this.loading$ = this.store.pipe(select(fromList.getLoading))!;
    this.plantillas$ = this.store.pipe(select(fromList.getPlantillas));
  }

  checkSelected = (selectedItems: any) => {

    this.selectedItems = [].concat(selectedItems);

  };

  onEditar(id: number): void {
    console.log('dentro del click editar');
    this._Route.navigate(['/dashboard/plantilla/edit/', id.toString()]);
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


  OndisablePlantilla():void {

    console.log('ondiableplantilla');

    if(this.selectedItems){

      console.log(this.selectedItems);

      this.store.dispatch(new fromList.Desactivate(this.selectedItems!));
    }

  }

  onactivatePlantilla():void {

    if(this.selectedItems){
      this.store.dispatch(new fromList.Activate(this.selectedItems!));
    }

  }


}
