import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { AppComponent } from './app.component';
import { SidebarComponent } from './components/sidebar/sidebar.component';
import { TopbarComponent } from './components/topbar/topbar.component';
import { FooterComponent } from './components/footer/footer.component';
import { LogoutModalComponent } from './components/logoutmodal/logout-modal.component';
import { ScrollToTopButtonComponent } from './components/scroll-to-top-button/scroll-to-top-button.component';
import { TableComponent } from './components/table/table.component';
import { DashboardComponent } from './pages/dashboard/dashboard.component';
import { PageNotFoundComponent } from './pages/page-not-found/page-not-found.component';
import { AppRoutingModule } from './app-routing.module';
import { AppStoreModule } from './app-store.module';
import { CommonModule } from '@angular/common';
import { AppGuiModule } from './app-gui.module';

@NgModule({
  declarations: [],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    AppGuiModule,
    AppStoreModule
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
