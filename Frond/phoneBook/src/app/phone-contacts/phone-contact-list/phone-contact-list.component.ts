import { PhoneContactService } from './../../shared/phone-contact.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-phone-contact-list',
  templateUrl: './phone-contact-list.component.html',
  styleUrls: ['./phone-contact-list.component.css']
})
export class PhoneContactListComponent implements OnInit {

  constructor(public service:PhoneContactService) { }

  ngOnInit(): void
  {

  }

  deletePhoneContact(id:number)
  {
    this.service.deletePhoneContact(id).subscribe(x => this.service.getPhoneContacts())
  }
}
