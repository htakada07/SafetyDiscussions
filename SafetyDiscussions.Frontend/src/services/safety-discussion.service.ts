import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { SafetyDiscussions } from 'src/contracts/safety-discussions';

@Injectable({
  providedIn: 'root'
})
export class SafetyDiscussionService {
  private readonly baseUrl = 'https://localhost:7113/api/SafetyDiscussions';

  constructor(private http: HttpClient) { }

  getAll(): Observable<SafetyDiscussions[]> {
    return this.http.get<SafetyDiscussions[]>(this.baseUrl);
  }

  getById(id: number): Observable<SafetyDiscussions> {
    const url = `${this.baseUrl}/${id}`;
    return this.http.get<SafetyDiscussions>(url);
  }

  create(safetyDiscussion: SafetyDiscussions): Observable<any> {
    return this.http.post(this.baseUrl, safetyDiscussion);
  }

  delete(id: number): Observable<any> {
    const url = `${this.baseUrl}/${id}`;
    return this.http.delete(url);
  }
}
