
import { Component, Inject, OnInit, PLATFORM_ID } from '@angular/core';
import { Router, Event, Scroll, NavigationEnd } from '@angular/router';
import { isPlatformBrowser } from '@angular/common';
import { environment } from 'src/environments/environment';
declare let gtag: Function;

const isInViewport = (elem) => {
  const bounding = elem.getBoundingClientRect();
  return (
    bounding.top >= 0 &&
    bounding.left >= 0 &&
    bounding.bottom <= (window.innerHeight || document.documentElement.clientHeight) &&
    bounding.right <= (window.innerWidth || document.documentElement.clientWidth)
  );
};

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'UnbrandedAcneMicrosite';

  readonly HEADER_OFFSET = -90;
  readonly SCROLL_DELAY = 700;
  constructor(
    private router: Router,
    @Inject(PLATFORM_ID) private platformId: any
  ) {

    this.router.events.subscribe(event => {
      if(event instanceof NavigationEnd){
        gtag('config', environment.googleAnalyticsTrackingID, {
          'page_title' : event.urlAfterRedirects,
          'page_path': event.urlAfterRedirects
          });
          }
        });

   }

  ngOnInit() {

    this.router.events.subscribe((event: Event) => {
      if (event instanceof Scroll && event.anchor && isPlatformBrowser(this.platformId)) {
        setTimeout(() => {
          const targetElement = document.querySelector('#' + event.anchor);
          if (!targetElement || event.anchor=='landing') {
            window.scrollTo(0, 0);
          } else if (!isInViewport(targetElement)) {
            targetElement.scrollIntoView();
            //window.scrollBy(0, this.HEADER_OFFSET);
          }

        }, this.SCROLL_DELAY);
      }
    });

  }
}
