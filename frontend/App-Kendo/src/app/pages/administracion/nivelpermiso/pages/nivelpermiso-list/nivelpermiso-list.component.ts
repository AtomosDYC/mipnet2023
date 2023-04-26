import { Component, OnInit } from '@angular/core';

import { DomSanitizer } from '@angular/platform-browser';

import * as fromRoot from '../../../../../store';
import { select, Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { filter, map } from 'rxjs/operators';

import * as fromList from '../../store/save';
import { NivelPermisoResponse as Response } from '../../store/save';
import { Router, ActivatedRoute } from '@angular/router';

import { IntlService } from '@progress/kendo-angular-intl';
import { MessageService } from '@progress/kendo-angular-l10n';
import { CustomMessagesService } from 'src/app/services/custom-messages.service';
import {DataStateChangeEvent } from "@progress/kendo-angular-grid";

@Component({
  selector: 'app-nivelpermiso-list',
  templateUrl: './nivelpermiso-list.component.html',
  styleUrls: ['./nivelpermiso-list.component.scss']
})
export class NivelpermisoListComponent implements OnInit {

  data$! : Observable<Response[] | null>;
  listadatos : any;
  loading$ : Observable<boolean | null> ;
  public selectedItems: any;
  public mySelection: string[] = [];
  public filtro:string = '';

  public customMsgService: CustomMessagesService;

  constructor(
    private store: Store<fromRoot.State>,
    private _Route: Router,
    public intl: IntlService, 
    public messages: MessageService
    ) {
      this.customMsgService = this.messages as CustomMessagesService;
    }

  public onFilter(e:DataStateChangeEvent): void {
    this.filtro = e.toString();
    this.loadData();
  }

  public loadData(): Observable<Response[] | null> {

    const datafull =  this.store.pipe(select(fromList.getNivelPermisos));

    if(this.filtro ){    
      const datafullfilter = datafull.pipe(
        map((data : Response[] | null) => data!.filter(valor => valor.wkf03nombre!.toLowerCase().includes(this.filtro.toLowerCase()) 
        || valor.wkf05nombre!.toLowerCase().includes(this.filtro.toLowerCase())))
        )
      return datafullfilter;

    } else {
      return datafull;
    }


  }

  ngOnInit(): void {
    this.store.dispatch(new fromList.Read());
    this.loading$ = this.store.pipe(select(fromList.getLoading))!;
    this.loadData();
  }

  OnNuevo(){
    this._Route.navigate(['/dashboard/nivelpermiso/nuevo/']);
  }

  OnEditar(id: number){
    this._Route.navigate(['/dashboard/nivelpermiso/edit/', id.toString()]);
  }

  OnEliminar(id: number){
      if (confirm("Esta seguro de eliminar este nivel de permiso?"))
      {
        this.store.dispatch(new fromList.Delete(id.toString()));
      }
    
  }

  

}
