import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateEstoqueComponent } from './create-estoque.component';

describe('CreateConsultComponent', () => {
  let component: CreateEstoqueComponent;
  let fixture: ComponentFixture<CreateEstoqueComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [CreateEstoqueComponent]
    });
    fixture = TestBed.createComponent(CreateEstoqueComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
