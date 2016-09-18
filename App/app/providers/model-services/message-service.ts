import { Injectable, Inject } from '@angular/core';
import { Http } from '@angular/http';
import 'rxjs/add/operator/map';

import { Message, IMessage } from '../../models/message';
import { User, IUser } from '../../models/user';
import { BasicAuth } from '../basic-auth/basic-auth';
import { MessagePrefixService } from './message-prefix-service';
import { MessageSuffixService } from './message-suffix-service';

@Injectable()
export class MessageService {

  private _mock: Array<Message> = new Array<Message>();
  private _lastId: number = 2;

  constructor(
    private http: Http,
    private basicAuth: BasicAuth,
    private messagePrefixService: MessagePrefixService,
    private messageSuffixService: MessageSuffixService) {
    this._mock.push(new Message({
      Id: 1,
      FromUserId: 1,
      FromUser: new User({ FullName: 'Amigo da Agenda #1' }),
      ToUserId: 1,
      ToUser: new User({ FullName: 'Mock Fulano #1' }),
      Status: 1,
      SelectedPrefixId: 1,
      SelectedSuffixId: 1,
      MessageType: 1,
      CreationDate: new Date(2016, 6 + 1, 10, 10, 15, 54)
      // LanguageId: 1,
      // MessagePrefix: this.messagePrefixService.get(1),
      // MessageSuffix: this.messageSuffixService.get(1)
    }));

    this._mock.push(new Message({
      Id: 2,
      FromUserId: 1,
      FromUser: new User({ FullName: 'Amigo da Agenda #2' }),
      ToUserId: 1,
      ToUser: new User({ FullName: 'Mock Fulano #1' }),
      Status: 1,
      SelectedPrefixId: 2,
      SelectedSuffixId: 2,
      MessageType: 1,
      CreationDate: new Date(2016, 7 + 1, 23, 5, 5, 20)
      // LanguageId: 1,
      // MessagePrefix: this.messagePrefixService.get(2),
      // MessageSuffix: this.messageSuffixService.get(2)
    }));

  }

  public getMessagesFrom(userId: number): Array<Message> {
    var result = undefined;

    this._mock.forEach((message, index) => {
      if (message.FromUserId === userId) {
        result = message;
        return;
      }
    });

    return result;
  }

  public getMessagesFromLoggedUser(): Array<Message> {
    var result = undefined;

    // this._mock.forEach((message, index) => {
    //   if (message.FromUserId === this.basicAuth.AuthenticatedUser.Id) {
    //     result = message;
    //     return;
    //   }
    // });
    result = this._mock;

    return result;
  }

  public getMessagesTo(userId: number): Array<Message> {
    var result = undefined;

    // this._mock.forEach((message, index) => {
    //   if (message.ToUserId === userId) {
    //     result = message;
    //     return;
    //   }
    // });
    result = this._mock;

    return result;
  }

  public add(message: IMessage) {
    message.Id = ++this._lastId;
    this._mock.push(new Message(message));
  }
}

