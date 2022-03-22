import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Graph } from '../models/Graph';
import { Observable } from 'rxjs';
import { Equation } from '../models/Equation';
import { User } from '../models/User';
import { UserSignIn } from '../models/UserSignIn';

@Injectable({
  providedIn: 'root'
})
export class DbService {

  constructor(private http: HttpClient) { }

  getGragh(): Observable < Graph[] > {
    return this.http.get<Graph[]>('http://localhost:59111/api/Graph/GetAllGraph');
  }

  getAllEquation(){
    return this.http.get<Equation>('http://localhost:59111/api/Graph/GetNigzeret');
  }
  newSignUp(user:User):Observable<User>{
    return this.http.post<User>('http://localhost:59111/api/User/PostSignUp',user);
  }
  newSignIn(user:UserSignIn):Observable<User>{
    return this.http.post<User>('http://localhost:59111/api/User/PostSignIn',user);
  }
  
}
