import { Component } from '@angular/core';
import { SelectionModel } from '@angular/cdk/collections';
import { LvHttpclientService } from './../Services/lv-httpclient.service';
import { MatTableDataSource } from '@angular/material'

@Component({
    selector: 'app-fetch-data',
    templateUrl: './fetch-data.component.html',
    styleUrls: ['./fetch-data.component.css']
})
export class FetchDataComponent {
    public livros: MatTableDataSource<Livros>;
    private apiPath: string = 'weatherforecast';
    displayedColumns: string[] = ['select', 'nome', 'autor', 'editora', 'dataPublicacao', 'quantidade'];
    selection = new SelectionModel<Livros>(false);

    constructor(httpClientService: LvHttpclientService) {
        httpClientService.get(this.apiPath).subscribe((result: Livros[]) => {
            this.livros = new MatTableDataSource(result);
        }, error => console.error(error));
    }

    logData() {
        var x = "teste";
    }

    aplicarFiltro(filterValue: string) {
        this.livros.filter = filterValue.trim().toLowerCase();
    }
}

interface Livros {
    id: string;
    nome: string;
    autor: string;
    editora: string;
    dataPublicacao: Date;
    quantidade: number;
}
