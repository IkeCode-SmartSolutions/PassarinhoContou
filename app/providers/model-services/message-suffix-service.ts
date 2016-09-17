import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import 'rxjs/add/operator/map';

import { MessageSuffix } from '../../models/message-suffix';

@Injectable()
export class MessageSuffixService {

  constructor(private http: Http) {

  }
  _allMessageSuffixes: Array<MessageSuffix> = new Array<MessageSuffix>(
    new MessageSuffix({
      Id: 1,
      Name: 'Não gostamos quando voce faz piadas sobre judeus',
      SuffixCategoryId: 3
    }),
    new MessageSuffix({
      Id: 2,
      Name: 'Voce poderia dar, ao menos, bom dia as pessoas',
      SuffixCategoryId: 3
    }),
    new MessageSuffix({
      Id: 3,
      Name: 'Voce tem mau halito',
      SuffixCategoryId: 2
    })
    , new MessageSuffix({
      Id: 4,
      Name: 'voce tem chulé, nao tire o sapato perto das pessoas',
      SuffixCategoryId: 1
    })
  );

  public get(id: number): MessageSuffix {
    let result = new MessageSuffix();

    this._allMessageSuffixes.forEach(item => {
      if (item.Id === id) {
        result = item;
        return;
      }
    });

    return result;
  }

  public getByCategory(suffixCategoryId: number): Array<MessageSuffix> {
    let result = new Array<MessageSuffix>();

    this._allMessageSuffixes.forEach(item => {
      if (item.SuffixCategoryId === suffixCategoryId) {
        result.push(item);
      }
    });

    return result;
  }
}

