import { NgModule } from '@angular/core';
import {
    MatButtonModule,
    MatToolbarModule,
    MatSidenavModule,
    MatMenuModule,
    MatListModule,
    MatDividerModule,
    MatIconModule,
    MatCardModule,
    MatStepperModule,
    MatInputModule
} from '@angular/material';

const MaterialComponents = [
    MatButtonModule,
    MatToolbarModule,
    MatSidenavModule,
    MatMenuModule,
    MatListModule,
    MatDividerModule,
    MatIconModule,
    MatCardModule,
    MatStepperModule,
    MatInputModule
]

@NgModule({
  declarations: [],
    imports: [MaterialComponents],
    exports: [MaterialComponents]
})
export class MaterialModule { }
