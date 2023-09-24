import { MediaMatcher } from '@angular/cdk/layout';
import { ChangeDetectorRef, Component, OnInit, ViewChild } from '@angular/core';
import { PessoaService } from '../../common/PessoaService';
import { PessoaModel } from '../../model/PessoaModel';


@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
  mobileQuery: MediaQueryList;
  private _mobileQueryListener: () => void;
  @ViewChild('sidenav') sidenav: any;
  id: number = 0;
  refresh: boolean = false;

  pessoas: PessoaModel[] = [];

  constructor(private pessoaService: PessoaService, changeDetectorRef: ChangeDetectorRef, media: MediaMatcher) {
    this.mobileQuery = media.matchMedia('(min-width: 1024px)');
    this._mobileQueryListener = () => changeDetectorRef.detectChanges();
    this.mobileQuery.addListener(this._mobileQueryListener);

  }
  ngOnInit(): void {
    this.onGetPessoas();
  }

  onGetPessoas() {
    this.pessoaService.getAll().subscribe((data) => {
      data.map((row) => {
        row.grupo = row.nome[0].toUpperCase();
      });
      this.pessoas = data;
    });
  }

  onSelectPessoa(pessoa: any) {
    this.refresh = false;
    this.id = pessoa.id;

    setTimeout(() => {
      this.sidenav.open();
      this.refresh = true;
    }, 800);
  }

  onNovo() {
    this.refresh = false;
    this.id = 0;
    setTimeout(() => {
      this.sidenav.open();
      this.refresh = true;
    }, 800);
  }

  onDelete(pessoa: any) {
    this.pessoaService.delete(pessoa.id).subscribe((data) => {
      this.closeNav();
    });
  }

  onRefresh() {
    this.onGetPessoas();
  }

  closeNav() {
    this.onGetPessoas();
    this.refresh = false;
    this.sidenav.close();
  }
}
