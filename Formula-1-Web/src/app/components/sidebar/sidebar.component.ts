import { HttpClient } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';
import { Observable, map } from 'rxjs';
import { ApiOverview } from 'src/app/models/api.overview';
import { Endpoint } from 'src/app/models/endpoint';
import { ApiService } from 'src/app/services/api.service';
import { APP_BASEURL } from 'src/main';

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.css']
})
export class SidebarComponent implements OnInit {

  public readonly endpoints: Observable<Array<Endpoint>> = this.apiService.GetSidebar();

  constructor(private readonly apiService: ApiService) { }

  ngOnInit(): void { }

}
