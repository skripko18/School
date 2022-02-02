import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { UserMyCourseComponent } from './user-mycourse.component';

describe('UserMyCourseComponent', () => {
  let component: UserMyCourseComponent;
  let fixture: ComponentFixture<UserMyCourseComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [UserMyCourseComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(UserMyCourseComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
