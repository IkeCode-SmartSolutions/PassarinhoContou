import { Component } from '@angular/core';
import { NavController, NavParams } from 'ionic-angular';

import { MessagePrefixService } from '../../providers/model-services/message-prefix-service';
import { MessagePrefix } from '../../models/message-prefix'

import { SuffixCategoryPage } from '../send-message/suffix-category'

import { SendMessageService } from '../../providers/send-message/send-message-service';

@Component({
  templateUrl: 'build/pages/send-message/message-prefix.html',
})
export class MessagePrefixPage {
  messagePrefixes: Array<MessagePrefix>;
  prefixCategoryName: string = this.sendMessageService.PrefixCategory.Name;

  constructor(
    public navCtrl: NavController,
    navParams: NavParams,
    messagePrefixService: MessagePrefixService,
    private sendMessageService: SendMessageService) {
    this.messagePrefixes = messagePrefixService.getByCategory(sendMessageService.PrefixCategory.Id);
  }

  messagePrefixTapped(event, messagePrefix) {
    this.sendMessageService.MessagePrefix = messagePrefix;
    console.log('sendMessageService.MessagePrefix.Name', this.sendMessageService.MessagePrefix.Name);
    this.navCtrl.push(SuffixCategoryPage);
  }
}
