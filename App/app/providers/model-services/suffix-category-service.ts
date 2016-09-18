import { Injectable } from '@angular/core';
import { Http, Response, URLSearchParams } from '@angular/http';
import 'rxjs/Rx';
import { Observable } from 'rxjs/Rx';

import { BaseService } from './base-service';

import { SuffixCategory } from '../../models/suffix-category';

@Injectable()
export class SuffixCategoryService extends BaseService {

  constructor(public http: Http) {
    super(http);
    this.BaseUrl += "/SuffixCategory/"; 
  }
  
  _allSuffixCategories: Array<SuffixCategory> = new Array<SuffixCategory>(
    new SuffixCategory({
      id: 1,
      name: 'Pessoal'
    }),
    new SuffixCategory({
      id: 2,
      name: 'Motivacional'
    }),
    new SuffixCategory({
      id: 3,
      name: 'Dica'
    })
  );

  public getAll(): Observable<Response> {
    console.log('SuffixCategoryService.getAll()');
    return this.http.get(this.BaseUrl);

    //return this._allSuffixCategories;
  }

}