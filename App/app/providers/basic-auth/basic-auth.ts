import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { Storage, LocalStorage } from 'ionic-angular';
import 'rxjs/add/operator/map';

import { User } from '../../models/user';
import { UserService } from '../user-service/user-service';

@Injectable()
export class BasicAuth {

  public AuthenticatedUser: User = null;
  _storage: Storage;
  _authKey: string = 'isAuthenticated';
  _authKeyUserId: string = 'userId';

  constructor(private http: Http, private userService: UserService) {
    this._storage = new Storage(LocalStorage);
  }

  authenticate(username: string, password: string, callback: (isAuthenticated: boolean) => void): void {
    this.userService.getByNickname(username, user => {
      this.AuthenticatedUser = user;

      //console.log('this.AuthenticatedUser', this.AuthenticatedUser ? this.AuthenticatedUser.id : 'not found');
      var isAuthenticated = false;
      if (this.AuthenticatedUser) {
        isAuthenticated = true;
        this._storage.set(this._authKeyUserId, this.AuthenticatedUser.id);
      }

      this._storage.set(this._authKey, isAuthenticated);

      callback(isAuthenticated);
    });
  }

  logoff(callback: Function): void {
    this._storage.remove(this._authKey).then(() => {
      callback();
    });
  }

  isAuthenticated(): Promise<boolean> {
    return this._storage.get(this._authKey).then<boolean>((value) => {
      // console.log('isAuthenticated()', value);
      var isTrue = value == 'true';

      if (isTrue && !this.AuthenticatedUser) {
        this._storage.get(this._authKeyUserId).then((value) => {
          this.userService.getById(value, (user) => {
            this.AuthenticatedUser = user;
          });
        });
      }

      return (value == 'true' ? true : false);
    });
  }
}

