import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { map } from 'rxjs/operators';
import { User, UserReg } from './user.model';
import { Observable, Subject } from 'rxjs';
import { SaveResult } from './save-result.model';
import { Direction } from '../admin-directions/models/direction.model';
import { Course } from '../teacher-course/models/course.model';

@Injectable({
  providedIn: 'root'
})
export class AdminService {
  [x: string]: any;
  private URL_REG = `${environment.apiHostUrl}/api/userregistration`;

  private URL_USER = `${environment.apiHostUrl}/api/user`;
  private URL_ADMIN = `${environment.apiHostUrl}/api/admin`;

  constructor(
    private http: HttpClient
  ) { }


  TeacherRegistration(newUser: UserReg): Observable<SaveResult> {
    const result: Subject<SaveResult> = new Subject<SaveResult>();
    const urlDoc = this.URL_REG + '/addteacher';

    this.http.post(urlDoc, newUser).subscribe(
      res => {
        if (res)
          result.next(new SaveResult(false));
        else
          result.next(new SaveResult(true));
      },
      error => {
        result.next(new SaveResult(true));
      });

    return result.asObservable();
  }

  DeleteUser(Id: string): Observable<SaveResult> {
    const result: Subject<SaveResult> = new Subject<SaveResult>();
    const url = `${environment.apiHostUrl}/api/user/deluser?Id=${Id}`;

    this.http.get(url).subscribe(
      res => {
        if (res)
          result.next(new SaveResult(false));
        else
          result.next(new SaveResult(true));
      },
      error => {
        result.next(new SaveResult(true));
      });

    return result.asObservable();
  }

  getUsers(): Observable<UserReg[]> {
    return this.http
      .get<UserReg[]>(this.URL_USER + '/getusers')
      .pipe(
        map(res => {
          const result: any = res;
          return result.map(item => new UserReg(item.Id, item.Created, item.Email, item.Password, item.UserName, item.RoleId, item.Role.RoleName,
            item.FIO, item.Status));
        })
      );
  }

  AddDirection(newDirection: Direction): Observable<SaveResult> {
    const result: Subject<SaveResult> = new Subject<SaveResult>();
    const urlDoc = this.URL_ADMIN + '/adddirection';

    this.http.post(urlDoc, newDirection).subscribe(
      res => {
        if (res)
          result.next(new SaveResult(false));
        else
          result.next(new SaveResult(true));
      },
      error => {
        result.next(new SaveResult(true));
      });

    return result.asObservable();
  }

  getDirections(): Observable<Direction[]> {
    return this.http
      .get<Direction[]>(this.URL_ADMIN + '/getdirections')
      .pipe(
        map(res => {
          const result: any = res;
          return result.map(item => new Direction(item.Id, item.Direction));
        })
      );
  }
  getCourses(): Observable<Course[]> {
    const url = `${environment.apiHostUrl}/api/admin/getcourses`;
    return this.http
      .get<Course[]>(url)
      .pipe(
        map(res => {
          const result: any = res;
          return result.map(item => new Course(item.Id, item.IdTeacherDirection, item.TeacherDirection, item.IdDirection,
            item.Direction, item.Name, item.Description, item.Skills, item.Status, item.DateStart));
        })
      );
  }
  ApproveCourse(id: string): Observable<SaveResult> {
    const url = `${environment.apiHostUrl}/api/admin/approvecourse?id=${id}`;
    const result: Subject<SaveResult> = new Subject<SaveResult>();
    this.http.get(url).subscribe(
      res => {
        result.next();
      },
      err => {
        result.next();
      }
    );
    return result.asObservable();
  }
  RejectCourse(id: string): Observable<SaveResult> {
    const url = `${environment.apiHostUrl}/api/admin/rejectcourse?id=${id}`;
    const result: Subject<SaveResult> = new Subject<SaveResult>();
    this.http.get(url).subscribe(
      res => {
        result.next();
      },
      err => {
        result.next();
      }
    );
    return result.asObservable();
  }
  Block(id: string): Observable<SaveResult> {
    const url = `${environment.apiHostUrl}/api/admin/block?id=${id}`;
    const result: Subject<SaveResult> = new Subject<SaveResult>();
    this.http.get(url).subscribe(
      res => {
        result.next();
      },
      err => {
        result.next();
      }
    );
    return result.asObservable();
  }
  Unblock(id: string): Observable<SaveResult> {
    const url = `${environment.apiHostUrl}/api/admin/unblock?id=${id}`;
    const result: Subject<SaveResult> = new Subject<SaveResult>();
    this.http.get(url).subscribe(
      res => {
        result.next();
      },
      err => {
        result.next();
      }
    );
    return result.asObservable();
  }
  private getOptionsCustom(Id: string) {
    return {
      params: new HttpParams()
        .set('Id', Id)
    };
  }
}
