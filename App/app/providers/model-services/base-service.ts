import { Http } from '@angular/http';
import 'rxjs/add/operator/map';

export class BaseService {
  protected BaseUrl: string = "http://localhost:700/api";

  constructor(protected http: Http) {
  }

}

