import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TipopercomunicacionListComponent } from './tipopercomunicacion-list.component';

describe('TipopercomunicacionListComponent', () => {
  let component: TipopercomunicacionListComponent;
  let fixture: ComponentFixture<TipopercomunicacionListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TipopercomunicacionListComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(TipopercomunicacionListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
