import { Component, OnInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';


@Component({
  selector: 'app-whatisacne',
  templateUrl: './whatisacne.component.html',
  styleUrls: ['./whatisacne.component.scss']
})
export class WhatisacneComponent implements OnInit {

  isSadFace = false;
  score: number = 0;
  constructor() { }

  ngOnInit(): void {
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

  calucateScore(event: any){
    var checkedbox = event.target;
    if(checkedbox.checked){
      this.score = this.score + Number(checkedbox.value)
    }
    else{
      this.score = this.score - Number(checkedbox.value)
    }

    //this.isSadFace = this.score > 0 ? true:false;
  }

  //changeface(){

    // var eye = document.getElementById('lefteye')!;
    // if(eye.classList.value.includes('animation')){
    //   eye.classList.remove('animation');
    // }
    // else{
    //   eye.classList.add('animation');
    // }
  //}
}
