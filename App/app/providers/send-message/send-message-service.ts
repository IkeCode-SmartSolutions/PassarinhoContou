import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { Events } from 'ionic-angular';
import 'rxjs/add/operator/map';

import { SuffixCategory } from '../../models/suffix-category'
import { PrefixCategory } from '../../models/prefix-category'
import { MessageSuffix } from '../../models/message-suffix'
import { MessagePrefix } from '../../models/message-prefix'
import { Message } from '../../models/message'
import { User } from '../../models/user'

import { TicketService } from '../../providers/ticket-service/ticket-service';
import { MessageService } from '../../providers/model-services/message-service';

import { BaseService } from '../model-services/base-service';

@Injectable()
export class SendMessageService extends BaseService {
  public Contact: any;
  public FromUser: User;
  public PrefixCategory: PrefixCategory;
  public SuffixCategory: SuffixCategory;
  public MessagePrefix: MessagePrefix;
  public MessageSuffix: MessageSuffix;
  public PendingSend: boolean;

  constructor(public http: Http,
    private ticketService: TicketService,
    private events: Events,
    private messageService: MessageService) {

    super(http);

    this.BaseUrl += "Message/";

    this.initialize();

  }

  send(successCallback?: (data: any) => void, errorCallback?: Function): void {
    console.log('send-message-service send');
    this.events.publish('message:send');
    this.ticketService.consume(
      () => {
        this.PendingSend = false;

        var message = new Message({
          messagePrefix: this.MessagePrefix,
          messageSuffix: this.MessageSuffix,
          selectedPrefixId: this.MessagePrefix.id,
          selectedSuffixId: this.MessageSuffix.id,
          fromUser: this.FromUser,
          toUser: new User({ fullName: this.Contact.name }),
          creationDate: new Date(Date.now())
        });

        //TODO fix it!
        message.id = 0;
        message.fromUserId = 1;
        message.fromUser = null;
        message.toUserId = 2;
        message.toUser = null;

        this.messageService.add(message, successCallback);
      },
      () => {
        this.PendingSend = true;

        if (errorCallback)
          errorCallback();
      });
  }

  discard(callback?: Function): void {
    this.initialize();
    this.events.publish('message:discard');

    if (callback)
      callback();
  }

  private initialize() {
    this.Contact = { name: 'mock' };
    this.PrefixCategory = new PrefixCategory();
    this.SuffixCategory = new SuffixCategory();
    this.MessagePrefix = new MessagePrefix();
    this.MessageSuffix = new MessageSuffix();
    this.PendingSend = false;
  }
}

