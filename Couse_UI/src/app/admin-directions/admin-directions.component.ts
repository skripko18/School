import { Component, OnInit } from '@angular/core';
import { MatDialog, MatSnackBar, PageEvent } from '@angular/material';
import { Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { BehaviorSubject, Observable } from 'rxjs';
import { FilePreviewOverlayService } from '../file-preview/file-preview-overlay.service';
import { AdminService } from '../shared/admin.service';
import { Direction } from './models/direction.model';

@Component({
  selector: 'app-admin-directions',
  templateUrl: './admin-directions.component.html',
  styleUrls: ['./admin-directions.component.css']
})
export class AdminDirectionsComponent implements OnInit {
  private tempResultSubject: BehaviorSubject<Direction[]> = new BehaviorSubject<Direction[]>([]);
  tempResult$: Observable<Direction[]> = this.tempResultSubject.asObservable();

  public direction: Direction[] = [];

  pageSize = 10;
  pageIndex = 0;
  length = 0;
  step = 0;

  isLoginError = false;
  newDirection: Direction = new Direction(null, '');
  successMessage = 'Направление курсов добавлено успешно.';
  errorMessage = 'Проверьте данные. Ошибка добавления.';
  successStyle = 'success-snackbar';
  errorStyle = 'error-snackbar';

  constructor(
    private adminService: AdminService,
    private router: Router,
    public snackBar: MatSnackBar,
    public dialog: MatDialog,
    public spinner: NgxSpinnerService,
    private previewDialog: FilePreviewOverlayService
  ) { }

  ngOnInit() {
    this.getDirections();
  }

  AddDirection() {
    this.spinner.show();
    this.adminService.AddDirection(this.newDirection).subscribe(next => {
      console.log(next)
      this.spinner.hide();
      if (next.error === false) {
        this.getDirections();
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

  getDirections() {
    this.adminService.getDirections().toPromise().then(
      data => {
        this.direction = data;
        this.setVariablesToDefault();
        this.step = this.direction[0].Id;
        this.length = this.direction.length;
        this.changePageEvent();
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
    this.newDirection = new Direction(null, '');
  }


  public changePageEvent(event?: PageEvent) {
    if (event != null) {
      this.pageIndex = event.pageIndex;
      this.pageSize = event.pageSize;
    }
    this.tempResultSubject.next(this.direction.slice(this.pageSize * this.pageIndex, this.pageSize * (this.pageIndex + 1)));
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
    const ind = this.direction.findIndex(x => x.Id === currentStep);
    if (this.direction[ind + 1] !== undefined) {
      this.step = this.direction[ind + 1].Id;
    }
  }

  prevStep(currentStep: number) {
    const ind = this.direction.findIndex(x => x.Id === currentStep);
    if (this.direction[ind - 1] !== undefined) {
      this.step = this.direction[ind - 1].Id;
    }
  }
}
