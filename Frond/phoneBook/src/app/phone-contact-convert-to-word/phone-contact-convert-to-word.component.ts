import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-phone-contact-convert-to-word',
  templateUrl: './phone-contact-convert-to-word.component.html',
  styleUrls: ['./phone-contact-convert-to-word.component.css']
})
export class PhoneContactConvertToWordComponent implements OnInit {

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
  }

  generateWord()
  {
    this.http.post("http://localhost:62792/api/convertToWord", {path: "dadad"}).subscribe(x => console.log(x))

  }
}
