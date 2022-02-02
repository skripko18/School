import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TeacherCreatecourseComponent } from './teacher-createcourse.component';

describe('TeacherCreatecourseComponent', () => {
  let component: TeacherCreatecourseComponent;
  let fixture: ComponentFixture<TeacherCreatecourseComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TeacherCreatecourseComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TeacherCreatecourseComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
