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
    // If we navigated to this page, we will have an item available as a nav param
    this.listType = navParams.get('listType');
    //let source = <Array<Message>>navParams.get('source');

    this.messages = [];
    this.messages = this.messageService.getMessagesFromLoggedUser();
  }
}
