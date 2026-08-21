import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PdfService {
  constructor(private http: HttpClient) {}

  convertHtmlToPdf(html: string): Observable<Blob> {
    const body = JSON.stringify({ htmlContent: html }); // Send JSON object
  return this.http.post('https://localhost:7268/api/HtmlToPdf', body, {
    headers: { 'Content-Type': 'application/json' }, // Ensure JSON format
    responseType: 'blob'
  });
  }
}
