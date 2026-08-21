import { Component } from '@angular/core';
import { PdfService } from './pdf.service';


@Component({
  selector: 'app-root',
  standalone: true,
  templateUrl: './app.component.html',
  imports: [],
})
export class AppComponent {
  htmlContent: string = '';
  constructor(private pdfService: PdfService) {}
  
  loadHtmlFile(event: any) {
  const file = event.target.files[0];
  const reader = new FileReader();

  reader.onload = () => {
    this.htmlContent = reader.result as string;
  };

  if (file) {
    reader.readAsText(file);
  }
}

  downloadPDF() {
	  if (!this.htmlContent) {
      alert('Please load an HTML file first.');
      return;
    }
	
    this.pdfService.convertHtmlToPdf(this.htmlContent).subscribe((blob:Blob) => {
      const url = window.URL.createObjectURL(blob);
      const a = document.createElement('a');
      a.href = url;
      a.download = 'Converted.pdf';
      a.click();
      window.URL.revokeObjectURL(url);
    });
  }
}
