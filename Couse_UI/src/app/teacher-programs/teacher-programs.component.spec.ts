import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TeacherProgramsComponent } from './teacher-programs.component';

describe('TeacherProgramsComponent', () => {
  let component: TeacherProgramsComponent;
  let fixture: ComponentFixture<TeacherProgramsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TeacherProgramsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TeacherProgramsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
