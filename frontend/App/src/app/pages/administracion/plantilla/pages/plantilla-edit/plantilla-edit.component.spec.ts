import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PlantillaEditComponent } from './plantilla-edit.component';

describe('PlantillaEditComponent', () => {
  let component: PlantillaEditComponent;
  let fixture: ComponentFixture<PlantillaEditComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PlantillaEditComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PlantillaEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
