import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TipopermisoEditComponent } from './tipopermiso-edit.component';

describe('TipopermisoEditComponent', () => {
  let component: TipopermisoEditComponent;
  let fixture: ComponentFixture<TipopermisoEditComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TipopermisoEditComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(TipopermisoEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
