import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, NgForm, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { formViewModel } from '../models/formViewModel';
import { ExportPDFService } from '../services/export-pdf.service';
import { environment } from 'src/environments/environment';
import { TranslateService } from '@ngx-translate/core';
import { FileSaverService } from 'ngx-filesaver';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-personalizedguide',
  templateUrl: './personalizedguide.component.html',
  styleUrls: ['./personalizedguide.component.scss']
})
export class PersonalizedguideComponent implements OnInit {

  formviewmodel: formViewModel
  containerUrl: string = environment.download_path;
  pdfName: string = '';

  constructor(private exportPDFService: ExportPDFService, private router: Router, private translate: TranslateService, private _httpClient: HttpClient, private _FileSaverService: FileSaverService,) {
    //this.formName = 'Name';
  }

  ngOnInit(): void {
  }

  exportPDF(f: NgForm) {

    this.formviewmodel = {
      language: this.translate.currentLang,
      ck_1_1: f.value.ck_1_1 == '' ? false : f.value.ck_1_1,
      ck_1_2: f.value.ck_1_2 == '' ? false : f.value.ck_1_2,
      ck_1_3: f.value.ck_1_3 == '' ? false : f.value.ck_1_3,
      ck_1_4: f.value.ck_1_4 == '' ? false : f.value.ck_1_4,
      ck_2_1: f.value.ck_2_1 == '' ? false : f.value.ck_2_1,
      ck_2_2: f.value.ck_2_2 == '' ? false : f.value.ck_2_2,
      ck_2_3: f.value.ck_2_3 == '' ? false : f.value.ck_2_3,
      ck_2_4: f.value.ck_2_4 == '' ? false : f.value.ck_2_4,
      ck_2_5: f.value.ck_2_5 == '' ? false : f.value.ck_2_5,
      ck_2_6: f.value.ck_2_6 == '' ? false : f.value.ck_2_6,
      ck_2_7: f.value.ck_2_7 == '' ? false : f.value.ck_2_7,
      ck_3_1: f.value.ck_3_1 == '' ? false : f.value.ck_3_1,
      ck_3_2: f.value.ck_3_2 == '' ? false : f.value.ck_3_2,
      ck_3_3: f.value.ck_3_3 == '' ? false : f.value.ck_3_3,
      ck_3_4: f.value.ck_3_4 == '' ? false : f.value.ck_3_4,
      ck_4_1: f.value.ck_4_1 == '' ? false : f.value.ck_4_1,
      ck_4_2: f.value.ck_4_2 == '' ? false : f.value.ck_4_2,
      ck_4_3: f.value.ck_4_3 == '' ? false : f.value.ck_4_3,
      ck_4_4: f.value.ck_4_4 == '' ? false : f.value.ck_4_4,
      ck_4_5: f.value.ck_4_5 == '' ? false : f.value.ck_4_5,
      ck_4_6: f.value.ck_4_6 == '' ? false : f.value.ck_4_6,
      ck_4_7: f.value.ck_4_7 == '' ? false : f.value.ck_4_7,
      ck_4_8: f.value.ck_4_8 == '' ? false : f.value.ck_4_8,
      ck_4_9: f.value.ck_4_9 == '' ? false : f.value.ck_4_9,
      ck_4_10: f.value.ck_4_10 == '' ? false : f.value.ck_4_10,
      ck_4_11: f.value.ck_4_11 == '' ? false : f.value.ck_4_11,
      ck_5_1: f.value.ck_5_1 == '' ? false : f.value.ck_5_1,
      ck_5_2: f.value.ck_5_2 == '' ? false : f.value.ck_5_2,
      ck_5_3: f.value.ck_5_3 == '' ? false : f.value.ck_5_3,
      ck_5_4: f.value.ck_5_4 == '' ? false : f.value.ck_5_4,
      ck_5_5: f.value.ck_5_5 == '' ? false : f.value.ck_5_5,
      ck_6_1: f.value.ck_6_1 == '' ? false : f.value.ck_6_1,
      ck_6_2: f.value.ck_6_2 == '' ? false : f.value.ck_6_2,
      ck_6_3: f.value.ck_6_3 == '' ? false : f.value.ck_6_3,
      ck_6_4: f.value.ck_6_4 == '' ? false : f.value.ck_6_4,
      ck_6_5: f.value.ck_6_5 == '' ? false : f.value.ck_6_5,
      txt_2_1: f.value.txt_2_1,
      txt_4_1: f.value.txt_4_1,
      txt_5_1: f.value.txt_5_1,
      txt_6_1: f.value.txt_6_1
    }

    this.exportPDFService.sendData(this.formviewmodel).subscribe((result:any) => {
      // console.log(result);
      if(result!= null){
        this._FileSaverService.save(result.document, result.fileName);
      }
      // if (result["message"] === '200 OK') {

      // //   this.pdfName = result["filename"];
      // //   if (this.pdfName.length > 0) {

      // //     var pdfUrl = this.containerUrl + this.pdfName;

      // //     window.location.replace(pdfUrl);
      // //   }



      //   this.pdfName = result["filename"];
      //   if (this.pdfName.length > 0) {

      //     var pdfUrl = this.containerUrl + this.pdfName;



      //     if (/Android|webOS|iPhone|iPad|Mac|Macintosh|iPod|BlackBerry|IEMobile|Opera Mini/i.test(navigator.userAgent)) {

      //       window.location.replace(pdfUrl);
      //       // window.open(pdfUrl, "_blank");
      //     }
      //     else {
      //       this._httpClient.get(pdfUrl, {
      //         observe: 'response',
      //         responseType: 'blob'
      //       }).subscribe(res => {
      //         this._FileSaverService.save(res.body, this.pdfName);
      //       });
      //     }


      //     return;
      //   }

      // }
      // else {
      //   console.log(result);
      // }
    })
  }
}
