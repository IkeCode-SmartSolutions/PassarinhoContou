import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import 'rxjs/add/operator/map';

import { User } from '../../models/user';
import { Message } from '../../models/message';

import { BaseService } from '../model-services/base-service';

@Injectable()
export class UserService extends BaseService {

  constructor(public http: Http) {

    super(http);
    this.BaseUrl += "User/";

  }

  public getAll(callback: (users: User[]) => void): void {
    this.http.get(this.BaseUrl + "All").map<User[]>(data => {
      //console.log('map data.json()', data.json());
      return data.json();
    }).subscribe(
      data => {
        console.log('api user.getAll data', data);
        callback(data);
      },
      error => {
        console.log('api user.getAll error', error.status);
      });
  }

  public getById(id: number, callback: (user: User) => void): void {
    this.http.get(this.BaseUrl + "ById/" + id).map<User>(data => {
      //console.log('map data.json()', data.json());
      return data.json();
    }).subscribe(
      data => {
        //console.log('api ONLINE data', data);
        callback(data);
      },
      error => {
        console.log('api user.getById error', error.status);
      });
  }

  public getByNickname(nickname: string, callback: (user: User) => void): void {
    this.http.get(this.BaseUrl + "ByNickname/" + nickname).map<User>(data => {
      //console.log('map data.json()', data.json());
      return data.json();
    }).subscribe(
      data => {
        //console.log('api ONLINE data', data);
        callback(data);
      },
      error => {
        console.log('api user.getByNickname error', error.status);
        if (error.status == 404) {
          callback(null);
        }
      });
  }

  public add(user: any, callback: (data) => void): void {
    this.http.post(this.BaseUrl + "Add", user).map(data => {
      //console.log('map data.json()', data.json());
      return data.json();
    }).subscribe(
      data => {
        //console.log('api ONLINE data', data);
        callback(data);
      },
      error => {
        console.log('api user.add error', error.status);
      });
  }
}