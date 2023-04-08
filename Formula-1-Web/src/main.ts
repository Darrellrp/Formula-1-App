import { InjectionToken, enableProdMode } from '@angular/core';
import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';

import { AppModule } from './app/app.module';
import { environment } from './environments/environment';

export function getBaseUrl(): string | null | undefined {
  return document.querySelector("meta[name='apiurl']")?.getAttribute("content");
}

export const APP_BASEURL = new InjectionToken<string>('app.baseUrl');

const providers = [
  { provide: APP_BASEURL, useFactory: getBaseUrl, deps: [] }
];

if (environment.production) {
  enableProdMode();
}

platformBrowserDynamic(providers).bootstrapModule(AppModule)
  .catch(err => console.log(err));
