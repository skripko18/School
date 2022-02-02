import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule} from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatButtonModule, MatCheckboxModule, MatToolbarModule, MatSidenavModule, MatIconModule,
   MatListModule, MAT_DATE_LOCALE } from '@angular/material';
import { MaterialModule } from './modules/material/material.module';
import { FileDropModule } from 'ngx-file-drop';

import { RecaptchaModule } from 'ng-recaptcha';
import { RecaptchaFormsModule } from 'ng-recaptcha/forms';
import { NgxSpinnerModule } from 'ngx-spinner';

import { UserService } from './shared/user.service';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { UserComponent } from './user/user.component';
import { SignInComponent } from './user/sing-in/sing-in.component';
import { HomeComponent } from './home/home.component';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { MainNavComponent } from './main-nav/main-nav.component';
import { LayoutModule } from '@angular/cdk/layout';
import { OverlayModule } from '@angular/cdk/overlay';
import { FilePreviewOverlayComponent } from './file-preview/file-preview-overlay/file-preview-overlay.component';
import { DatePipe } from '@angular/common';
import { RegisterComponent } from './user/register/register.component';
import { AdminNavComponent } from './admin-nav/admin-nav.component';
import { AdminService } from './shared/admin.service';
import { AdminHomeComponent } from './admin-home/admin-home.component';
import { AdminUsersComponent } from './admin-users/admin-users.component';
import { TeacherService } from './shared/teacher.service';
import { DateTimeFormatPipe } from './pipes/date-time-format.pipe';
import { DateFormatPipe } from './pipes/date-format.pipe';
import { TeacherRegistrationComponent } from './teacher-registration/teacher-registration.component';
import { MainPageComponent } from './main-page/main-page.component';
import { TeacherNavComponent } from './teacher-nav/teacher-nav.component';
import { TeacherHomeComponent } from './teacher-home/teacher-home.component';
import { ErrorPageComponent } from './error-page/error-page.component';
import { AdminDirectionsComponent } from './admin-directions/admin-directions.component';
import { TeacherCourseComponent } from './teacher-course/teacher-course.component';
import { TeacherCreatecourseComponent } from './teacher-createcourse/teacher-createcourse.component';
import { TeacherProgramsComponent } from './teacher-programs/teacher-programs.component';
import { TeacherHomeworkComponent } from './teacher-homework/teacher-homework.component';
import { TeacherMaterialComponent } from './teacher-material/teacher-material.component';
import { AdminCourseComponent } from './admin-course/admin-course.component';
import { AdminInfoComponent } from './admin-info/admin-info.component';
import { TeacherInfoComponent } from './teacher-info/teacher-info.component';
import { UserCourseComponent } from './user-course/user-course.component';
import { UserMyCourseComponent } from './user-mycourse/user-mycourse.component';
import { CourseInfoComponent } from './course-info/course-info.component';
import { TeacherCourseInfoComponent } from './teacher-course-info/teacher-course-info.component';

@NgModule({
  declarations: [
    AppComponent,
    UserComponent,
    SignInComponent,
    RegisterComponent,
    FilePreviewOverlayComponent,
    HomeComponent,
    AdminHomeComponent,
    AdminUsersComponent,
    MainNavComponent,
    DateTimeFormatPipe,
    DateFormatPipe,
    TeacherNavComponent,
    AdminNavComponent,
    TeacherRegistrationComponent,
    TeacherHomeComponent,
    TeacherRegistrationComponent,
    MainPageComponent,
    ErrorPageComponent,
    AdminDirectionsComponent,
    TeacherCourseComponent,
    UserCourseComponent,
    UserMyCourseComponent,
    CourseInfoComponent,
    TeacherCourseInfoComponent,
    TeacherCreatecourseComponent,
    TeacherProgramsComponent,
    TeacherHomeworkComponent,
    TeacherMaterialComponent,
    AdminCourseComponent,
    AdminInfoComponent,
    TeacherInfoComponent,
  ],
  entryComponents: [
    FilePreviewOverlayComponent
  ],
  imports: [
    BrowserModule,
    MaterialModule,
    FormsModule,
    HttpClientModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    MatButtonModule,
    MatCheckboxModule,
    FileDropModule,
    RecaptchaModule,
    RecaptchaFormsModule,
    NgxSpinnerModule,
    LayoutModule,
    MatToolbarModule,
    MatSidenavModule,
    MatIconModule,
    MatListModule,
    OverlayModule
  ],
  providers: [
    { provide: MAT_DATE_LOCALE, useValue: 'ru-RU' },
    DatePipe,
    UserService,
    AdminService,
    TeacherService,
    ],
  bootstrap: [AppComponent]
})
export class AppModule {
  constructor() {}
}
