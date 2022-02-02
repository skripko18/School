import { Component, OnInit } from '@angular/core';
import { MatDialog, MatSnackBar, PageEvent } from '@angular/material';
import { Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { BehaviorSubject, Observable } from 'rxjs';
import { TeacherService } from '../shared/teacher.service';
import { Material } from './models/material.model';

@Component({
  selector: 'app-teacher-material',
  templateUrl: './teacher-material.component.html',
  styleUrls: ['./teacher-material.component.css']
})
export class TeacherMaterialComponent implements OnInit {


  private tempResultSubject: BehaviorSubject<Material[]> = new BehaviorSubject<Material[]>([]);
  tempResult$: Observable<Material[]> = this.tempResultSubject.asObservable();

  public material: Material[] = [];

  pageSize = 10;
  pageIndex = 0;
  length = 0;
  step = 0;

  isLoginError = false;
  newMaterial: Material = new Material(null, null, '', '');
  successMessage = 'Учебный материал добавлен успешно.';
  successDelMessage = 'Учебный материал удален успешно.';
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
    this.getMaterials();
  }

  AddMaterial() {
    this.spinner.show();
    this.newMaterial.IdCourse = Number(localStorage.getItem('CourseId'));
    this.teacherService.AddMaterial(this.newMaterial).subscribe(next => {
      if (next.error === false) {
        this.spinner.hide();
        this.getMaterials();
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

  getMaterials() {
    const id = Number(localStorage.getItem('CourseId'));
    this.teacherService.getMaterials(id).toPromise().then(
      data => {
        this.material = data;
        this.setVariablesToDefault();
        this.step = this.material[0].Id;
        this.length = this.material.length;
        this.changePageEvent();
      });
  }

  deleteMaterial(id) {
    this.teacherService.DeleteMaterial(id).subscribe(next => {
      console.log(next)
      this.spinner.hide();
      if (next.error === false) {
        this.showSnackBar(this.successDelMessage, this.successStyle);
        this.getMaterials();
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
    this.newMaterial = new Material(null, null, '', '');
  }


  public changePageEvent(event?: PageEvent) {
    if (event != null) {
      this.pageIndex = event.pageIndex;
      this.pageSize = event.pageSize;
    }
    this.tempResultSubject.next(this.material.slice(this.pageSize * this.pageIndex, this.pageSize * (this.pageIndex + 1)));
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
    const ind = this.material.findIndex(x => x.Id === currentStep);
    if (this.material[ind + 1] !== undefined) {
      this.step = this.material[ind + 1].Id;
    }
  }

  prevStep(currentStep: number) {
    const ind = this.material.findIndex(x => x.Id === currentStep);
    if (this.material[ind - 1] !== undefined) {
      this.step = this.material[ind - 1].Id;
    }
  }


}
