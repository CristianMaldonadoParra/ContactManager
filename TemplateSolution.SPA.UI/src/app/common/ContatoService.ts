import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { ContatoModel } from "../model/ContatoModel";

@Injectable({ providedIn: "root" })
export class ContatoService {
  constructor(private http: HttpClient) {

  }

  getAll(pessoaId:number): Observable<ContatoModel[]> {
    return this.http.get<ContatoModel[]>(`https://bravi-contact-manager.azurewebsites.net/api/Contatos?PessoaId=${pessoaId}`);
  }

  getById(id: number): Observable<ContatoModel> {
    return this.http.get<ContatoModel>(`https://bravi-contact-manager.azurewebsites.net/api/Contatos/GetDetails?id=${id}`);
  }

  create(payload: ContatoModel) {
    return this.http.post(`https://bravi-contact-manager.azurewebsites.net/api/Contatos`, payload);
  }

  update(payload: ContatoModel) {
    return this.http.put(`https://bravi-contact-manager.azurewebsites.net/api/Contatos`, payload);
  }

  delete(id: number) {
    return this.http.delete(`https://bravi-contact-manager.azurewebsites.net/api/Contatos?id=${id}`);
  }
}
