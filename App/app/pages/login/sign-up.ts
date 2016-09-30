import { Component, Input } from '@angular/core';
import { NavController, AlertController, Platform  } from 'ionic-angular';
import { Sim } from 'ionic-native';

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
    private userService: UserService,
    private platform: Platform) {

      if (this.platform.is('cordova')) {
        Sim.getSimInfo().then(val => {
          console.log(val);
          console.log(val.mnc);
        });
      }
      
  }

  register(): void {
    console.log('register user.nickName', this.user.nickName);

    this.userService.add(this.user, data => {
      this.navCtrl.pop();
    });
  }
}
