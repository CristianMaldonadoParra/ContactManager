import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { PessoaModel } from "../model/PessoaModel";

@Injectable({ providedIn: "root" })
export class PessoaService {
  constructor(private http: HttpClient) {

  }

  getAll(): Observable<PessoaModel[]> {
    return this.http.get<PessoaModel[]>('https://bravi-contact-manager.azurewebsites.net/api/Pessoas');
  }

  getById(id:number): Observable<PessoaModel> {
    return this.http.get<PessoaModel>(`https://bravi-contact-manager.azurewebsites.net/api/Pessoas/GetDetails?id=${id}`);
  }

  create(payload: PessoaModel) {
    return this.http.post(`https://bravi-contact-manager.azurewebsites.net/api/Pessoas`, payload);
  }

  update(payload: PessoaModel) {
    return this.http.put(`https://bravi-contact-manager.azurewebsites.net/api/Pessoas`, payload);
  }

  delete(id: number) {
    return this.http.delete(`https://bravi-contact-manager.azurewebsites.net/api/Pessoas?id=${id}`);
  }
}
