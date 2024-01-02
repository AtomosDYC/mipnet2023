import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute, UrlSegment, UrlSerializer } from '@angular/router';
import { switchMap } from 'rxjs/operators';

@Component({
  selector: 'app-personas-contenedor',
  templateUrl: './personas-contenedor.component.html',
  styleUrls: ['./personas-contenedor.component.scss']
})
export class PersonasContenedorComponent implements OnInit {

  public selectedItem: any;

  constructor(
    private router: ActivatedRoute
  ) { }

  ngOnInit(): void {

    this.router.parent?.url.subscribe(path =>{
      const url: UrlSegment[] = path.map(path =>{ return path })
      this.selectedItem = url[0]!.path;
    });

    //console.log('contenedor',this.selectedItem);
  }

}
