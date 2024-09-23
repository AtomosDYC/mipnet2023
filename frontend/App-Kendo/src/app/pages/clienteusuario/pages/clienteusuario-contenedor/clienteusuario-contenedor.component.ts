import { Component, OnInit } from '@angular/core';
import {  ActivatedRoute, UrlSegment } from '@angular/router';

@Component({
  selector: 'app-clienteusuario-contenedor',
  templateUrl: './clienteusuario-contenedor.component.html',
  styleUrls: ['./clienteusuario-contenedor.component.scss']
})
export class ClienteusuarioContenedorComponent implements OnInit {

  public selectedItem: any;

  constructor(
    private router: ActivatedRoute
  ) { }

  ngOnInit(): void {

    this.router.parent?.url.subscribe(path =>{
      const url: UrlSegment[] = path.map(path =>{ return path })

      this.selectedItem = url[0]!.path;
    });
  }

}
