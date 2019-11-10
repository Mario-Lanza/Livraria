import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { CadastroComponent } from "./cadastro/cadastro.component";
import { ListaComponent } from './lista/lista.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MaterialModule } from './material/material.module';
import { LvHttpclientService } from './Services/lv-httpclient.service'

@NgModule({
    declarations: [
        AppComponent,
        HomeComponent,
        CadastroComponent,
        ListaComponent
    ],
    imports: [
        BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
        HttpClientModule,
        FormsModule,
        ReactiveFormsModule,
        RouterModule.forRoot([
            { path: '', component: HomeComponent, pathMatch: 'full' },
            { path: 'cadastro', component: CadastroComponent },
            { path: 'lista', component: ListaComponent },
        ]),
        BrowserAnimationsModule,
        MaterialModule
    ],
    providers: [LvHttpclientService],
    bootstrap: [AppComponent]
})
export class AppModule { }
