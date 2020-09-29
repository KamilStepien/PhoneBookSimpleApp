import { PhoneContactService } from './../../shared/phone-contact.service';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { thistle } from 'color-name';



@Component({
  selector: 'app-phone-contact',
  templateUrl: './phone-contact.component.html',
  styleUrls: ['./phone-contact.component.css']
})
export class PhoneContactComponent implements OnInit {

  phoneContact = new FormGroup({
    firstName:new FormControl('',[Validators.required]),
    lastName: new FormControl('',[Validators.required]),
    phoneNumber: new FormControl('',[Validators.required])
  }
  )

  constructor(public service:PhoneContactService) {}

  ngOnInit(): void {
  }
  addPhoneContact():void
  {

    this.service.addPhoneContact().subscribe(x => this.service.phoneContacts.push(x));
    this.resetForm();
  }

  resetForm():void
  {
    this.phoneContact.reset();
  }



}
