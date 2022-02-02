import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { map } from 'rxjs/operators';
import { User, UserReg } from './user.model';
import { Observable, Subject } from 'rxjs';
import { SaveResult } from './save-result.model';
import { TeacherDirection } from '../teacher-home/models/teacherdirection.model';
import { Course } from '../teacher-course/models/course.model';
import { Program } from '../teacher-programs/models/program.model';
import { Homework } from '../teacher-homework/models/homework.model';
import { Material } from '../teacher-material/models/material.model';
import { LearnerCourse } from '../user-course/models/learnercourse.model';

@Injectable({
  providedIn: 'root'
})
export class TeacherService {
  [x: string]: any;
  private URL_TEACHER = `${environment.apiHostUrl}/api/teacher`;

  constructor(
    private http: HttpClient
  ) { }

  AddTeacherDirection(newTeacherDirection: TeacherDirection): Observable<SaveResult> {
    const result: Subject<SaveResult> = new Subject<SaveResult>();
    const urlDoc = this.URL_TEACHER + '/addteacherdirection';

    this.http.post(urlDoc, newTeacherDirection).subscribe(
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

  getTeacherDirections(id): Observable<TeacherDirection[]> {
    const url = `${environment.apiHostUrl}/api/teacher/getteacherdirections?id=${id}`;
    return this.http
      .get<TeacherDirection[]>(url)
      .pipe(
        map(res => {
          const result: any = res;
          return result.map(item => new TeacherDirection(item.Id, item.IdUser, item.FIO, item.Experience, item.Workplace));
        })
      );
  }

  AddCourse(newCourse: Course): Observable<SaveResult> {
    const result: Subject<SaveResult> = new Subject<SaveResult>();
    const urlDoc = this.URL_TEACHER + '/addcourse';

    this.http.post(urlDoc, newCourse).subscribe(
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
  OrderCourse(newLearnerCourse: LearnerCourse): Observable<SaveResult> {
    const result: Subject<SaveResult> = new Subject<SaveResult>();
    const urlDoc = this.URL_TEACHER + '/ordercourse';

    this.http.post(urlDoc, newLearnerCourse).subscribe(
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
  getCourses(id): Observable<Course[]> {
    const url = `${environment.apiHostUrl}/api/teacher/getcourses?id=${id}`;
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
  getActiveCourses(): Observable<Course[]> {
    const url = `${environment.apiHostUrl}/api/teacher/getactivecourses`;
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
  getLearnerCourses(id: string): Observable<LearnerCourse[]> {
    const url = `${environment.apiHostUrl}/api/teacher/getlearnercourses?id=${id}`;
    return this.http
      .get<LearnerCourse[]>(url)
      .pipe(
        map(res => {
          const result: any = res;
          return result.map(item => new LearnerCourse(item.Id, item.IdCourse, item.IdUser, item.Name));
        })
      );
  }
  getCourseInfo(id): Observable<Course> {
    const url = `${environment.apiHostUrl}/api/teacher/getcourseinfo?id=${id}`;
    return this.http
      .get<Course>(url)
      .pipe(
        map(res => {
          const result: any = res;
          return result;
        })
      );
  }
  DeleteCourse(id: number): Observable<SaveResult> {
    const result: Subject<SaveResult> = new Subject<SaveResult>();
    const url = `${environment.apiHostUrl}/api/teacher/delcourse?id=${id}`;

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
  FinishCreateCourse(id: string): Observable<SaveResult> {
    const url = `${environment.apiHostUrl}/api/teacher/finishcreatecourse?id=${id}`;
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
  StartCourse(id: string): Observable<SaveResult> {
    const url = `${environment.apiHostUrl}/api/teacher/startcourse?id=${id}`;
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
  EditCourse(course: Course): Observable<number> {
     console.log(course);
    const result: Subject<number> = new Subject<number>();
    this.http.put(this.URL_TEACHER + '/editcourse', course).subscribe(
      res => {
          result.next();
      },
      err => {
        result.next();
      }
    );
    return result.asObservable();
  }
  AddProgram(newProgram: Program): Observable<SaveResult> {
    const result: Subject<SaveResult> = new Subject<SaveResult>();
    const urlDoc = this.URL_TEACHER + '/addprogram';

    this.http.post(urlDoc, newProgram).subscribe(
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
  getPrograms(id): Observable<Program[]> {
    const url = `${environment.apiHostUrl}/api/teacher/getprograms?id=${id}`;
    return this.http
      .get<Program[]>(url)
      .pipe(
        map(res => {
          const result: any = res;
          return result.map(item => new Program(item.Id, item.IdCourse, item.Theme));
        })
      );
  }
  DeleteProgram(id: number): Observable<SaveResult> {
    const result: Subject<SaveResult> = new Subject<SaveResult>();
    const url = `${environment.apiHostUrl}/api/teacher/delprogram?id=${id}`;

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
  AddHomework(newHomework: Homework): Observable<SaveResult> {
    const result: Subject<SaveResult> = new Subject<SaveResult>();
    const urlDoc = this.URL_TEACHER + '/addhomework';

    this.http.post(urlDoc, newHomework).subscribe(
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
  getHomeworks(id): Observable<Homework[]> {
    const url = `${environment.apiHostUrl}/api/teacher/gethomeworks?id=${id}`;
    return this.http
      .get<Homework[]>(url)
      .pipe(
        map(res => {
          const result: any = res;
          return result.map(item => new Homework(item.Id, item.IdCourse, item.Link, item.Description));
        })
      );
  }
  DeleteHomework(id: number): Observable<SaveResult> {
    const result: Subject<SaveResult> = new Subject<SaveResult>();
    const url = `${environment.apiHostUrl}/api/teacher/delhomework?id=${id}`;

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
  AddMaterial(newMaterial: Material): Observable<SaveResult> {
    const result: Subject<SaveResult> = new Subject<SaveResult>();
    const urlDoc = this.URL_TEACHER + '/addmaterial';

    this.http.post(urlDoc, newMaterial).subscribe(
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
  getMaterials(id): Observable<Material[]> {
    const url = `${environment.apiHostUrl}/api/teacher/getmaterials?id=${id}`;
    return this.http
      .get<Material[]>(url)
      .pipe(
        map(res => {
          const result: any = res;
          return result.map(item => new Material(item.Id, item.IdCourse, item.Link, item.Description));
        })
      );
  }
  DeleteMaterial(id: number): Observable<SaveResult> {
    const result: Subject<SaveResult> = new Subject<SaveResult>();
    const url = `${environment.apiHostUrl}/api/teacher/delmaterial?id=${id}`;

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
  private getOptions(query: string, status: string) {
    return {
      params: new HttpParams()
        .set('UserId', query)
        .set('Status', status)
    };
  }
}
