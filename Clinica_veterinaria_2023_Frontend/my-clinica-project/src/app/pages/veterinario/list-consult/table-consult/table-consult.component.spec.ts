import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TableConsultComponent } from './table-consult.component';

describe('UserTableComponent', () => {
  let component: TableConsultComponent;
  let fixture: ComponentFixture<TableConsultComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [TableConsultComponent]
    });
    fixture = TestBed.createComponent(TableConsultComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
