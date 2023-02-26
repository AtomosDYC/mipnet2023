import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NivelflujoNuevoComponent } from './nivelflujo-nuevo.component';

describe('NivelflujoNuevoComponent', () => {
  let component: NivelflujoNuevoComponent;
  let fixture: ComponentFixture<NivelflujoNuevoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ NivelflujoNuevoComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(NivelflujoNuevoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
