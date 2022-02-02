import { Component, OnInit } from '@angular/core';
import { MatDialog, MatSnackBar, PageEvent } from '@angular/material';
import { Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { BehaviorSubject, Observable } from 'rxjs';
import { Direction } from '../admin-directions/models/direction.model';
import { AdminService } from '../shared/admin.service';
import { TeacherService } from '../shared/teacher.service';
import { Course } from '../teacher-course/models/course.model';
import { LearnerCourse } from './models/learnercourse.model';

@Component({
  selector: 'app-user-course',
  templateUrl: './user-course.component.html',
  styleUrls: ['./user-course.component.css']
})
export class UserCourseComponent implements OnInit {
  private tempResultSubject: BehaviorSubject<Course[]> = new BehaviorSubject<Course[]>([]);
  tempResult$: Observable<Course[]> = this.tempResultSubject.asObservable();
  public courses: Course[] = [];
  public directions: Direction[] = [];

  newCourse: Course = new Course(null, null, '', null, '', '', '', '', '', '');
  newLearnerCourse: LearnerCourse = new LearnerCourse(null, null, null, null,);

  public editCourse = false;
  pageSize = 10;
  pageIndex = 0;
  length = 0;
  step = 0;

  successMessage = 'Вы записались на курс успешно.';
  errorMessage = 'Вы уже записаны на этот курс';
  successStyle = 'success-snackbar';
  errorStyle = 'error-snackbar';
  constructor(
    private teacherService: TeacherService,
    private adminService: AdminService,
    private router: Router,
    public snackBar: MatSnackBar,
    public dialog: MatDialog,
    public spinner: NgxSpinnerService,
  ) { }

  ngOnInit() {
    this.getCourses();
  }

  getCourses() {
    this.teacherService.getActiveCourses().toPromise().then(
      data => {
        this.courses = data;
        this.setVariablesToDefault();
        this.step = this.courses[0].Id;
        this.length = this.courses.length;
        this.changePageEvent();
      });
  }

  order(course: Course) {
    this.spinner.show();
    this.newLearnerCourse.IdCourse = course.Id;
    this.newLearnerCourse.Name = course.Name;
    this.newLearnerCourse.IdUser = localStorage.getItem('userId');
    this.teacherService.OrderCourse(this.newLearnerCourse).subscribe(next => {
      if (next.error === false) {
        this.spinner.hide();
        this.showSnackBar(this.successMessage, this.successStyle);
      } else {
        this.showSnackBar(this.errorMessage, this.errorStyle);
      }
    }, error => {
      console.log(error);
      this.spinner.hide();
    });
  }
  
  info(id: string) {
    localStorage.setItem('CourseId', id);
    this.router.navigate(['/course-info']);
  }
  
  showSnackBar(message: string, typeClass: string) {
    this.snackBar.open(message, null, {
      duration: 3000,
      verticalPosition: 'top',
      horizontalPosition: 'center',
      panelClass: [typeClass]
    });
  }

  public changePageEvent(event?: PageEvent) {
    if (event != null) {
      this.pageIndex = event.pageIndex;
      this.pageSize = event.pageSize;
    }
    this.tempResultSubject.next(this.courses.slice(this.pageSize * this.pageIndex, this.pageSize * (this.pageIndex + 1)));
    return event;
  }

  private setVariablesToDefault() {
    this.pageSize = 10;
    this.pageIndex = 0;
    this.length = 0;
  }

  setStep(index: number) {
    this.step = index;
  }

  nextStep(currentStep: number) {
    const ind = this.courses.findIndex(x => x.Id === currentStep);
    if (this.courses[ind + 1] !== undefined) {
      this.step = this.courses[ind + 1].Id;
    }
  }

  prevStep(currentStep: number) {
    const ind = this.courses.findIndex(x => x.Id === currentStep);
    if (this.courses[ind - 1] !== undefined) {
      this.step = this.courses[ind - 1].Id;
    }
  }
}
