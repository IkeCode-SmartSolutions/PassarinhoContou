import { Injectable } from '@angular/core';
import { Http, Response, URLSearchParams } from '@angular/http';
import 'rxjs/Rx';
import { Observable } from 'rxjs/Rx';

import { MessagePrefix } from '../../models/message-prefix';
import { BaseService } from './base-service';

@Injectable()
export class MessagePrefixService extends BaseService {

  constructor(public http: Http) {
    super(http);
    this.BaseUrl += "MessagePrefix/";
  }

  // _allMessagePrefixes: Array<MessagePrefix> = new Array<MessagePrefix>(
  //   new MessagePrefix({
  //     id: 1,
  //     name: 'Não querendo ser chato, mas gostaria de te avisar que',
  //     prefixCategoryId: 3
  //   }),
  //   new MessagePrefix({
  //     id: 2,
  //     name: 'Venho por meio desta, oferecer uma dica amigável',
  //     prefixCategoryId: 2
  //   }),
  //   new MessagePrefix({
  //     id: 3,
  //     name: 'Amigão, sinto lhe informar que',
  //     prefixCategoryId: 1
  //   })
  //   , new MessagePrefix({
  //     id: 4,
  //     name: 'É chato falar mas',
  //     prefixCategoryId: 1
  //   })
  // );

  public get(id: number):Observable<Response> {
    return this.http.get(this.BaseUrl);

    //let result = undefined;

    // this._allMessagePrefixes.forEach(item => {
    //   if (item.id === id) {
    //     result = item;
    //     return;
    //   }
    // });

    //return result;
  }

  public getByCategory(prefixCategoryId: number): Observable<Response> {
    let params = new URLSearchParams();
    params.set('categoryId', prefixCategoryId.toString());

    return this.http.get(this.BaseUrl + prefixCategoryId);

    // let result = new Array<MessagePrefix>();

    // this._allMessagePrefixes.forEach(item => {
    //   if (item.prefixCategoryId === prefixCategoryId) {
    //     result.push(item);
    //     // console.log('messagePreffix added', item.Id);
    //   }
    // });

    // return result;
  }
}

