import { Component, OnInit } from '@angular/core';
import { MatDialog, MatSnackBar, PageEvent } from '@angular/material';
import { Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { BehaviorSubject, Observable } from 'rxjs';
import { TeacherService } from '../shared/teacher.service';
import { Program } from './models/program.model';

@Component({
  selector: 'app-teacher-programs',
  templateUrl: './teacher-programs.component.html',
  styleUrls: ['./teacher-programs.component.css']
})
export class TeacherProgramsComponent implements OnInit {
  private tempResultSubject: BehaviorSubject<Program[]> = new BehaviorSubject<Program[]>([]);
  tempResult$: Observable<Program[]> = this.tempResultSubject.asObservable();

  public program: Program[] = [];

  pageSize = 10;
  pageIndex = 0;
  length = 0;
  step = 0;

  isLoginError = false;
  newProgram: Program = new Program(null,null, '');
  successMessage = 'Тема добавлена успешно.';
  successDelMessage = 'Тема удалена успешно.';
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
    this.getPrograms();
  }

  AddProgram() {
    this.spinner.show();
    this.newProgram.IdCourse = Number(localStorage.getItem('CourseId'));
    this.teacherService.AddProgram(this.newProgram).subscribe(next => {
      if (next.error === false) {
        this.spinner.hide();
        this.getPrograms();
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

  getPrograms() {
    const id = Number(localStorage.getItem('CourseId'));
    this.teacherService.getPrograms(id).toPromise().then(
      data => {
        this.program = data;
        this.setVariablesToDefault();
        this.step = this.program[0].Id;
        this.length = this.program.length;
        this.changePageEvent();
      });
  }

  deleteProgram(id) {
    this.teacherService.DeleteProgram(id).subscribe(next => {
      console.log(next)
      this.spinner.hide();
      if (next.error === false) {
        this.showSnackBar(this.successDelMessage, this.successStyle);
        this.getPrograms();
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
    this.newProgram = new Program(null,null, '');
  }


  public changePageEvent(event?: PageEvent) {
    if (event != null) {
      this.pageIndex = event.pageIndex;
      this.pageSize = event.pageSize;
    }
    this.tempResultSubject.next(this.program.slice(this.pageSize * this.pageIndex, this.pageSize * (this.pageIndex + 1)));
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
    const ind = this.program.findIndex(x => x.Id === currentStep);
    if (this.program[ind + 1] !== undefined) {
      this.step = this.program[ind + 1].Id;
    }
  }

  prevStep(currentStep: number) {
    const ind = this.program.findIndex(x => x.Id === currentStep);
    if (this.program[ind - 1] !== undefined) {
      this.step = this.program[ind - 1].Id;
    }
  }

}
