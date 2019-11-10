import { Component } from '@angular/core';
import { SelectionModel } from '@angular/cdk/collections';
import { LvHttpclientService } from './../Services/lv-httpclient.service';
import { MatTableDataSource, MatSnackBar } from '@angular/material'
import { Router } from '@angular/router'

@Component({
    selector: 'lista',
    templateUrl: './lista.component.html',
    styleUrls: ['./lista.component.css']
})
export class ListaComponent {
    public livros: MatTableDataSource<Livros>;
    private apiPath: string = 'livros';
    displayedColumns: string[] = ['select', 'nome', 'autor', 'editora', 'dataPublicacao', 'quantidade'];
    selection = new SelectionModel<Livros>(false);

    constructor(
        private httpClientService: LvHttpclientService,
        private snackBar: MatSnackBar,
        private route: Router) {
        this.atualizarLista();
    }

    deletarLivro() {
        var snackBarRef = this.snackBar.open("Deseja mesmo deletar este livro?", "Sim", { duration: 15000 });
        snackBarRef.onAction().subscribe(() => {
            this.httpClientService.delete(this.apiPath, this.selection.selected[0].id).subscribe(() => {
                this.snackBar.open("Livro deletado com sucesso!", "Fechar", { duration: 10000 })
                this.selection = new SelectionModel<Livros>(false);
                this.atualizarLista();
            }, error => {
                this.snackBar.open("Ocorreu um erro ao deletar o livro.", "Fechar", { duration: 10000 })
            });
        });
    }

    alterarLivro() {
        this.route.navigate(['/cadastro'], { queryParams: { id: this.selection.selected[0].id } })
    }

    aplicarFiltro(filterValue: string) {
        this.livros.filter = filterValue.trim().toLowerCase();
    }

    private atualizarLista() {
        this.httpClientService.get(this.apiPath).subscribe((result: Livros[]) => {
            this.livros = new MatTableDataSource(result);
        }, error => console.error(error));
    }
}
