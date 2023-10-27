import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TreeViewUnspscComponent } from './tree-view-unspsc.component';

describe('TreeViewUnspscComponent', () => {
  let component: TreeViewUnspscComponent;
  let fixture: ComponentFixture<TreeViewUnspscComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [TreeViewUnspscComponent]
    });
    fixture = TestBed.createComponent(TreeViewUnspscComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
