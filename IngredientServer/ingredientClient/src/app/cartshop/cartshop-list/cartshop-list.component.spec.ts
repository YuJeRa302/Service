import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CartshopListComponent } from './cartshop-list.component';

describe('CartshopListComponent', () => {
  let component: CartshopListComponent;
  let fixture: ComponentFixture<CartshopListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CartshopListComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CartshopListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
