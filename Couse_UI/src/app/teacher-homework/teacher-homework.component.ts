import { Component, OnInit } from '@angular/core';
import { MatDialog, MatSnackBar, PageEvent } from '@angular/material';
import { Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { BehaviorSubject, Observable } from 'rxjs';
import { TeacherService } from '../shared/teacher.service';
import { Homework } from './models/homework.model';

@Component({
  selector: 'app-teacher-homework',
  templateUrl: './teacher-homework.component.html',
  styleUrls: ['./teacher-homework.component.css']
})
export class TeacherHomeworkComponent implements OnInit {

  private tempResultSubject: BehaviorSubject<Homework[]> = new BehaviorSubject<Homework[]>([]);
  tempResult$: Observable<Homework[]> = this.tempResultSubject.asObservable();

  public homework: Homework[] = [];

  pageSize = 10;
  pageIndex = 0;
  length = 0;
  step = 0;

  isLoginError = false;
  newHomework: Homework = new Homework(null, null, '', '');
  successMessage = 'Домашнее задание добавлено успешно.';
  successDelMessage = 'Домашнее задание удалено успешно.';
  errorMessage = 'Проверьте данные. Ошибка добавления.';
  successStyle = 'success-snackbar';
  errorStyle = 'error-snackbar';

  constructor(
    private teacherService: TeacherService,
    private router: Router,
    public snackBar: MatSnackBar,
    public dialog: MatDialog,
    public spinner: NgxSpinnerService,
  ) { }

  ngOnInit() {
    this.getHomeworks();
  }

  AddHomework() {
    this.spinner.show();
    this.newHomework.IdCourse = Number(localStorage.getItem('CourseId'));
    this.teacherService.AddHomework(this.newHomework).subscribe(next => {
      if (next.error === false) {
        this.spinner.hide();
        this.getHomeworks();
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

  getHomeworks() {
    const id = Number(localStorage.getItem('CourseId'));
    this.teacherService.getHomeworks(id).toPromise().then(
      data => {
        this.homework = data;
        this.setVariablesToDefault();
        this.step = this.homework[0].Id;
        this.length = this.homework.length;
        this.changePageEvent();
      });
  }

  deleteHomework(id) {
    this.teacherService.DeleteHomework(id).subscribe(next => {
      console.log(next)
      this.spinner.hide();
      if (next.error === false) {
        this.showSnackBar(this.successDelMessage, this.successStyle);
        this.getHomeworks();
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
    this.newHomework = new Homework(null, null, '', '');
  }


  public changePageEvent(event?: PageEvent) {
    if (event != null) {
      this.pageIndex = event.pageIndex;
      this.pageSize = event.pageSize;
    }
    this.tempResultSubject.next(this.homework.slice(this.pageSize * this.pageIndex, this.pageSize * (this.pageIndex + 1)));
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
    const ind = this.homework.findIndex(x => x.Id === currentStep);
    if (this.homework[ind + 1] !== undefined) {
      this.step = this.homework[ind + 1].Id;
    }
  }

  prevStep(currentStep: number) {
    const ind = this.homework.findIndex(x => x.Id === currentStep);
    if (this.homework[ind - 1] !== undefined) {
      this.step = this.homework[ind - 1].Id;
    }
  }


}
