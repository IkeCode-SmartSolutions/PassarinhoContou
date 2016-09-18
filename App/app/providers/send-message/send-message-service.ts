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

@Injectable()
export class SendMessageService {
  public Contact: any;
  public FromUser: User;
  public PrefixCategory: PrefixCategory;
  public SuffixCategory: SuffixCategory;
  public MessagePrefix: MessagePrefix;
  public MessageSuffix: MessageSuffix;
  public PendingSend: boolean;

  constructor(private http: Http,
    private ticketService: TicketService,
    private events: Events,
    private messageService: MessageService) {
    this.initialize();
  }

  send(successCallback?: Function, errorCallback?: Function): void {
    console.log('send-message-service send');
    this.events.publish('message:send');
    this.ticketService.consume(
      () => {
        this.PendingSend = false;

        var message = new Message({
          MessagePrefix: this.MessagePrefix,
          MessageSuffix: this.MessageSuffix,
          SelectedPrefixId: this.MessagePrefix.id,
          SelectedSuffixId: this.MessageSuffix.Id,
          FromUser: this.FromUser,
          ToUser: new User({FullName: this.Contact.name}),
          CreationDate: new Date(Date.now())
        });
        this.messageService.add(message);

        if (successCallback)
          successCallback();
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

