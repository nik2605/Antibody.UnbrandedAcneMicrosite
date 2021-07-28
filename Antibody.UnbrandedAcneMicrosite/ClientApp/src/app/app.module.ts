import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import {HttpClient, HttpClientModule} from '@angular/common/http';
import {TranslateModule, TranslateLoader} from '@ngx-translate/core';
import {TranslateHttpLoader} from '@ngx-translate/http-loader';


import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { AcnemisconceptionsComponent } from './acnemisconceptions/acnemisconceptions.component';
import { PersonalizedguideComponent } from './personalizedguide/personalizedguide.component';
import { PrivacypolicyComponent } from './privacypolicy/privacypolicy.component';
import { WhatcanidoComponent } from './whatcanido/whatcanido.component';
import { WhatisacneComponent } from './whatisacne/whatisacne.component';
import { PageNotFoundComponent } from './page-not-found/page-not-found.component';
import { HeaderComponent } from './header/header.component';
import { FooterComponent } from './footer/footer.component';
import { LandingComponent } from './landing/landing.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { FileSaverModule } from 'ngx-filesaver';

export function HttpLoaderFactory(httpClient: HttpClient) {
  return new TranslateHttpLoader(httpClient);
}


@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    AcnemisconceptionsComponent,
    PersonalizedguideComponent,
    PrivacypolicyComponent,
    WhatcanidoComponent,
    WhatisacneComponent,
    PageNotFoundComponent,
    HeaderComponent,
    FooterComponent,
    LandingComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    FormsModule,
    ReactiveFormsModule,
    AppRoutingModule,
    HttpClientModule,
    FileSaverModule,
    TranslateModule.forRoot({
      loader: {
        provide: TranslateLoader,
        useFactory: HttpLoaderFactory,
        deps: [HttpClient]
      }
    })
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
