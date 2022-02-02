import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminDirectionsComponent } from './admin-directions.component';

describe('AdminDirectionsComponent', () => {
  let component: AdminDirectionsComponent;
  let fixture: ComponentFixture<AdminDirectionsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AdminDirectionsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AdminDirectionsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
