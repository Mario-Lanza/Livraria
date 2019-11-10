import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class LvHttpclientService {
  private url: string;

    constructor(@Inject('BASE_URL') baseUrl: string, private httpClient: HttpClient) {
        this.url = baseUrl;
    }

    get(path: string) {
        return this.httpClient.get(this.url + path);
    }
}
