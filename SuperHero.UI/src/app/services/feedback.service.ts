import { HttpClient } from "@angular/common/http";
import { Feedback } from "../models/feedback";
import { Observable } from "rxjs";
import { environment } from "src/environments/environment";
import { Injectable } from "@angular/core";


@Injectable({
    providedIn: 'root',
})

export class FeedbackService{
    private url = 'Feedback';

    constructor(private http: HttpClient) {}

    public getFeedbacks(): Observable<Feedback[]> {
        return this.http.get<Feedback[]>(`${environment.apiUrl}/${this.url}`);
      }
    
      public updateFeedback(feedback: Feedback): Observable<Feedback[]> {
        return this.http.put<Feedback[]>(
          `${environment.apiUrl}/${this.url}`,
          feedback
        );
      }
    
      public createFeedback(feedback: Feedback): Observable<Feedback[]> {
        return this.http.post<Feedback[]>(
          `${environment.apiUrl}/${this.url}`,
          feedback
        );
      }
    
      public deleteFeedback(feedback: Feedback): Observable<Feedback[]> {
        return this.http.delete<Feedback[]>(
          `${environment.apiUrl}/${this.url}/${feedback.id}`
        );
      }
}