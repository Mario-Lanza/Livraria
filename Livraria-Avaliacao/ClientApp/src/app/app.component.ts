import { Component } from '@angular/core';
import { MatSnackBar } from '@angular/material'

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
    title = 'app';
    opened = false;

    constructor(
        private snackBar: MatSnackBar) { }

    menuSuperiorItem() {
        this.snackBar.open("Não foi implementado", "", { duration: 5000 });
    }
}
