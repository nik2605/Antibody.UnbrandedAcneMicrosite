import { HttpClient } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { ExtraOptions, RouterModule, Routes } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';
import {
  LocalizeRouterModule, LocalizeParser, ManualParserLoader, CacheMechanism,
  LocalizeRouterSettings
} from '@gilsdav/ngx-translate-router';
import { LocalizeRouterHttpLoader } from 'localize-router-http-loader';
import { AcnemisconceptionsComponent } from './acnemisconceptions/acnemisconceptions.component';
import { HomeComponent } from './home/home.component';
import { PageNotFoundComponent } from './page-not-found/page-not-found.component';
import { PersonalizedguideComponent } from './personalizedguide/personalizedguide.component';
import { PrivacypolicyComponent } from './privacypolicy/privacypolicy.component';
import { WhatcanidoComponent } from './whatcanido/whatcanido.component';
import { WhatisacneComponent } from './whatisacne/whatisacne.component';
import { CommonModule, Location } from '@angular/common';
import { CookiepolicyComponent } from './cookiepolicy/cookiepolicy.component';

export function HttpLoaderFactory(translate: TranslateService, location: Location, settings: LocalizeRouterSettings, http: HttpClient) {
  return new LocalizeRouterHttpLoader(translate, location, settings, http);
}

const routerOptions: ExtraOptions = {
  onSameUrlNavigation: "reload",
  enableTracing: true,
  scrollPositionRestoration: 'enabled',
  anchorScrolling: 'enabled',
  //scrollOffset: [0, 90],
};


const routes: Routes = [
  { path: 'home', component: HomeComponent },
  { path: 'personalizedguide', component: PersonalizedguideComponent },
  { path: 'privacypolicy', component: PrivacypolicyComponent },
  { path: 'cookiepolicy', component: CookiepolicyComponent },
  // { path: 'whatcanido', component: WhatcanidoComponent },
  // { path: 'whatisacne', component: WhatisacneComponent },
  // { path: 'acnemisconceptions', component: AcnemisconceptionsComponent },
  { path: '', component: HomeComponent, pathMatch: 'full' },
  { path: '**', component: PageNotFoundComponent },
];

@NgModule({
  imports: [
    CommonModule,
    RouterModule.forRoot(routes),
    //RouterModule.forRoot(routes),
    LocalizeRouterModule.forRoot(routes, {
      parser: {
        provide: LocalizeParser,
        useFactory: HttpLoaderFactory,
        deps: [TranslateService, Location, LocalizeRouterSettings, HttpClient]
      }
    })
  ],
  exports: [RouterModule, LocalizeRouterModule]
})
export class AppRoutingModule { }
