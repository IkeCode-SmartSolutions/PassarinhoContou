import { Component } from '@angular/core';
import { NavController, AlertController  } from 'ionic-angular';

import { PassarinhoContouApp } from '../../app'

import { BasicAuth } from '../../providers/basic-auth/basic-auth';

import { SignUpPage } from './sign-up';

@Component({
  templateUrl: 'build/pages/login/login.html'
})
export class LoginPage {
  public model: any = { username: '', password: '' };

  constructor(
    private navCtrl: NavController,
    private basicAuth: BasicAuth,
    private alertController: AlertController) {

  }

  signin(): void {
    //console.log('login model', this.model);
    if (this.model.username.length > 0 && this.model.password.length > 0) {
      this.basicAuth.authenticate(this.model.username, this.model.password).then((isAuthenticated) => {
        if (isAuthenticated) {
          this.navCtrl.setRoot(PassarinhoContouApp);
        } else {
          let alert = this.alertController.create({
            title: 'Não autorizado!',
            subTitle: 'Usuário e/ou Senha inválidos',
            buttons: ['OK']
          });
          alert.present();
        }
      });
    } else {
      let alert = this.alertController.create({
        title: 'Ooops!',
        subTitle: 'Preencha todos os campos para fazer o login.',
        buttons: ['OK']
      });
      alert.present();
    }
  }

  signup(): void {
    this.navCtrl.push(SignUpPage);
  }
}
