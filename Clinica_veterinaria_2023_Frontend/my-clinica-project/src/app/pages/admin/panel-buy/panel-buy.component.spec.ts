import { ComponentFixture, TestBed } from '@angular/core/testing';
import { PanelBuyComponent } from './panel-buy.component';


describe('CreateConsultComponent', () => {
  let component: PanelBuyComponent;
  let fixture: ComponentFixture<PanelBuyComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [PanelBuyComponent]
    });
    fixture = TestBed.createComponent(PanelBuyComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
