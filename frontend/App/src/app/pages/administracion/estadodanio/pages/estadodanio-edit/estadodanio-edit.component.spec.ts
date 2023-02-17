import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EstadodanioEditComponent } from './estadodanio-edit.component';

describe('EstadodanioEditComponent', () => {
  let component: EstadodanioEditComponent;
  let fixture: ComponentFixture<EstadodanioEditComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EstadodanioEditComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EstadodanioEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
