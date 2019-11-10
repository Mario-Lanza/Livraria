import { Component } from '@angular/core';
import { LvHttpclientService } from './../Services/lv-httpclient.service';

@Component({
    selector: 'app-home',
    templateUrl: './home.component.html',
    styleUrls: ['./home.component.css']
})
export class HomeComponent {
    livrosAbaixoEstoque: Livros[] = [];
    private apiPath: string = 'estoque';

    constructor(private httpClientService: LvHttpclientService) { }

    ngOnInit() {
        this.httpClientService.get(this.apiPath).subscribe((result: Livros[]) => {
            this.livrosAbaixoEstoque = result;
        }, error => console.error(error));
    }

    abaixoDoEstoque(): boolean {
        return this.livrosAbaixoEstoque.length < 0;
    }
}
