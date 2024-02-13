import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { environment } from "src/environments/environment";
import { Injectable } from "@angular/core";
import { ChatGPTResponse } from "../models/response";


@Injectable({
    providedIn: 'root',
})

export class ResponseService{
    private url = 'ChatGPT';

    constructor(private http: HttpClient) {}

    public getResponses(): Observable<ChatGPTResponse[]> {
        return this.http.get<ChatGPTResponse[]>(`${environment.apiUrl}/${this.url}`);
      }
    
}