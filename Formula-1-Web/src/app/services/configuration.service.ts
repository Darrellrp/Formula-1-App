import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, tap, throwError } from 'rxjs';
import { ApiConfiguration } from '../models/configurations/api.configuration';
import { IResult } from '../models/IResult';

@Injectable({
  providedIn: 'root'
})
export class ConfigurationService {

  private readonly apiBaseUrl: string = "";
  private readonly apiUri: string = "api/configuration";

  public constructor(private httpClient: HttpClient) {
    let apiBaseUrl = this.GetApiBaseUrl();

    if (apiBaseUrl == null || apiBaseUrl == '') {
      throw new Error("API Base URL was not found");
    }

    this.apiBaseUrl = apiBaseUrl;
  }

  public Get(): Observable<IResult<ApiConfiguration>> {
    if (this.apiBaseUrl == null || this.apiBaseUrl == "") {
      return throwError(() => {
        const error: any = new Error('Error: Empty ApiBaseUrl property');
        error.timestamp = Date.now();
        return error;
      });;
    }
    return this.httpClient.get<any>(`${this.apiBaseUrl}/${this.apiUri}`);
  }

  public GetApiBaseUrl(): string | null | undefined {
    return document.querySelector("meta[name='apiurl']")?.getAttribute("content");
  }

  //public GetProperty(propertyName: string) {
  //  return this.Get().pipe()
  //}
}
