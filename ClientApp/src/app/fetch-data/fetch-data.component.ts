import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { isDevMode } from '@angular/core';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  public forecasts: WeatherForecast[] = [];
  private prodBaseUrl: string = "https://localhost:8080/";

  constructor(http: HttpClient, @Inject('BASE_URL') devBaseUrl: string) {
    const baseUrl = isDevMode() ? devBaseUrl : this.prodBaseUrl;

    http.get<WeatherForecast[]>(baseUrl + 'weatherforecast').subscribe(result => {
      this.forecasts = result;
    }, error => console.error(error));
  }
}

interface WeatherForecast {
  date: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
}
