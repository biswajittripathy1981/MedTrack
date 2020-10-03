import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';
import { Medicine } from './medicine';


@Injectable({ providedIn: 'root' })

export class MedService {
    private url = 'https://localhost:5001/medicine';
    httpOptions = {
        headers: new HttpHeaders({ 'Content-Type': 'application/json' })
      };
    constructor(private http: HttpClient) { }
    
    getMedicines(): Observable<Medicine[]> {
        return this.http.get<Medicine[]>(this.url)
          .pipe(
            catchError(this.handleError<Medicine[]>('GetMedicines', []))
          );
      }

      getMedicine(id: number): Observable<Medicine> {
        const url = `${this.url}/${id}`;
        return this.http.get<Medicine>(url).pipe(
          catchError(this.handleError<Medicine>(`get id=${id}`))
        );
      }

      addMedicine(medicine: Medicine): Observable<boolean> {
        return this.http.post<boolean>(this.url, medicine, this.httpOptions).pipe(
           catchError(this.handleError<boolean>('addMedicine'))
        );
      }

      updateMedicine(medicine: Medicine): Observable<any> {
        return this.http.put<boolean>(this.url, medicine, this.httpOptions).pipe(
          catchError(this.handleError<any>('updateMedicine'))
        );
      }

      private handleError<T>(operation = 'operation', result?: T) {
        return (error: any): Observable<T> => {
    
         console.error(error); 
         return of(result as T);
        };
      }
}