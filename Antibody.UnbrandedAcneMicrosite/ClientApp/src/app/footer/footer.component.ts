import { Component, HostListener, OnInit } from '@angular/core';
import { NavigationEnd, NavigationError, NavigationStart, Router } from '@angular/router';
import { LocalizeRouterService } from '@gilsdav/ngx-translate-router';
import { filter } from 'rxjs/operators';

@Component({
  selector: 'app-footer',
  templateUrl: './footer.component.html',
  styleUrls: ['./footer.component.scss']
})
export class FooterComponent implements OnInit {

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

  ngOnInit(): void {
  }

}
