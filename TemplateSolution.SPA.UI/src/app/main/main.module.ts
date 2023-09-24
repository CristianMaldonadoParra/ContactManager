import { CdkTableModule } from '@angular/cdk/table';
import { CommonModule, NgFor, NgIf } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatDialogModule } from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatSidenavModule } from '@angular/material/sidenav';
import { RouterModule } from '@angular/router';
import { AgruparPorLetraPipe } from '../common/AgruparPorLetraPipe';
import { DemoMaterialModule } from '../demo-material-module';
import { ContatoComponent } from './home/contato/contato.component';
import { ModalDialogComponent } from './home/contato/modal-dialog/modal-dialog.component';
import { HomeComponent } from './home/home.component';
import { MainRoutes } from './main.routing';

@NgModule({
  imports: [
    CommonModule,
    RouterModule.forChild(MainRoutes),
    DemoMaterialModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    CdkTableModule,
    MatCardModule,
    DemoMaterialModule,
    NgFor,
    NgIf,
    RouterModule,
    CommonModule,
    MatIconModule,
    MatSidenavModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    MatDialogModule,
    
  ],
  declarations: [
    HomeComponent,
    AgruparPorLetraPipe,
    ContatoComponent,
    ModalDialogComponent,
  ],
  providers: [],
})
export class MainModule { }
