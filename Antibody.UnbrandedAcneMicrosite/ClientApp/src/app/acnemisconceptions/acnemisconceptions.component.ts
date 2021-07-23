import { Component, HostListener, OnInit } from '@angular/core';
import { NavigationEnd, NavigationError, NavigationStart, Router } from '@angular/router';
import { LocalizeRouterService } from '@gilsdav/ngx-translate-router';
import { filter } from 'rxjs/operators';


@Component({
  selector: 'app-acnemisconceptions',
  templateUrl: './acnemisconceptions.component.html',
  styleUrls: ['./acnemisconceptions.component.scss']
})
export class AcnemisconceptionsComponent implements OnInit {

  public currentLanguage: string;
  constructor(public localize: LocalizeRouterService, private router: Router) {
    this.currentLanguage = this.localize.parser.currentLang;
  }

  ngOnInit(): void {
  }

  @HostListener("document:click", ['$event.target'])
  switchLanguage(event) {
    if (event.id == 'language_icon') {
      this.currentLanguage = event.innerText == 'EN' ? 'fr' : "en";
    }
  }


  flipcard(event: any) {
    var card_inner = event.currentTarget.firstChild;
    if (card_inner.classList.value.includes('flipSingleCard')) {
      card_inner.classList.remove('flipSingleCard')
    }
    else {
      card_inner.classList.add('flipSingleCard')
    }
  }
}
