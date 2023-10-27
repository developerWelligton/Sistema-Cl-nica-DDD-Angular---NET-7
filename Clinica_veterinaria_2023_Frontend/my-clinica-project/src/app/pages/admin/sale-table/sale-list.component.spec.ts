import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SaleTableComponent } from './sale-list.component';

describe('SaleTableComponent', () => {
  let component: SaleTableComponent;
  let fixture: ComponentFixture<SaleTableComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [SaleTableComponent]
    });
    fixture = TestBed.createComponent(SaleTableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
