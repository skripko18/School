import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TeacherCourseInfoComponent } from './teacher-course-info.component';

describe('TeacherCourseInfoComponent', () => {
  let component: TeacherCourseInfoComponent;
  let fixture: ComponentFixture<TeacherCourseInfoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [TeacherCourseInfoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TeacherCourseInfoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
