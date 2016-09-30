import { Injectable, Inject } from '@angular/core';
import { Http } from '@angular/http';
import 'rxjs/add/operator/map';

import { Message, IMessage } from '../../models/message';
import { User, IUser } from '../../models/user';
import { BasicAuth } from '../basic-auth/basic-auth';
import { MessagePrefixService } from './message-prefix-service';
import { MessageSuffixService } from './message-suffix-service';

import { BaseService } from '../model-services/base-service';

@Injectable()
export class MessageService extends BaseService {
  constructor(
    public http: Http,
    private basicAuth: BasicAuth,
    private messagePrefixService: MessagePrefixService,
    private messageSuffixService: MessageSuffixService) {

    super(http);
    this.BaseUrl += "Message/";

  }

  private getMessages(fromTo: string, userId: number, callback: (data: Message[]) => void): void {
    this.http.get(this.BaseUrl + fromTo + "/" + userId).map<Array<Message>>(data => {
      //console.log('map data.json()', data.json());
      return data.json();
    }).subscribe(
      data => {
        //console.log('api data', data);
        callback(data);
      },
      error => {
        console.log('api error', error.json().currentTarget.status);
      });
  }

  public getMessagesFrom(userId: number, callback: (data: Message[]) => void): void {
    this.getMessages("From", userId, callback);
  }

  public getMessagesFromLoggedUser(callback: (data: Message[]) => void): void {
    //console.log('auth user id', this.basicAuth.AuthenticatedUser.id);
    //TODO dps que fizer o login colocar id certo aqui
    this.getMessagesFrom(1, callback);
  }

  public getMessagesTo(userId: number, callback: (data: Message[]) => void): void {
    this.getMessages("To", userId, callback);
  }

  public getMessagesToLoggedUser(callback: (data: Message[]) => void): void {
    //console.log('auth user id', this.basicAuth.AuthenticatedUser.id);
    //TODO dps que fizer o login colocar id certo aqui
    this.getMessagesTo(1, callback);
  }

  public add(message: IMessage, callback?: (data: any) => void): void {
    this.http.post(this.BaseUrl + "Add", message).map(data => data.json()).subscribe(
      data => {
        console.log('Message POST OK data', data);
        if (callback)
          callback(data);
      },
      error => {
        console.log('Message POST ERROR', error.json());
      });
  }
}

