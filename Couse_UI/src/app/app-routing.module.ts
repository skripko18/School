import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { UserComponent } from './user/user.component';
import { SignInComponent } from './user/sing-in/sing-in.component';
import { RegisterComponent } from './user/register/register.component';
import { AdminHomeComponent } from './admin-home/admin-home.component';
import { AdminUsersComponent } from './admin-users/admin-users.component';
import { TeacherHomeComponent } from './teacher-home/teacher-home.component';
import { TeacherRegistrationComponent } from './teacher-registration/teacher-registration.component';
import { MainPageComponent } from './main-page/main-page.component';
import { AdminDirectionsComponent } from './admin-directions/admin-directions.component';
import { TeacherCourseComponent } from './teacher-course/teacher-course.component';
import { TeacherCreatecourseComponent } from './teacher-createcourse/teacher-createcourse.component';
import { TeacherProgramsComponent } from './teacher-programs/teacher-programs.component';
import { TeacherHomeworkComponent } from './teacher-homework/teacher-homework.component';
import { TeacherMaterialComponent } from './teacher-material/teacher-material.component';
import { AdminCourseComponent } from './admin-course/admin-course.component';
import { AdminInfoComponent } from './admin-info/admin-info.component';
import { UserCourseComponent } from './user-course/user-course.component';
import { UserMyCourseComponent } from './user-mycourse/user-mycourse.component';
import { CourseInfoComponent } from './course-info/course-info.component';
import { TeacherCourseInfoComponent } from './teacher-course-info/teacher-course-info.component';

const routes: Routes = [
  { path : '', redirectTo: '/ilearn', pathMatch : 'full'},
  { path: 'home', component: HomeComponent },
  { path: 'user-course', component: UserCourseComponent },
  { path: 'my-courses', component: UserMyCourseComponent },
  { path: 'course-info', component: CourseInfoComponent },

  { path: 'admin-home', component: AdminHomeComponent },
  { path: 'admin-users', component: AdminUsersComponent },
  { path: 'admin-directions', component: AdminDirectionsComponent },
  { path: 'admin-course', component: AdminCourseComponent },
  { path: 'admin-info', component: AdminInfoComponent },
  { path: 'ilearn', component: MainPageComponent },

  { path: 'teacher-home', component: TeacherHomeComponent },
  { path: 'teacher-registration', component: TeacherRegistrationComponent },
  { path: 'teacher-courses', component: TeacherCourseComponent },
  { path: 'teacher-new-course', component: TeacherCreatecourseComponent },
  { path: 'teacher-programs', component: TeacherProgramsComponent },
  { path: 'teacher-materials', component: TeacherMaterialComponent },
  { path: 'teacher-homeworks', component: TeacherHomeworkComponent },
  { path: 'teacher-course-info', component: TeacherCourseInfoComponent },

  { path: 'login', component: UserComponent, children: [{ path: '', component: SignInComponent }]},
  { path: 'login', component: UserComponent, pathMatch: 'full' },
  { path: 'registration', component: RegisterComponent, pathMatch: 'full' },
  { path: '**', redirectTo: '/ilearn'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes, { useHash: true })],
  exports: [RouterModule]
})
export class AppRoutingModule { }
