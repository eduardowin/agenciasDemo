import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { catchError, tap, map } from 'rxjs/operators';
import { Agencias } from '../pages/models/agencias';
import { Observable, of } from 'rxjs';

const apiUrl = "https://localhost:44326/api/Agencias/GetAgencias/a/1/10";

const httpOptions = {
  headers: new HttpHeaders({
    Authorization: 'Bearer ' + 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IkVkdWFyZG9Vc2VyIiwidkRhdGFVc3VhcmlvIjoie1wiVXN1YXJpb0lkXCI6XCJFZHVhcmRvVXNlclwiLFwiTm9tYnJlVXN1XCI6XCJVc3VhcmlvIEFkbWluaXN0cmFkb3JcIixcIkNvcnJlb0VsZXRyb25pY29cIjpcImVkdWFyZG93b25AZ21haWwuY29tXCIsXCJSb2xJZFwiOlwiMVwiLFwiTm9tYnJlUm9sXCI6XCJSb2xBZG1pbmlzdHJhZG9yXCJ9IiwianRpIjoiNDE0MGMxYzItMDdkMy00M2U0LTk1ZDMtNWYwMmJmNjAxMzM5IiwibmJmIjoxNTc0NzI1ODI5LCJleHAiOjE1NzQ3Mjk0MjksImlhdCI6MTU3NDcyNTgyOSwiaXNzIjoiaHR0cDovL2xvY2FsaG9zdDo0OTIyMCIsImF1ZCI6Imh0dHA6Ly9sb2NhbGhvc3Q6NDkyMjAifQ.VbSacjSDOxqsXniM8LYcs27PGDf3YNiILANKfbLQj0A',
    'Content-Type': 'application/json'
  })
}; 

@Injectable({
  providedIn: 'root'
})
export class AgenciasService {

  constructor(private http: HttpClient) { }
  getAgencias (): Observable<any> {
      return this.http.get(apiUrl,httpOptions);
  }
  private handleError<T> (operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {

      // TODO: send the error to remote logging infrastructure
      console.error(error); // log to console instead

      // Let the app keep running by returning an empty result.
      return of(result as T);
    };
  }
}
