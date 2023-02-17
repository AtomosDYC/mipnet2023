import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EstadodanioNuevoComponent } from './estadodanio-nuevo.component';

describe('EstadodanioNuevoComponent', () => {
  let component: EstadodanioNuevoComponent;
  let fixture: ComponentFixture<EstadodanioNuevoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EstadodanioNuevoComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EstadodanioNuevoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
