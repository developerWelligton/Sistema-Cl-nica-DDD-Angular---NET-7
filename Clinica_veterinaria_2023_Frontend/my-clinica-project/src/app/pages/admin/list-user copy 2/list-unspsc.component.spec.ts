import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ListUnspscComponent } from './list-unspsc.component';

describe('CreateConsultComponent', () => {
  let component: ListUnspscComponent;
  let fixture: ComponentFixture<ListUnspscComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ListUnspscComponent]
    });
    fixture = TestBed.createComponent(ListUnspscComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
