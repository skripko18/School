import { Component, OnInit } from '@angular/core';
import { MatDialog, MatSnackBar } from '@angular/material';
import { Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { Direction } from '../admin-directions/models/direction.model';
import { AdminService } from '../shared/admin.service';
import { TeacherService } from '../shared/teacher.service';
import { Course } from './models/course.model';

@Component({
  selector: 'app-teacher-course',
  templateUrl: './teacher-course.component.html',
  styleUrls: ['./teacher-course.component.css']
})
export class TeacherCourseComponent implements OnInit {

  public courses: Course[] = [];
  public directions: Direction[] = [];

  newCourse: Course = new Course(null, null, '', null, '', '', '', '', '', '');

  public editCourse = false;

  successDelMessage = 'Курс удален успешно.';
  errorMessage = 'Проверьте данные. Ошибка добавления.';
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
    this.getDirections();
    this.getCourses();
  }

  getCourses() {
    const id = Number(localStorage.getItem('IdTeacherDirection'));
    this.teacherService.getCourses(id).toPromise().then(
      data => {
        this.courses = data;
      });
  }

  finishCreateCourse(id) {
    this.teacherService.FinishCreateCourse(id).subscribe(
      next => {
        this.getCourses();
      },
      err => {
        console.log(err);
      }
    );
  }
  start(id) {
    this.teacherService.StartCourse(id).subscribe(
      next => {
        this.getCourses();
      },
      err => {
        console.log(err);
      }
    );
  }
  delCourse(id) {
    this.teacherService.DeleteCourse(id).subscribe(next => {
      console.log(next)
      this.spinner.hide();
      if (next.error === false) {
        this.showSnackBar(this.successDelMessage, this.successStyle);
        this.getCourses();
      } else {
        this.showSnackBar(this.errorMessage, this.errorStyle);
      }
    }, error => {
      console.log(error);
      this.spinner.hide();
    });
  }
  program(id: string) {
    localStorage.setItem('CourseId', id);
    this.router.navigate(['/teacher-programs']);
  }
  material(id: string) {
    localStorage.setItem('CourseId', id);
    this.router.navigate(['/teacher-materials']);
  }
  homework(id: string) {
    localStorage.setItem('CourseId', id);
    this.router.navigate(['/teacher-homeworks']);
  }
  info(id: string) {
    localStorage.setItem('CourseId', id);
    this.router.navigate(['/teacher-course-info']);
  }
  edit(course: Course) {
    this.editCourse = true;
    this.newCourse.Name = course.Name;
    this.newCourse.IdDirection = course.IdDirection;
    this.newCourse.IdTeacherDirection = course.IdTeacherDirection;
    this.newCourse.Description = course.Description;
    this.newCourse.DateStart = course.DateStart;
    this.newCourse.Skills = course.Skills;
    this.newCourse.Status = course.Status;
    this.newCourse.Id = course.Id;

  }
  EditCourse() {
    this.teacherService.EditCourse(this.newCourse).subscribe(next => {
        this.editCourse = false;
        this.getCourses();
    }, error => {
      console.log(error);
      this.spinner.hide();
    });
  }
  getDirections() {
    this.adminService.getDirections().toPromise().then(
      data => {
        this.directions = data;
      });
  }
  showSnackBar(message: string, typeClass: string) {
    this.snackBar.open(message, null, {
      duration: 3000,
      verticalPosition: 'top',
      horizontalPosition: 'center',
      panelClass: [typeClass]
    });
  }
}
