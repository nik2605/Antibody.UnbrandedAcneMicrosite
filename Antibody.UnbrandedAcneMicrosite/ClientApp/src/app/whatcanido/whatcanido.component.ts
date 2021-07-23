import { Component, HostListener, OnInit } from '@angular/core';
import { NavigationEnd, NavigationError, NavigationStart, Router } from '@angular/router';
import { LocalizeRouterService } from '@gilsdav/ngx-translate-router';
import { filter } from 'rxjs/operators';


@Component({
  selector: 'app-whatcanido',
  templateUrl: './whatcanido.component.html',
  styleUrls: ['./whatcanido.component.scss']
})
export class WhatcanidoComponent implements OnInit {

  public currentLanguage: string;
  constructor(public localize: LocalizeRouterService, private router: Router) {
    this.currentLanguage = this.localize.parser.currentLang;
  }

  @HostListener("document:click", ['$event.target'])
  switchLanguage(event) {
    if (event.id == 'language_icon') {
      this.currentLanguage = event.innerText == 'EN' ? 'fr' : "en";
    }
  }


  // switchLanguage(targetLanguage:string){
  //   this.currentLanguage = targetLanguage;
  //   // let translatedURL = this.router.url.replace(this.translate.currentLang,targetLanguage);
  //   // this.router.navigate([translatedURL]);
  // }



  ngOnInit(): void {
  }

  // param ={
  //   personalized_guide_link:'href="{{currentLanguage}}/personalizedguide"'
  // }
}
