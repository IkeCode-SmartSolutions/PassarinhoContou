import { Component, ViewChild, OnInit } from '@angular/core';
import {
  ionicBootstrap,
  Platform,
  Nav,
  Storage,
  LocalStorage,
  PopoverController,
  Events
} from 'ionic-angular';
import { StatusBar } from 'ionic-native';

import { HomePage } from './pages/home/home';
import { MessageListPage } from './pages/message-list/message-list';
import { SelectContactPage } from './pages/send-message/select-contact';

import { LoginPage } from './pages/login/login';
import { BasicAuth } from './providers/basic-auth/basic-auth';
import { UserService } from './providers/user-service/user-service';
import { PendingMessagePopoverPage } from './pages/pending-message-popover/pending-message-popover';
import { SummaryPage } from './pages/send-message/summary';

import { SendMessageService } from './providers/send-message/send-message-service';
import { TicketService } from './providers/ticket-service/ticket-service';

import { MessageService } from './providers/model-services/message-service';
import { MessagePrefixService } from './providers/model-services/message-prefix-service';
import { MessageSuffixService } from './providers/model-services/message-suffix-service';
import { SuffixCategoryService } from './providers/model-services/suffix-category-service';
import { PrefixCategoryService } from './providers/model-services/prefix-category-service';

@Component({
  templateUrl: 'build/app.html'
})
export class PassarinhoContouApp implements OnInit {
  @ViewChild(Nav) nav: Nav;

  ngOnInit() {
    //console.log('app onInit');
  }

  rootPage: any = HomePage;

  public pages: Array<{ title: string, icon: string, component: any, params?: any }>;

  showFooter: boolean = true;

  constructor(
    public platform: Platform,
    public basicAuth: BasicAuth,
    public ticketService: TicketService,
    public sendMessageService: SendMessageService,
    public messageService: MessageService,
    public popoverController: PopoverController,
    public events: Events) {

    this.pages = [
      { title: 'Enviar Mensagem', icon: 'send', component: SelectContactPage },
      {
        title: 'Mensagens Enviadas', icon: 'list-box', component: MessageListPage, params: {
          //'source': this.messageService.getMessagesFromLoggedUser(),
          'listType': 'Enviadas'
        }
      },
      {
        title: 'Mensagens Recebidas', icon: 'list-box', component: MessageListPage, params: {
          //'source': this.messageService.getMessagesTo(this.basicAuth.AuthenticatedUser.Id),
          'listType': 'Recebidas'
        }
      }
    ];
    //console.log('this.pages', this.pages);

    this.basicAuth.isAuthenticated().then((isAuthenticated) => {
      console.log('app ctor this.basicAuth.isAuthenticated()', isAuthenticated);
      if (!isAuthenticated) {
        this.showFooter = false;
        this.rootPage = LoginPage;
      } else {
        this.showFooter = true;
        this.rootPage = HomePage;

        //console.log(this.basicAuth.AuthenticatedUser);

        this.initializeApp();
        //ole.log('this.pages on authenticated', this.pages);
      }
    });

  }

  initializeApp() {
    this.platform.ready().then(() => {
      // Okay, so the platform is ready and our plugins are available.
      // Here you can do any higher level native things you might need.
      StatusBar.styleDefault();
    });
  }

  openPage(page) {
    // Reset the content nav to have just this page
    // we wouldn't want the back button to show in this scenario
    this.nav.push(page.component, page.params);
  }

  public home() {
    // this.sendMessageService.send(
    //   () => {
    //     console.log('success');
    //     this.nav.setRoot(HomePage);
    //   },
    //   () => {
    //     console.log('error');
    //     this.nav.setRoot(HomePage);
    //   });
    this.nav.setRoot(HomePage);
  }

  logoff() {
    this.showFooter = false;
    this.basicAuth.logoff(() => {
      this.nav.setRoot(LoginPage);
    });
  }

  pendingMessagePopover(ev): void {
    //console.log('pendingMessagePopover()');
    // let popover = this.popoverController.create(PendingMessagePopoverPage);
    // popover.present();
    this.nav.push(SummaryPage);
  }
}

ionicBootstrap(PassarinhoContouApp, [
  BasicAuth,
  UserService,
  MessageService,
  PrefixCategoryService,
  SuffixCategoryService,
  MessagePrefixService,
  MessageSuffixService,
  SendMessageService,
  TicketService
]);