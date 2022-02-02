import { Component, OnInit } from '@angular/core';
import { MatDialog, MatSnackBar } from '@angular/material';
import { Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { Direction } from '../admin-directions/models/direction.model';
import { AdminService } from '../shared/admin.service';
import { TeacherService } from '../shared/teacher.service';
import { Course } from '../teacher-course/models/course.model';
import { LearnerCourse } from '../user-course/models/learnercourse.model';

@Component({
  selector: 'app-user-mycourse-course',
  templateUrl: './user-mycourse.component.html',
  styleUrls: ['./user-mycourse.component.css']
})
export class UserMyCourseComponent implements OnInit {

  public courses: LearnerCourse[] = [];
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
    const id = localStorage.getItem('userId');
    this.teacherService.getLearnerCourses(id).toPromise().then(
      data => {
        this.courses = data;
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
}
