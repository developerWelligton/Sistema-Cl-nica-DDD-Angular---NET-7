import { ComponentFixture, TestBed } from '@angular/core/testing';

import { StockProductsTableComponent } from './stock-products-table.component';

describe('StockProductsTableComponent', () => {
  let component: StockProductsTableComponent;
  let fixture: ComponentFixture<StockProductsTableComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [StockProductsTableComponent]
    });
    fixture = TestBed.createComponent(StockProductsTableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
