import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, tap } from 'rxjs';
import { ApiConfiguration } from '../models/configurations/api.configuration';
import { IResult } from '../models/IResult';

@Injectable({
  providedIn: 'root'
})
export class ConfigurationService {

  private readonly apiBaseUrl: string = "https://localhost:7022";
  private readonly apiUri: string = "api/configuration";

  public constructor(private httpClient: HttpClient) {
    const baseUrl = this.loadApiBaseUrl();
    this.apiBaseUrl = baseUrl ?? this.apiBaseUrl;
  }

  public Get(): Observable<IResult<ApiConfiguration>> {
    console.log(`test: ${this.apiBaseUrl}/${this.apiUri}`);
    return this.httpClient.get<any>(`${this.apiBaseUrl}/${this.apiUri}`);
  }

  private loadApiBaseUrl(): string | null | undefined {
    return document.querySelector("meta[name='apiurl']")?.getAttribute("content");
  }

  //public GetProperty(propertyName: string) {
  //  return this.Get().pipe()
  //}
}
