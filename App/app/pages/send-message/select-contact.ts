import { Component } from '@angular/core';
import { NavController, NavParams, Platform } from 'ionic-angular';
import { Contacts } from 'ionic-native';

import { User } from '../../models/user';

import { PrefixCategoryPage } from '../send-message/prefix-category';
import { UserService } from '../../providers/user-service/user-service';
import { SendMessageService } from '../../providers/send-message/send-message-service';

@Component({
  templateUrl: 'build/pages/send-message/select-contact.html',
})
export class SelectContactPage {
  contacts: Array<User>;

  constructor(
    public navCtrl: NavController,
    navParams: NavParams,
    private sendMessageService: SendMessageService,
    private platform: Platform,
    private userService: UserService) {

    userService.getAll((users)=>{
      this.contacts = users;
    });


    // if (this.platform.is('cordova')) {
    //   Contacts.find(['*'], { filter: '', multiple: true, hasPhoneNumber: true }).then((contacts) => {
    //     console.log('contacts.length', contacts.length);

    //     contacts.forEach(i => {

    //       this.contacts.push({
    //         name: i.displayName,
    //         phoneNumber: i.phoneNumbers[0].value,
    //         icon: 'person'
    //       });

    //     });

    //   });
    // } else {
    //   if (this.contacts.length == 0) {
    //     this.contacts.push({
    //       name: 'Contato para WEB',
    //       phoneNumber: '11 99999999',
    //       icon: 'person'
    //     });
    //   }
    // }
  }

  contactTapped(event, contact) {
    this.sendMessageService.Contact = contact;
    console.log('sendMessageService.Contact.fullName ->', this.sendMessageService.Contact.fullName);
    this.navCtrl.push(PrefixCategoryPage);
  }
}
