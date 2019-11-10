import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { LvHttpclientService } from './../Services/lv-httpclient.service';
import { Router, ActivatedRoute } from "@angular/router";
import {  MatSnackBar } from '@angular/material'

@Component({
    selector: 'cadastro-component',
    templateUrl: './cadastro.component.html',
    styleUrls: ['./cadastro.component.css']
})
export class CadastroComponent {
    primeiroStep: FormGroup;
    segundoStep: FormGroup;
    dataMinima: Date = new Date(0);
    dataMaxima: Date = new Date(Date.now());
    stepsCarregados = false;
    apiPath: string = "livros";
    id: string;
    title: string;

    constructor(
        private _formBuilder: FormBuilder,
        private httpClientService: LvHttpclientService,
        private route: Router,
        private activatedRoute: ActivatedRoute,
        private snackBar: MatSnackBar) { }

    ngOnInit() {
        this.id = this.activatedRoute.snapshot.queryParams.id;

        var livro: Livros = {};

        if (this.id) {
            this.httpClientService.getComParametro(this.apiPath, this.id).subscribe((result: Livros) => {
                this.title = "Alterar Cadastro"
                this.carregarStep(result);
            }, error => {
                this.snackBar.open("Erro ao carregar os dados.")
            });
        }
        else {
            this.title = "Novo Cadastro"
            this.carregarStep(livro);
        }
    }

    salvar() {
        var livro: Livros = {
            id: this.id,
            nome: this.primeiroStep.value.nome,
            autor: this.primeiroStep.value.autor,
            editora: this.primeiroStep.value.editora,
            dataPublicacao: this.primeiroStep.value.dataPublicacao,
            quantidade: this.segundoStep.value.quantidade,
            quantidadeMinima: this.segundoStep.value.quantidadeMinima,
        };

        (this.id ?
            this.httpClientService.put<Livros>(this.apiPath, livro) :
            this.httpClientService.post<Livros>(this.apiPath, livro)).subscribe(() => {
                this.snackBar.open("Livro salvo com sucesso.", "", {duration: 5000})
                this.route.navigate(['/lista']);
            }, error => {
                    this.snackBar.open("Erro ao tentar salvar o livro.", "fechar", { duration: 5000 });
            })
    }

    private carregarStep(livro: Livros) {
        this.primeiroStep = this._formBuilder.group({
            id: [livro.id],
            nome: [livro.nome, Validators.required],
            autor: [livro.autor],
            editora: [livro.editora],
            dataPublicacao: [livro.dataPublicacao]
        });
        this.segundoStep = this._formBuilder.group({
            quantidade: [livro.quantidade, Validators.required],
            quantidadeMinima: [livro.quantidadeMinima]
        });

        this.stepsCarregados = true;
    }
}
