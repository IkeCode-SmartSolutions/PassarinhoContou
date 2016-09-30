import { Http } from '@angular/http';
import 'rxjs/add/operator/map';

export class BaseService {
  protected BaseUrl: string = "/api/";

  constructor(protected http: Http) {
  }

}

