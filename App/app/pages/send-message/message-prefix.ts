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
  prefixCategoryName: string = this.sendMessageService.PrefixCategory.name;

  constructor(
    public navCtrl: NavController,
    private navParams: NavParams,
    private messagePrefixService: MessagePrefixService,
    private sendMessageService: SendMessageService) {
    messagePrefixService
      .getByCategory(sendMessageService.PrefixCategory.id)
      .subscribe(res => this.messagePrefixes = res.json());
  }

  messagePrefixTapped(event, messagePrefix) {
    this.sendMessageService.MessagePrefix = messagePrefix;
    console.log('sendMessageService.MessagePrefix.name', this.sendMessageService.MessagePrefix.name);
    this.navCtrl.push(SuffixCategoryPage);
  }
}
