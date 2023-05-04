import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AppComponent } from './app.component';
import { FooterComponent } from './components/footer/footer.component';
import { LogoutModalComponent } from './components/logoutmodal/logout-modal.component';
import { ScrollToTopButtonComponent } from './components/scroll-to-top-button/scroll-to-top-button.component';
import { SidebarComponent } from './components/sidebar/sidebar.component';
import { TableComponent } from './components/table/table.component';
import { TopbarComponent } from './components/topbar/topbar.component';
import { DashboardComponent } from './pages/dashboard/dashboard.component';
import { PageNotFoundComponent } from './pages/page-not-found/page-not-found.component';
import { FormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';

const uiComponents = [
  AppComponent,
  SidebarComponent,
  TopbarComponent,
  FooterComponent,
  LogoutModalComponent,
  ScrollToTopButtonComponent,
  TableComponent,
  DashboardComponent,
  PageNotFoundComponent
]

@NgModule({
  declarations: [...uiComponents],
  imports: [
    CommonModule,
    FormsModule,
    AppRoutingModule
  ],
  exports: [
    CommonModule,
    FormsModule,
    ...uiComponents
  ]
})
export class AppGuiModule { }
