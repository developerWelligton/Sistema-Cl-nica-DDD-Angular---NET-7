import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UnspscTableComponent } from './unspsc-table.component';

describe('UnspscTableComponent', () => {
  let component: UnspscTableComponent;
  let fixture: ComponentFixture<UnspscTableComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [UnspscTableComponent]
    });
    fixture = TestBed.createComponent(UnspscTableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
