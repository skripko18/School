import { Component, OnInit } from '@angular/core';
import { UploadEvent, UploadFile, FileSystemFileEntry, FileSystemDirectoryEntry } from 'ngx-file-drop';
import { MatSnackBar, MatDialog } from '@angular/material';
import { Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { FilePreviewOverlayService } from '../file-preview/file-preview-overlay.service';
import { FilePreviewOverlayRef } from '../file-preview/file-preview-overlay/file-preview-overlay-ref';
import { DatePipe } from '@angular/common';
import { DateTimeFormatPipe } from '../pipes/date-time-format.pipe';
import { DateFormatPipe } from '../pipes/date-format.pipe';
import { AdminService } from '../shared/admin.service';
import { UserReg } from '../shared/user.model';

@Component({
  selector: 'app-admin-users',
  templateUrl: './admin-users.component.html',
  styleUrls: ['./admin-users.component.css']
})
export class AdminUsersComponent implements OnInit {
  public files: UploadFile[] = [];
  public users: UserReg[] = [];

  isLoginError = false;
  newUser: UserReg = new UserReg('', '', '', '', '', '', '', '','');
  successMessage = 'Новый преподаватель добавлен успешно.';
  successDelMessage = 'Пользователь удален успешно.';
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
    this.getUsers();
  }

  OnSubmit() {
    this.spinner.show();
    this.adminService.HrRegistration(this.newUser).subscribe(next => {
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

  getUsers() {
    this.adminService.getUsers().toPromise().then(
      data => {
        this.users = data;
      });
  }

  deleteUser(Id) {
    this.adminService.DeleteUser(Id).subscribe(next => {
      console.log(next)
      this.spinner.hide();
      if (next.error === false) {
        this.showSnackBar(this.successDelMessage, this.successStyle);
        this.getUsers();
      } else {
          this.showSnackBar(this.errorMessage, this.errorStyle);
      }
    }, error => {
      console.log(error);
      this.spinner.hide();
    });
  }
  block(id) {
    this.adminService.Block(id).subscribe(
      next => {
        this.getUsers();
      },
      err => {
        console.log(err);
      }
    );
  }
  unblock(id) {
    this.adminService.Unblock(id).subscribe(
      next => {
        this.getUsers();
      },
      err => {
        console.log(err);
      }
    );
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
    this.newUser = new UserReg('', '', '', '', '', '', '', '','');
  }
}
