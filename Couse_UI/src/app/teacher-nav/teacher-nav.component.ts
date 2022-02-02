import { Component, OnInit } from '@angular/core';
import { BreakpointObserver, Breakpoints } from '@angular/cdk/layout';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { Router } from '@angular/router';

@Component({
  selector: 'app-teacher-nav',
  templateUrl: './teacher-nav.component.html',
  styleUrls: ['./teacher-nav.component.css'],
})
export class TeacherNavComponent implements OnInit {
  public userName = '';
  isHandset$: Observable<boolean> = this.breakpointObserver.observe(Breakpoints.Handset)
    .pipe(
      map(result => result.matches)
    );

  constructor(
    private breakpointObserver: BreakpointObserver,
    private router: Router,
    ) {
    }

    ngOnInit () {
    }

  Profile() {
    this.router.navigate(['/teacher-home']);
  }

  Logout() {
    localStorage.clear();
    this.router.navigate(['/login']);
  }
}
