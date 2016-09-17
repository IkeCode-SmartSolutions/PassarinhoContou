import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import 'rxjs/add/operator/map';

import { SuffixCategory } from '../../models/suffix-category';

@Injectable()
export class SuffixCategoryService {

  constructor(private http: Http) {

  }
  
  _allSuffixCategories: Array<SuffixCategory> = new Array<SuffixCategory>(
    new SuffixCategory({
      Id: 1,
      Name: 'Pessoal'
    }),
    new SuffixCategory({
      Id: 2,
      Name: 'Motivacional'
    }),
    new SuffixCategory({
      Id: 3,
      Name: 'Dica'
    })
  );

  public getAll(): Array<SuffixCategory> {
    return this._allSuffixCategories;
  }

}