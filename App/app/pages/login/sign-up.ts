import { Component, Input } from '@angular/core';
import { NavController, AlertController  } from 'ionic-angular';

import { User } from '../../models/user';
import { LoginPage } from './login';
import { UserService } from '../../providers/user-service/user-service';

@Component({
  templateUrl: 'build/pages/login/sign-up.html'
})
export class SignUpPage {
  user: User = new User();

  constructor(
    private navCtrl: NavController,
    private alertController: AlertController,
    private userService: UserService) {

  }

  register(): void {
    console.log('register user.nickName', this.user.nickName);
    
    this.userService.add(this.user, data => {
      this.navCtrl.pop();
    });
  }
}
