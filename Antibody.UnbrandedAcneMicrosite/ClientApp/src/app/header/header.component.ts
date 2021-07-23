import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { LocalizeRouterService } from '@gilsdav/ngx-translate-router';
import {TranslateService} from '@ngx-translate/core';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})

export class HeaderComponent implements OnInit {

  public language_icon_text: string;
  public currentLanguage:string;
  isHide = false;
  isMobileMenu = false;

  constructor(public translate: TranslateService,public localize: LocalizeRouterService,private router:Router){
    //console.log('ROUTES', this.localize.parser.currentLang);
    //translate.addLangs(['en', 'fr']);
    // translate.setDefaultLang('en');

    // const browserLang = translate.getBrowserLang();
    // translate.use(browserLang.match(/en|fr/) ? browserLang : 'en');
    this.currentLanguage = this.localize.parser.currentLang
    translate.use(this.currentLanguage);


    this.language_icon_text = this.currentLanguage == "en"?"fr":"en";
  }

  ngOnInit(): void {
  }


  switchLanguage(targetLanguage:string){
    this.currentLanguage = targetLanguage;
    //let translatedURL = this.router.url.replace(this.translate.currentLang,targetLanguage);
    //location.replace('/'+ this.currentLanguage+'/home');
    //this.router.navigate('home');
    this.translate.use(targetLanguage);
    this.language_icon_text = targetLanguage == "en"?"fr":"en";

  }

  hideMenu() {
    this.isHide = true;
  }
  ShowMoilbeMenu() {
    this.isMobileMenu = !this.isMobileMenu;
  }
}
