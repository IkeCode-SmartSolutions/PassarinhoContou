import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import 'rxjs/add/operator/map';

import { User } from '../../models/user';
import { Message } from '../../models/message';

@Injectable()
export class UserService {

  private _usersMock: Array<User> = new Array<User>();
  private _lastId: number = 1;

  constructor(private http: Http) {
    this._usersMock.push(new User({
      id: 1,
      fullName: 'Leandro Barral',
      email: 'leandro.barral@yep.net.br',
      nickName: 'Barral',
      phoneNumber: '11988856996',
      registerDate: new Date(),
      messagesFrom: new Array<Message>(),
      messagesTo: new Array<Message>(),
    }));
  }

  public getAll(): Array<User> {
    return this._usersMock;
  }

  public getById(id: number): User {
    var result = undefined;

    this._usersMock.forEach((user, index) => {
      if (user.id === id) {
        result = user;
        return;
      }
    });

    return result;
  }

  public getByNickname(nickname: string): User {
    var result = undefined;

    //console.log('getByNickname this._usersMock.length', this._usersMock.length);

    this._usersMock.forEach((user, index) => {
      // console.log('getByNickname user.NickName', user.NickName);
      // console.log('getByNickname nickname', nickname);
      if (user.nickName === nickname) {
        result = user;
        return;
      }
    });

    return result;
  }

  public add(user: any){
    user.Id = ++this._lastId;
    this._usersMock.push(new User(user));
    //console.log('add this._usersMock.length', this._usersMock.length);
  }
}