import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NotfoundConsultComponent } from './notfound-consult.component';

describe('NotfoundConsultComponent', () => {
  let component: NotfoundConsultComponent;
  let fixture: ComponentFixture<NotfoundConsultComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [NotfoundConsultComponent]
    });
    fixture = TestBed.createComponent(NotfoundConsultComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
