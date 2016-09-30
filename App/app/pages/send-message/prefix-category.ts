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
    private navParams: NavParams,
    private prefixCategoryService: PrefixCategoryService,
    private sendMessageService: SendMessageService) {

    // prefixCategoryService
    //   .getAll()
    //   .subscribe(res => this.prefixCategories = res.json());

    prefixCategoryService
      .getAll((data) => {
        //console.log('callback data', data);
        this.prefixCategories = data;
      });
  }

  prefixCategoryTapped(event, prefixCategory) {
    this.sendMessageService.PrefixCategory = prefixCategory;
    console.log('sendMessageService.PrefixCategory.name', this.sendMessageService.PrefixCategory.name);
    this.navCtrl.push(MessagePrefixPage);
  }
}
