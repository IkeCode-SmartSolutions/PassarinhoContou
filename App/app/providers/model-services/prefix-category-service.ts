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
    this.BaseUrl = this.BaseUrl + "PrefixCategory/";
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

  public getAll(callback: (data: PrefixCategory[]) => void): void {
    this.http.get(this.BaseUrl).map<Array<PrefixCategory>>(data => {
      //console.log('map data.json()', data.json());
      return data.json();
    }).subscribe(
      data => {
        //console.log('api ONLINE data', data);
        callback(data);
      },
      error => {
        console.log('api ONLINE error', error.json().currentTarget.status);
      });
  }
}

