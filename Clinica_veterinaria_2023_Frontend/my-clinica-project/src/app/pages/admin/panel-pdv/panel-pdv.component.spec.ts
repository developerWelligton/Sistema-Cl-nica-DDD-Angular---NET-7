import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PanelPdvComponent } from './panel-pdv.component';

describe('CreateConsultComponent', () => {
  let component: PanelPdvComponent;
  let fixture: ComponentFixture<PanelPdvComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [PanelPdvComponent]
    });
    fixture = TestBed.createComponent(PanelPdvComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
