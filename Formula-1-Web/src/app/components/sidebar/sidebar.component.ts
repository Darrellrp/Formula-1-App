import { HttpClient } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';
import { Observable, map } from 'rxjs';
import { ApiOverview } from 'src/app/models/api.overview';
import { Endpoint } from 'src/app/models/endpoint';
import { APP_BASEURL } from 'src/main';

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.css']
})
export class SidebarComponent implements OnInit {

  public endpoints: Observable<Array<Endpoint>> = this.http.get<ApiOverview>(`${this.baseUrl}/api`).pipe(map(x => x.endpoints));

  constructor(private http: HttpClient, @Inject(APP_BASEURL) private baseUrl: string) { }

  ngOnInit(): void {
  }

}
