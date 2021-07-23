import { Inject, Injectable } from '@angular/core';
import { HttpClient,HttpHeaders } from '@angular/common/http';
import { Observable, throwError, observable } from 'rxjs';
import { retry, catchError } from 'rxjs/operators';
import { formViewModel } from '../models/formViewModel';

@Injectable({
  providedIn: 'root'
})
export class ExportPDFService {

  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json; charset=utf-8',
    })
  };
  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {

  }

  sendData(formViewModel){
    return this.http.post(this.baseUrl + 'export',JSON.stringify(formViewModel),this.httpOptions)
    .pipe(
      catchError(this.errorHandler)
    )
  }

  errorHandler(error) {
    let errorMessage = '';
    if (error.error instanceof ErrorEvent) {
      // Get client-side error
      errorMessage = error.error.message;
    } else {
      // Get server-side error
      errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}`;
    }
    console.log(errorMessage);
    return throwError(errorMessage);
  }
}
