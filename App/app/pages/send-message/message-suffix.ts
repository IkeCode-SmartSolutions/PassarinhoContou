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
  suffixCategoryName: string = this.sendMessageService.SuffixCategory.name;

  constructor(
    public navCtrl: NavController,
    navParams: NavParams,
    messageSuffixService: MessageSuffixService,
    private sendMessageService: SendMessageService) {
    messageSuffixService.getByCategory(sendMessageService.SuffixCategory.id).subscribe(res => this.messageSuffixes = res.json());
  }

  messagePrefixTapped(event, messageSuffix) {
    this.sendMessageService.MessageSuffix = messageSuffix;
    console.log('sendMessageService.MessageSuffix.name', this.sendMessageService.MessageSuffix.name);
    this.navCtrl.push(SummaryPage);
  }
}
