import { PhoneContactService } from './shared/phone-contact.service';
import { HttpClientModule } from '@angular/common/http';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { PhoneContactsComponent } from './phone-contacts/phone-contacts.component';
import { PhoneContactComponent } from './phone-contacts/phone-contact/phone-contact.component';
import { PhoneContactListComponent } from './phone-contacts/phone-contact-list/phone-contact-list.component';
import { ReactiveFormsModule } from '@angular/forms';
import { PhoneContactConvertToWordComponent } from './phone-contact-convert-to-word/phone-contact-convert-to-word.component';


@NgModule({
  declarations: [
    AppComponent,
    PhoneContactsComponent,
    PhoneContactComponent,
    PhoneContactListComponent,
    PhoneContactConvertToWordComponent
  ],
  imports: [
    HttpClientModule,
    BrowserModule,
    ReactiveFormsModule

  ],
  providers: [PhoneContactService],
  bootstrap: [AppComponent]
})
export class AppModule { }
