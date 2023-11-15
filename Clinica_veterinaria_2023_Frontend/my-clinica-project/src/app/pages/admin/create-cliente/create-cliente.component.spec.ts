import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateUnspscComponent } from './create-unspsc.component';

describe('CreateConsultComponent', () => {
  let component: CreateUnspscComponent;
  let fixture: ComponentFixture<CreateUnspscComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [CreateUnspscComponent]
    });
    fixture = TestBed.createComponent(CreateUnspscComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
