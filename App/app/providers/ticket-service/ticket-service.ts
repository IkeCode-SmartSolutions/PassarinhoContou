import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { NavController, AlertController, ToastController } from 'ionic-angular';
import 'rxjs/add/operator/map';

@Injectable()
export class TicketService {
  public GreenTickets: number = 0;
  public YellowTickets: number = 0;

  constructor(private http: Http, private alertController: AlertController, private toastController: ToastController) {

  }

  private success(successCallback?: Function): void {
    let toast = this.toastController.create({
      message: 'Mensagem enviada com sucesso!',
      //duration: 3000,
      position: 'botton',
      showCloseButton: true,
      closeButtonText: 'OK'
    });
    toast.present();

    if (successCallback)
        successCallback();
  }

  consume(successCallback?: Function, errorCallback?: Function): void {
    console.log('consume');
    if (this.GreenTickets > 0) {
      this.GreenTickets--;
      this.success(successCallback);
    } else if (this.YellowTickets > 0) {
      this.YellowTickets--;
      this.success(successCallback);
    } else {
      let alert = this.alertController.create({
        title: 'Sem Tok-UPs',
        subTitle: 'Você não possui mais Tok-UPs para usar, deseja adquirir mais?',
        buttons: [
          {
            text: 'Não',
            handler: () => {
              console.log('not purchase tok-up');
              if (errorCallback)
                errorCallback();
            }
          },
          {
            text: 'Sim',
            handler: () => {
              this.GreenTickets++;
              console.log('re-consume');
              this.consume(successCallback, errorCallback);
              // let alertPurchase = this.alertController.create({
              //   title: 'Não implementado',
              //   subTitle: 'Você seria redirecionado a seção de compras',
              //   buttons: ['OK']
              // });
              // alertPurchase.present();
            }
          }
        ]
      });
      alert.present();
    }
  }
}

