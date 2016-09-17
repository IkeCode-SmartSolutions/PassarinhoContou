import { Component } from '@angular/core';
import { NavController, NavParams } from 'ionic-angular';

import { PrefixCategoryService } from '../../providers/model-services/prefix-category-service';
import { PrefixCategory } from '../../models/prefix-category'

import { MessagePrefixPage } from '../send-message/message-prefix'

import { SendMessageService } from '../../providers/send-message/send-message-service';

@Component({
  templateUrl: 'build/pages/send-message/prefix-category.html',
})
export class PrefixCategoryPage {
  prefixCategories: Array<PrefixCategory>;

  constructor(
    public navCtrl: NavController,
    navParams: NavParams,
    prefixCategoryService: PrefixCategoryService,
    private sendMessageService: SendMessageService) {
    this.prefixCategories = prefixCategoryService.getAll();
  }

  prefixCategoryTapped(event, prefixCategory) {
    this.sendMessageService.PrefixCategory = prefixCategory;
    console.log('sendMessageService.PrefixCategory.Name', this.sendMessageService.PrefixCategory.Name);
    this.navCtrl.push(MessagePrefixPage);
  }
}
