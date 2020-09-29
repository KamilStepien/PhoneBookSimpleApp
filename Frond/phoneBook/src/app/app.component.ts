import { PhoneContactModule } from './shared/phone-contact.module';

import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent 
{
    phoneContacts: PhoneContactModule [];


  constructor( private http:HttpClient)
  {
    http.get<PhoneContactModule[]>("http://localhost:62792/api/phoneContact").subscribe(result => this.phoneContacts = result)
  }

}
