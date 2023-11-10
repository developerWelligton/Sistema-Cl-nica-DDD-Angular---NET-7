import { ComponentFixture, TestBed } from '@angular/core/testing';


describe('CreateConsultComponent', () => {
  let component: CreateBuyComponent;
  let fixture: ComponentFixture<CreateBuyComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [CreateBuyComponent]
    });
    fixture = TestBed.createComponent(CreateBuyComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
