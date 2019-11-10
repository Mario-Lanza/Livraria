import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class LvHttpclientService {
  private url: string;

    constructor(@Inject('BASE_URL') baseUrl: string, private httpClient: HttpClient) {
        this.url = baseUrl;
    }

    get(path: string) {
        return this.httpClient.get(this.concatenarUrlPath(path));
    }

    getComParametro(path: string, param: string) {
        return this.httpClient.get(`${this.concatenarUrlPath(path)}/${param}`);
    }

    post<T>(path: string, data: T) {
        var caminhoCompleto = this.concatenarUrlPath(path);
        return this.httpClient.post<T>(caminhoCompleto, data, {
            headers: this.ObterHeaders()
        });
    }

    put<T>(path: string, data: T) {
        var caminhoCompleto = this.concatenarUrlPath(path);
        return this.httpClient.put<T>(caminhoCompleto, data, {
            headers: this.ObterHeaders()
        });
    }

    delete(path: string, id: string) {
        var caminhoCompleto = `${this.concatenarUrlPath(path)}/${id}`;
        return this.httpClient.delete(caminhoCompleto);
    }

    private ObterHeaders(): HttpHeaders {
        return new HttpHeaders({
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        });
    }

    private concatenarUrlPath(apiPath: string): string {
        return `${this.url}${apiPath}`;
    }
}
