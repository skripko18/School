import { Component, OnInit } from '@angular/core';
import { MatDialog, MatSnackBar } from '@angular/material';
import { Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { Direction } from '../admin-directions/models/direction.model';
import { AdminService } from '../shared/admin.service';
import { TeacherService } from '../shared/teacher.service';
import { Course } from '../teacher-course/models/course.model';

@Component({
  selector: 'app-teacher-createcourse',
  templateUrl: './teacher-createcourse.component.html',
  styleUrls: ['./teacher-createcourse.component.css']
})
export class TeacherCreatecourseComponent implements OnInit {
  public directions: Direction[] = [];
  public teacherDirection: number;

  newCourse: Course = new Course(null, null,'', null,'', '', '', '', '', '');

  successMessage = 'Новый курс добавлен успешно.';
  errorMessage = 'Проверьте данные. Ошибка добавления.';
  successStyle = 'success-snackbar';
  errorStyle = 'error-snackbar';

  constructor(
    private adminService: AdminService,
    private teacherService: TeacherService,
    private router: Router,
    public snackBar: MatSnackBar,
    public dialog: MatDialog,
    public spinner: NgxSpinnerService,) { }

  ngOnInit() {
    this.getDirections();
    this.teacherDirection = Number(localStorage.getItem('IdTeacherDirection'));
  }

  getDirections() {
    this.adminService.getDirections().toPromise().then(
      data => {
        this.directions = data;
      });
  }

  AddCourse() {
    this.newCourse.IdTeacherDirection = this.teacherDirection;
    this.newCourse.Status = "Новый";
    this.spinner.show();
    this.teacherService.AddCourse(this.newCourse).subscribe(next => {
      if (next.error === false) {
        this.spinner.hide();
        this.showSnackBar(this.successMessage, this.successStyle);
        this.setObjectsToDefault();
      } else {
        this.showSnackBar(this.errorMessage, this.errorStyle);
      }
    }, error => {
      console.log(error);
      this.spinner.hide();
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

  setObjectsToDefault() {
    this.newCourse = new Course(null, null, '', null, '', '', '', '', '', '');
  }
}
