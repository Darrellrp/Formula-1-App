import { APP_INITIALIZER, NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ROUTES, Route, Router, RouterModule, Routes } from '@angular/router';
import { DashboardComponent } from './pages/dashboard/dashboard.component';
import { PageNotFoundComponent } from './pages/page-not-found/page-not-found.component';
import { HttpClient } from '@angular/common/http';
import { ApiService } from './services/api/api.service';

const wildCardRoute: Route = { path: '**', redirectTo: '/404' };

const routes: Routes = [
  { path: '', component: DashboardComponent, pathMatch: 'full' },
  { path: '404', component: PageNotFoundComponent }
];

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forRoot([...routes, wildCardRoute])
  ],
  providers: [
    {
      provide: APP_INITIALIZER,
      useFactory: loadRoutesFromApi,
      multi: true,
      deps: [ApiService, Router],
    },
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }

function loadRoutesFromApi(apiService: ApiService, router: Router): () => Promise<void> {
  return () =>
    new Promise((resolve) => {
      apiService.GetEndpoints().pipe().subscribe(endpoints => {
        const apiRoutes: Array<Route> = [...routes];

        endpoints.forEach(e => {
          apiRoutes.push({
            path: e.key,
            component: DashboardComponent,
          });
        });

        apiRoutes.push(wildCardRoute);

        router.resetConfig(apiRoutes);
        resolve();
      });
    });
}
