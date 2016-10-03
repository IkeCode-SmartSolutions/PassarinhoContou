import { Http } from '@angular/http';
import 'rxjs/add/operator/map';

export class BaseService {
  protected BaseUrl: string;

  constructor(protected http: Http) {
    this.BaseUrl = "http://local.passarinhocontou.ikecode.com.br:7000/api/";
    //this.BaseUrl = "http://passarinhocontou.ikecode.com.br/api/";
  }

}

