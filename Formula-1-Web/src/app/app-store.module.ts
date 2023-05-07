import { APP_INITIALIZER, NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { EffectsModule } from '@ngrx/effects';
import { Store, StoreModule } from '@ngrx/store';
import { StoreDevtoolsModule } from '@ngrx/store-devtools';
import { environment } from 'src/environments/environment';
import { reducers } from './store/app.reducer';
import { EntitiesEffects } from './store/entities/entities.effects';
import { HttpClientModule } from '@angular/common/http';
import { ApiService } from './services/api/api.service';
import * as EntitiesActions from 'src/app/store/entities/entities.actions';

@NgModule({
  declarations: [],
  imports: [
    HttpClientModule,
    StoreModule.forRoot({}),
    EffectsModule.forRoot([EntitiesEffects]),
    StoreModule.forFeature('app', reducers),
    !environment.production ? StoreDevtoolsModule.instrument() : []
  ],
})
export class AppStoreModule { }
