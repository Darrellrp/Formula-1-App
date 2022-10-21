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

  constructor(private http: HttpClient, private configurationService: ConfigurationService) {
    this.loadWeatherForecast();
  }

  private loadWeatherForecast() {
    const apiBaseUrl = this.configurationService.GetApiBaseUrl();
    console.log(`apiBaseUrl: ${apiBaseUrl}`);
    this.http.get<WeatherForecast[]>(apiBaseUrl + '/api/weatherforecast')
      .pipe(tap(x => console.log(x)))
      .subscribe(result => {
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
