import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ListProviderComponent } from './list-provider.component';

describe('CreateConsultComponent', () => {
  let component: ListProviderComponent;
  let fixture: ComponentFixture<ListProviderComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ListProviderComponent]
    });
    fixture = TestBed.createComponent(ListProviderComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
