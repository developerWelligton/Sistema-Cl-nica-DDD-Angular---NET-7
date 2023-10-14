import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UserProductComponent } from './product-table.component';

describe('UserTableComponent', () => {
  let component: UserProductComponent;
  let fixture: ComponentFixture<UserProductComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [UserProductComponent]
    });
    fixture = TestBed.createComponent(UserProductComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
