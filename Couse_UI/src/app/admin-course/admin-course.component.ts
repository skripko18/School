import { Component, OnInit } from '@angular/core';
import { MatDialog, MatSnackBar, PageEvent } from '@angular/material';
import { Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { BehaviorSubject, Observable } from 'rxjs';
import { Direction } from '../admin-directions/models/direction.model';
import { AdminService } from '../shared/admin.service';
import { TeacherService } from '../shared/teacher.service';
import { Course } from '../teacher-course/models/course.model';

@Component({
  selector: 'app-admin-course',
  templateUrl: './admin-course.component.html',
  styleUrls: ['./admin-course.component.css']
})
export class AdminCourseComponent implements OnInit {
  private tempResultSubject: BehaviorSubject<Course[]> = new BehaviorSubject<Course[]>([]);
  tempResult$: Observable<Course[]> = this.tempResultSubject.asObservable();
  public courses: Course[] = [];
  public directions: Direction[] = [];

  newCourse: Course = new Course(null, null, '', null, '', '', '', '', '', '');

  public editCourse = false;
  pageSize = 10;
  pageIndex = 0;
  length = 0;
  step = 0;
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
    this.adminService.getCourses().toPromise().then(
      data => {
        this.courses = data; this.setVariablesToDefault();
        this.step = this.courses[0].Id;
        this.length = this.courses.length;
        this.changePageEvent();
        console.log(this.courses)
      });
  }

  approve(id) {
    this.adminService.ApproveCourse(id).subscribe(
      next => {
        this.getCourses();
      },
      err => {
        console.log(err);
      }
    );
  }
  reject(id) {
    this.adminService.RejectCourse(id).subscribe(
      next => {
        this.getCourses();
      },
      err => {
        console.log(err);
      }
    );
  }
  info(id: string) {
    localStorage.setItem('CourseId', id);
    this.router.navigate(['/admin-info']);
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
