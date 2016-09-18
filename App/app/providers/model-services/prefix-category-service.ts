import { Injectable } from '@angular/core';
import { Http, Response } from '@angular/http';
import 'rxjs/Rx';
import { Observable } from 'rxjs/Rx'; 

import { PrefixCategory } from '../../models/prefix-category';
import { BaseService } from './base-service';

@Injectable()
export class PrefixCategoryService extends BaseService {
  constructor(protected http: Http) {
    super(http);
  }

  _allPrefixCategories: Array<PrefixCategory> = new Array<PrefixCategory>(
    // new PrefixCategory({
    //   id: 1,
    //   name: 'Pessoal'
    // }),
    // new PrefixCategory({
    //   id: 2,
    //   name: 'Motivacional'
    // }),
    // new PrefixCategory({
    //   id: 3,
    //   name: 'Dica'
    // })
  );

  public getAll(): Observable<Response> {
     return this.http.get(this.BaseUrl + "/PrefixCategory");
  }

}

