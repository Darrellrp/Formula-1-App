import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable, map, throwError } from 'rxjs';
import { APP_BASEURL } from 'src/main';
import { ApiConfiguration } from '../../models/api.configuration';
import { ApiEndpoints } from '../api.endpoints';
import { Endpoint } from '../../models/endpoint';
import { ApiOverview } from '../../models/api.overview';
import { ApiResult } from '../../models/api.result';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  constructor(
    @Inject(APP_BASEURL)
    private readonly baseUrl: string,
    private readonly http: HttpClient
  ) { }

  public GetConfiguration(): Observable<ApiConfiguration> {
    if (this.baseUrl == null || this.baseUrl == "") {
      return throwError(() => {
        const error: any = new Error('Error: Empty ApiBaseUrl property');
        error.timestamp = Date.now();
        return error;
      });;
    }
    return this.http.get<any>(`${this.baseUrl}/${ApiEndpoints.Configuration}`);
  }

  public GetEndpoints(): Observable<Array<Endpoint>> {
    return this.http.get<ApiOverview>(this.baseUrl).pipe(map(x => x.endpoints));
  }

  public GetEntities<Entity>(collectionKey: string): Observable<ApiResult<Entity>> {
    return this.http.get<ApiResult<Entity>>(`${this.baseUrl}/${collectionKey}`);
  }
}
