import { ComponentFixture, TestBed } from '@angular/core/testing';

import { StockListTableComponent } from './stock-table.component';

describe('StockListTableComponent', () => {
  let component: StockListTableComponent;
  let fixture: ComponentFixture<StockListTableComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [StockListTableComponent]
    });
    fixture = TestBed.createComponent(StockListTableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
