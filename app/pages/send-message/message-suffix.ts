import { Component } from '@angular/core';
import { NavController, NavParams } from 'ionic-angular';

import { MessageSuffixService } from '../../providers/model-services/message-suffix-service';
import { MessageSuffix } from '../../models/message-suffix'

import { SummaryPage } from '../send-message/summary'

import { SendMessageService } from '../../providers/send-message/send-message-service';

@Component({
  templateUrl: 'build/pages/send-message/message-suffix.html',
})
export class MessageSuffixPage {
  messageSuffixes: Array<MessageSuffix>;
  suffixCategoryName: string = this.sendMessageService.SuffixCategory.Name;

  constructor(
    public navCtrl: NavController,
    navParams: NavParams,
    messageSuffixService: MessageSuffixService,
    private sendMessageService: SendMessageService) {
    this.messageSuffixes = messageSuffixService.getByCategory(sendMessageService.SuffixCategory.Id);
  }

  messagePrefixTapped(event, messageSuffix) {
    this.sendMessageService.MessageSuffix = messageSuffix;
    console.log('sendMessageService.MessageSuffix.Name', this.sendMessageService.MessageSuffix.Name);
    this.navCtrl.push(SummaryPage);
  }
}
