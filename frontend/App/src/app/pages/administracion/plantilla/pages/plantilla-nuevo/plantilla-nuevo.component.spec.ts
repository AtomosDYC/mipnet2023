import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PlantillaNuevoComponent } from './plantilla-nuevo.component';

describe('PlantillaNuevoComponent', () => {
  let component: PlantillaNuevoComponent;
  let fixture: ComponentFixture<PlantillaNuevoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PlantillaNuevoComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PlantillaNuevoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
