import { Injectable } from '@angular/core';
import { Http, Response, URLSearchParams } from '@angular/http';
import 'rxjs/Rx';
import { Observable } from 'rxjs/Rx';

import { BaseService } from './base-service';

import { MessageSuffix } from '../../models/message-suffix';

@Injectable()
export class MessageSuffixService extends BaseService {

  constructor(public http: Http) {
    super(http);
    this.BaseUrl += "/MessageSuffix/";
  }
  _allMessageSuffixes: Array<MessageSuffix> = new Array<MessageSuffix>(
    new MessageSuffix({
      id: 1,
      name: 'Não gostamos quando voce faz piadas sobre judeus',
      suffixCategoryId: 3
    }),
    new MessageSuffix({
      id: 2,
      name: 'Voce poderia dar, ao menos, bom dia as pessoas',
      suffixCategoryId: 3
    }),
    new MessageSuffix({
      id: 3,
      name: 'Voce tem mau halito',
      suffixCategoryId: 2
    })
    , new MessageSuffix({
      id: 4,
      name: 'voce tem chulé, nao tire o sapato perto das pessoas',
      suffixCategoryId: 1
    })
  );

  public get(id: number): MessageSuffix {
    let result = new MessageSuffix();

    this._allMessageSuffixes.forEach(item => {
      if (item.id === id) {
        result = item;
        return;
      }
    });

    return result;
  }

  public getByCategory(suffixCategoryId: number): Observable<Response> {
    let params = new URLSearchParams();
    params.set('categoryId', suffixCategoryId.toString());

    return this.http.get(this.BaseUrl + suffixCategoryId);

    // let result = new Array<MessageSuffix>();

    // this._allMessageSuffixes.forEach(item => {
    //   if (item.suffixCategoryId === suffixCategoryId) {
    //     result.push(item);
    //   }
    // });

    // return result;
  }
}

