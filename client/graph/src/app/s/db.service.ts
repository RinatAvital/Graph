import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class DbService {

  constructor(private http: HttpClient) {

  }

  getGraph() {
    return this.http.get("http://localhost:59111/api/Graph/GetAllGraph");
  }

}
