import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import 'rxjs/add/operator/map';

import { MessagePrefix } from '../../models/message-prefix';

@Injectable()
export class MessagePrefixService {

  constructor(private http: Http) {

  }

  _allMessagePrefixes: Array<MessagePrefix> = new Array<MessagePrefix>(
    new MessagePrefix({
      Id: 1,
      Name: 'Não querendo ser chato, mas gostaria de te avisar que',
      PrefixCategoryId: 3
    }),
    new MessagePrefix({
      Id: 2,
      Name: 'Venho por meio desta, oferecer uma dica amigável',
      PrefixCategoryId: 2
    }),
    new MessagePrefix({
      Id: 3,
      Name: 'Amigão, sinto lhe informar que',
      PrefixCategoryId: 1
    })
    , new MessagePrefix({
      Id: 4,
      Name: 'É chato falar mas',
      PrefixCategoryId: 1
    })
  );

  public get(id: number): MessagePrefix {
    let result = undefined;

    this._allMessagePrefixes.forEach(item => {
      if (item.Id === id) {
        result = item;
        return;
      }
    });

    return result;
  }

  public getByCategory(prefixCategoryId: number): Array<MessagePrefix> {
    let result = new Array<MessagePrefix>();

    this._allMessagePrefixes.forEach(item => {
      if (item.PrefixCategoryId === prefixCategoryId) {
        result.push(item);
        // console.log('messagePreffix added', item.Id);
      }
    });

    return result;
  }
}

