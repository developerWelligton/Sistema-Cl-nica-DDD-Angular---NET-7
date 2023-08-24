import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ListConsultComponent } from './list-consult.component';

describe('CreateConsultComponent', () => {
  let component: ListConsultComponent;
  let fixture: ComponentFixture<ListConsultComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ListConsultComponent]
    });
    fixture = TestBed.createComponent(ListConsultComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
