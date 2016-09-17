import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import 'rxjs/add/operator/map';

import { PrefixCategory } from '../../models/prefix-category';

@Injectable()
export class PrefixCategoryService {

  constructor(private http: Http) {

  }

  _allPrefixCategories: Array<PrefixCategory> = new Array<PrefixCategory>(
    new PrefixCategory({
      Id: 1,
      Name: 'Pessoal'
    }),
    new PrefixCategory({
      Id: 2,
      Name: 'Motivacional'
    }),
    new PrefixCategory({
      Id: 3,
      Name: 'Dica'
    })
  );

  public getAll(): Array<PrefixCategory> {
    return this._allPrefixCategories;
  }

}

