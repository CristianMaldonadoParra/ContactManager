import { Component, Input, OnDestroy, OnInit } from '@angular/core';
import { ContatoService } from '../../../common/ContatoService';
import { PessoaService } from '../../../common/PessoaService';
import { ContatoModel } from '../../../model/ContatoModel';
import { PessoaModel } from '../../../model/PessoaModel';
import { MatDialog } from '@angular/material/dialog';
import { ModalDialogComponent } from './modal-dialog/modal-dialog.component';

@Component({
  selector: 'app-contato',
  templateUrl: './contato.component.html',
  styleUrls: ['./contato.component.scss']
})
export class ContatoComponent implements OnInit, OnDestroy {
  pessoa: PessoaModel = { id: 0, nome: '' };
  telefones: ContatoModel[] = [];
  emails: ContatoModel[] = [];
  whatsapps: ContatoModel[] = [];
  showConfig: boolean = false;
  @Input('id') id: number = 0;
  constructor(private pessoaService: PessoaService, private contatoService: ContatoService, public dialog: MatDialog) { }

  ngOnInit(): void {

    if (this.id > 0) {
      this.onGetPessoa(this.id);
      this.onGetContato(this.id);
      this.showConfig = true;
    }
    else {
      this.showConfig = false;
    }
  }

  onGetPessoa(id: number) {
    this.pessoaService.getById(this.id).subscribe((data) => {
      this.pessoa = data;
    });
  }

  onGetContato(pessoaId: number) {
    this.contatoService.getAll(pessoaId).subscribe((data) => {
      this.telefones = data.filter(filter => filter.tipo == 'Telefone');
      this.emails = data.filter(filter => filter.tipo == 'Email');
      this.whatsapps = data.filter(filter => filter.tipo == 'Whatsapp');
    })
  }

  salvarPessoa() {
    if (this.pessoa.id == 0) {
      this.pessoaService.create(this.pessoa).subscribe((data: any) => {        
        this.id = data.id;
        this.pessoa.id = data.id;
        this.pessoa.nome = data.nome;
        this.showConfig = true;
      });
    }
    else {
      this.pessoaService.update(this.pessoa).subscribe((data: any) => {
        this.id = data.id;
        this.pessoa.id = data.id;
        this.pessoa.nome = data.nome;
        this.showConfig = true;
      });
    }
  }

  onDeleteContato(contatoId: number) {
    this.contatoService.delete(contatoId).subscribe(() => {
      this.onGetContato(this.id);
    });
  }

  openDialog(contatoId: number, tipoContato: string, valor: string): void {
    var contato: ContatoModel = {
      id: contatoId,
      tipo: tipoContato,
      valor: valor,
      pessoaId: this.pessoa.id
    }
    const dialogRef = this.dialog.open(ModalDialogComponent, {
      data: contato
    });

    dialogRef.afterClosed().subscribe(result => {
      this.onGetContato(this.id);
    });
  }

  ngOnDestroy(): void {
    this.id = 0;
  }
}
