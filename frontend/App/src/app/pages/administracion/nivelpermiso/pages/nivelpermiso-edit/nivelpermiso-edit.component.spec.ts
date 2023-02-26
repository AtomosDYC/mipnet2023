import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NivelpermisoEditComponent } from './nivelpermiso-edit.component';

describe('NivelpermisoEditComponent', () => {
  let component: NivelpermisoEditComponent;
  let fixture: ComponentFixture<NivelpermisoEditComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ NivelpermisoEditComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(NivelpermisoEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
