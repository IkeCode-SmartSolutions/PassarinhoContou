import { Component } from '@angular/core';
import { NavController, ViewController } from 'ionic-angular';

import { SummaryPage } from '../send-message/summary';
import { HomePage } from '../home/home';
import { SendMessageService } from '../../providers/send-message/send-message-service';

@Component({
  templateUrl: 'build/pages/pending-message-popover/pending-message-popover.html',
})
export class PendingMessagePopoverPage {
  rootPage: any = HomePage;
  constructor(private navCtrl: NavController, private sendMessageService: SendMessageService, private viewCtrl: ViewController) {
    
  }

  view(): void {
    this.viewCtrl.dismiss();
    this.navCtrl.push(SummaryPage, { 
      fromResend: true
    });
  }

  discard(): void {
    this.sendMessageService.discard();
    this.viewCtrl.dismiss();
  }
}
