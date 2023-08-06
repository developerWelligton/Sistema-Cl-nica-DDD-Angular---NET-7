import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SearchConsultComponent } from './search-consult.component';

describe('SearchConsultComponent', () => {
  let component: SearchConsultComponent;
  let fixture: ComponentFixture<SearchConsultComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [SearchConsultComponent]
    });
    fixture = TestBed.createComponent(SearchConsultComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
