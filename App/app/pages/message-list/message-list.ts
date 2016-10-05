import { Component } from '@angular/core';
import { NavController, NavParams } from 'ionic-angular';
import { Contacts } from 'ionic-native';

import { Message } from '../../models/message';

import { MessageService } from '../../providers/model-services/message-service';

@Component({
  templateUrl: 'build/pages/message-list/message-list.html'
})
export class MessageListPage {
  icons: string[];
  messages: Array<Message>;
  listType: string = 'Enviadas';

  constructor(
    public navCtrl: NavController,
    navParams: NavParams,
    private messageService: MessageService) {
      
    this.listType = navParams.get('listType');

    this.messages = [];

    if (this.listType == "Enviadas") {
      this.messageService.getMessagesFromLoggedUser(data => {
        //console.log('data', data);
        this.messages = data;
      });
    } else {
      this.messageService.getMessagesToLoggedUser(data => {
        //console.log('data', data);
        this.messages = data;
      });
    }
  }
}
