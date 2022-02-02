import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UserService } from '../shared/user.service';
import { NgxSpinnerService } from 'ngx-spinner';
import { TeacherDirection } from './models/teacherdirection.model';
import { TeacherService } from '../shared/teacher.service';
import { MatSnackBar } from '@angular/material';

@Component({
  selector: 'app-teacher-home',
  templateUrl: './teacher-home.component.html',
  styleUrls: ['./teacher-home.component.css']
})
export class TeacherHomeComponent implements OnInit {
  public userName: string;
  public role: string;
  public email: string;
  public fio: string;
  public experience: string;
  public workplace: string;
  public addInfo = false;

  newTeacherDirection: TeacherDirection = new TeacherDirection(null, '', '', '','');
  public teacherDirection: TeacherDirection[] = [];

  successMessage = 'Личные данные добавлены успешно.';
  errorMessage = 'Проверьте данные. Ошибка добавления.';
  successStyle = 'success-snackbar';
  errorStyle = 'error-snackbar';

  constructor(
    private router: Router,
    private teacherService: TeacherService,
    public spinner: NgxSpinnerService,
    public snackBar: MatSnackBar,
  ) { }

  ngOnInit() {
 this.getTeacherDirections();
    this.userName = localStorage.getItem('userName');
    this.role = localStorage.getItem('role');
    this.email = localStorage.getItem('email');
   
  }

  AddTeacherDirection(FIO: string, Experience: string, Workplace: string) {
    this.spinner.show();
    this.newTeacherDirection.FIO = FIO;
    this.newTeacherDirection.Experience = Experience;
    this.newTeacherDirection.Workplace = Workplace;
    this.newTeacherDirection.IdUser = localStorage.getItem('userId');

    this.teacherService.AddTeacherDirection(this.newTeacherDirection).subscribe(next => {
      console.log(next)
      this.spinner.hide();
      if (next.error === false) {
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
  getTeacherDirections() {
    this.newTeacherDirection.IdUser = localStorage.getItem('userId');
    this.teacherService.getTeacherDirections(this.newTeacherDirection.IdUser).toPromise().then(
      data => {
        this.teacherDirection = data;
        if (this.teacherDirection.length == 0) {
          this.addInfo = true;
        } else {

    localStorage.setItem('fio', this.teacherDirection[0].FIO);
        localStorage.setItem('experience', this.teacherDirection[0].Experience);
        localStorage.setItem('workplace', this.teacherDirection[0].Workplace);
          localStorage.setItem('IdTeacherDirection', this.teacherDirection[0].Id.toString());
          this.fio = localStorage.getItem('fio');
          this.experience = localStorage.getItem('experience');
          this.workplace = localStorage.getItem('workplace');
        }
    
      });
  }
  Logout() {
    localStorage.clear();
    this.router.navigate(['/login']);
  }
  setObjectsToDefault() {
    this.newTeacherDirection = new TeacherDirection(null, '', '', '', '');
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
