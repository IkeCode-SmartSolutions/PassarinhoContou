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
  _authKeyUsername: string = 'username';

  constructor(private http: Http, private userService: UserService) {
    this._storage = new Storage(LocalStorage);
  }

  authenticate(username: string, password: string): Promise<boolean> {
    this.AuthenticatedUser = this.userService.getByNickname(username);
    console.log('this.AuthenticatedUser', this.AuthenticatedUser ? this.AuthenticatedUser.id : 'not found');
    var isAuthenticated = false;
    if (this.AuthenticatedUser) {
      isAuthenticated = true;
    }

    this._storage.set(this._authKeyUserId, this.AuthenticatedUser.id);
    this._storage.set(this._authKeyUsername, this.AuthenticatedUser.nickName);

    return this._storage.set(this._authKey, isAuthenticated).then<boolean>(() => {
      return this.isAuthenticated().then<boolean>((authenticated) => {
        return authenticated;
      });
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
        this._storage.get(this._authKeyUserId).then((userId) => {
          this._storage.get(this._authKeyUsername).then((username) => {
            this.AuthenticatedUser = new User({ fullName: username, id: userId });
          });
        });
      }

      return (value == 'true' ? true : false);
    });
  }
}

