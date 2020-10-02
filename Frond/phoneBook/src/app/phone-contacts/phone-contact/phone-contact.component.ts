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
    imageSrc: new FormControl(''),
    id:new FormControl(''),
    firstName:new FormControl('',[Validators.required]),
    lastName: new FormControl('',[Validators.required]),
    phoneNumber: new FormControl('',[Validators.required])
  }
  )

  constructor(public service:PhoneContactService) {}

  ngOnInit(): void {
  }
  submit(id:number):void
  {
    if(id.toString() == "")
    {
      this.AddContact();
    }
    else
    {
    this.EditContact(id)
    }
    this.resetForm();

  }

  AddContact()
  {
    this.service.addPhoneContact().subscribe(x => this.service.phoneContacts.push(x));
  }
  EditContact(id:number)
  {
    this.service.editPhoneContact(id).subscribe(x =>   this.service.refreshPhoneContacts());

  }




  resetForm():void
  {
    this.phoneContact.reset();
  }



}
