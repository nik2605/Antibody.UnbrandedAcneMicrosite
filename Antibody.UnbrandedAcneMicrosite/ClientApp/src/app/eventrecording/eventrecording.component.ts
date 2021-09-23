import { Component, ElementRef, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { interval, observable, Observable, of, Subscription, timer } from 'rxjs';
import { catchError, filter, first, mergeMap, switchMap } from 'rxjs/operators';
import { uservideoprogressService } from '../services/uservideoprogressService.service';
import { Guid } from 'guid-typescript';
import { uservideoprogress } from '../models/uservideoprogress';


@Component({
  selector: 'app-eventrecording',
  templateUrl: './eventrecording.component.html',
  styleUrls: ['./eventrecording.component.scss']
})
export class EventrecordingComponent implements OnInit, OnDestroy {
  // @ViewChild("videoPlayer", { static: false }) videoPlayer: ElementRef;

  miliseconds = 30 * 1000;
  subscription: Subscription;
  uservideoprogress: uservideoprogress;
  userGuid;
  isRecordingStart: boolean = false;


  constructor(private uservideoprogressservice: uservideoprogressService) { }

  ngOnInit(): void {
    this.userGuid = Guid.create().toString();
    var video = document.getElementById('video1');

    //video.addEventListener("playing", this.TurnonTimeRecord);
    this.StartRecording();
  }

  async postprogress(video1) {
    var time = await Math.floor(video1.currentTime);
    if (time > 0) {
      return this.uservideoprogressservice.PostUserVideoProgress(this.userGuid, time, 1).subscribe(data => { });
    }
  }

  TurnonTimeRecord() {
    if (!this.isRecordingStart) {
      this.isRecordingStart = true;
    }
  }

  StartRecording() {
    var video1 = document.getElementById('video1') as HTMLMediaElement;
    this.subscription = interval(this.miliseconds)
      .pipe(
        mergeMap(async () => {
          this.postprogress(video1)
        }

        )
      )
      .subscribe()
  }

  ngOnDestroy() {
    if (this.subscription) {
      this.subscription.unsubscribe();
    }
  }
}
