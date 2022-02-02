import { Direction } from '@angular/cdk/bidi';
import { Component, OnInit } from '@angular/core';
import { MatDialog, MatSnackBar } from '@angular/material';
import { Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { AdminService } from '../shared/admin.service';
import { TeacherService } from '../shared/teacher.service';
import { Course } from '../teacher-course/models/course.model';
import { Homework } from '../teacher-homework/models/homework.model';
import { Material } from '../teacher-material/models/material.model';
import { Program } from '../teacher-programs/models/program.model';

@Component({
  selector: 'app-teacher-course-info-info',
  templateUrl: './teacher-course-info.component.html',
  styleUrls: ['./teacher-course-info.component.css']
})
export class TeacherCourseInfoComponent implements OnInit {

  public courses: Course;
  public homework: Homework[] =[];
  public program: Program[] =[];
  public material: Material[] =[];

  newCourse: Course = new Course(null, null, '', null, '', '', '', '', '', '');

  constructor(
    private teacherService: TeacherService,
    private adminService: AdminService,
    private router: Router,
    public snackBar: MatSnackBar,
    public dialog: MatDialog,
    public spinner: NgxSpinnerService,
  ) { }

  ngOnInit() {
    this.getCourseInfo();
    this.getHomeworks();
    this.getMaterials();
    this.getPrograms();
  }

  getCourseInfo() {
    const id = Number(localStorage.getItem('CourseId'));
    this.teacherService.getCourseInfo(id).toPromise().then(
      data => {
        this.courses = data; 
        console.log(this.courses)
      });
  }

  getHomeworks() {
    const id = Number(localStorage.getItem('CourseId'));
    this.teacherService.getHomeworks(id).toPromise().then(
      data => {
        this.homework = data;
      });
  }
  getPrograms() {
    const id = Number(localStorage.getItem('CourseId'));
    this.teacherService.getPrograms(id).toPromise().then(
      data => {
        this.program = data;
      });
  }
  getMaterials() {
    const id = Number(localStorage.getItem('CourseId'));
    this.teacherService.getMaterials(id).toPromise().then(
      data => {
        this.material = data;
      });
  }
}
