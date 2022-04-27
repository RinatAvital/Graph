import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Graph } from '../models/Graph';
import { Observable } from 'rxjs';
import { Equation } from '../models/Equation';
import { User } from '../models/User';
import { UserSignIn } from '../models/UserSignIn';
import { GraphNew } from '../models/GraphNew';
import { Point } from '../models/Point';


@Injectable({
  providedIn: 'root'
})
export class DbService {

  e: Equation = new Equation()

  constructor(private http: HttpClient) { }

  getGragh(): Observable<Graph[]> {
    return this.http.get<Graph[]>('http://localhost:59111/api/Graph/GetAllGraph');
  }
  getOneEquation(): Observable<Equation> {
    return this.http.get<Equation>('http://localhost:59111/api/Graph/getOneGraph')
  }
  getPointGraph(): Observable<Point[]> {
    return this.http.get<Point[]>('http://localhost:59111/api/Graph/GetPointGraph')
  }
  newSignUp(user: User): Observable<User> {
    return this.http.post<User>('http://localhost:59111/api/User/PostSignUp', user);
  }
  newSignIn(user: UserSignIn): Observable<User> {
    debugger;
    return this.http.post<User>('http://localhost:59111/api/User/PostSignIn', user);
  }
  sendStringGraphToDB(graph: GraphNew):Observable<GraphNew>{
    return this.http.post<GraphNew>('http://localhost:59111/api/Graph/PostImportGraphString', graph);
  }

}
