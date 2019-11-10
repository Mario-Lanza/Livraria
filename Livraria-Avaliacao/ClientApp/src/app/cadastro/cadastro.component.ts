import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
@Component({
    selector: 'app-cadastro-component',
    templateUrl: './cadastro.component.html',
    styleUrls: ['./cadastro.component.css']
})
export class CadastroComponent {
    primeiroStep: FormGroup;
    segundoStep: FormGroup;
    dataMinima: Date = new Date(0);
    dataMaxima: Date = new Date(Date.now());

    constructor(private _formBuilder: FormBuilder) { }

    ngOnInit() {
        this.primeiroStep = this._formBuilder.group({
            primeiroCtrl: ['', Validators.required]
        });
        this.segundoStep = this._formBuilder.group({
            segundoCtrl: ''
        });
    }
}
