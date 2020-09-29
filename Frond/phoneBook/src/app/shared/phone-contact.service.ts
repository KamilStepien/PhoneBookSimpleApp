import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { PhoneContactModule } from './phone-contact.module';

@Injectable({
  providedIn: 'root'
})
export class PhoneContactService {

  phoneContacts: PhoneContactModule[];
  phoneContact: PhoneContactModule =
  {
    id:null,
    firstName:null,
    lastName:null,
    phoneNumber: null
  }

  constructor(private http:HttpClient) {
    this.getPhoneContacts();
   }

  getPhoneContacts()
  {
    this.http.get<PhoneContactModule[]>("http://localhost:62792/api/phoneContact").subscribe(
      result => this.phoneContacts =  result
    );
  }

  getPhoneContact(id:number)
  {
    this.http.get<PhoneContactModule>("http://localhost:62792/api/phoneContact/" + id).subscribe(
      result => this.phoneContact = result
    )
  }

  addPhoneContact()
  {
    this.phoneContact.id=0;
    return this.http.post<PhoneContactModule>("http://localhost:62792/api/phoneContact",this.phoneContact)
  }

  deletePhoneContact(id:number)
  {
    return this.http.delete<PhoneContactModule>("http://localhost:62792/api/phoneContact/"+id)
  }
}
