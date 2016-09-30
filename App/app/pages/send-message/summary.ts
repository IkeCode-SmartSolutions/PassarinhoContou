import { Component, OnDestroy } from '@angular/core';
import { NavController, NavParams } from 'ionic-angular';

import { MessageSuffixService } from '../../providers/model-services/message-suffix-service';
import { MessageSuffix } from '../../models/message-suffix';

import { SuffixCategoryPage } from '../send-message/suffix-category';

import { HomePage } from '../home/home';
import { PassarinhoContouApp } from '../../app';

import { SendMessageService } from '../../providers/send-message/send-message-service';
import { BasicAuth } from '../../providers/basic-auth/basic-auth';

@Component({
  templateUrl: 'build/pages/send-message/summary.html',
})
export class SummaryPage implements OnDestroy {
  fromResend: boolean = false;
  constructor(
    navParams: NavParams,
    private navCtrl: NavController,
    private messageSuffixService: MessageSuffixService,
    private sendMessageService: SendMessageService,
    private basicAuth: BasicAuth) {

    this.fromResend = navParams.get('fromResend');
    console.log('summary fromResend', this.fromResend);

    this.sendMessageService.PendingSend = true;
  }

  ngOnDestroy() {
    
  }

  sendMessage(): void {
    console.log("summary sendMessage() this.basicAuth.AuthenticatedUser", this.basicAuth.AuthenticatedUser);
    this.sendMessageService.FromUser = this.basicAuth.AuthenticatedUser;
    this.sendMessageService.send(
      (data) => {
        console.log('summary success');
        this.navCtrl.setRoot(HomePage);
      },
      () => {
        console.log('summary error');
        this.navCtrl.setRoot(HomePage);
      });
  }

  discard(): void {
    this.navCtrl.setRoot(HomePage);
    this.sendMessageService.discard();
  }
}
