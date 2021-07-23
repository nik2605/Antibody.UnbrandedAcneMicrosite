import { Component } from '@angular/core';
import { LocalizeRouterService } from '@gilsdav/ngx-translate-router';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'UnbrandedAcneMicrosite';

  constructor(private localize: LocalizeRouterService) {

  }
}
