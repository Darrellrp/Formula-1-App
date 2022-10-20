import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { isDevMode } from '@angular/core';
import { ConfigurationService } from '../../services/configuration.service';
import { tap } from 'rxjs';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  public forecasts: WeatherForecast[] = [];

  constructor(private http: HttpClient, configurationService: ConfigurationService) {
    configurationService.Get()
      .pipe(tap(x => console.log(x.value.apiServerUrl)))
      .subscribe(response => this.loadWeatherForecast(response.value.apiServerUrl));
  }

  private loadWeatherForecast(baseUrl: string) {
    this.http.get<WeatherForecast[]>(baseUrl + 'weatherforecast').subscribe(result => {
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
