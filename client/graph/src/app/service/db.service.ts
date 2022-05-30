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

  user2: User = new User()
  e: Equation = new Equation()

  constructor(private http: HttpClient) { }
  //מחזיר רשימת כל הגרפים
  getGragh(): Observable<Graph[]> {
    return this.http.get<Graph[]>('http://localhost:59111/api/Graph/GetAllGraph');
  }
  //מחזיר את הגרף הנוכחי
  getOneEquation(): Observable<Equation> {
    return this.http.get<Equation>('http://localhost:59111/api/Graph/getOneGraph');
  }
  //מחזיר רשימת נקודות מיוחדות לגרף
  getPointGraph(e: Equation): Observable<Point[]> {
    debugger;
    return this.http.post<Point[]>('http://localhost:59111/api/Graph/PostPointGraph', e);
  }
  //הוספת משתמש חדש
  newSignUp(user: User): Observable<User> {
    return this.http.post<User>('http://localhost:59111/api/User/PostSignUp', user);
  }
  //כניסת משתמש קיים
  newSignIn2(user: UserSignIn): Observable<User> {
    debugger;
    return this.http.post<User>('http://localhost:59111/api/User/PostSignIn', user);
  }
  newSignIn(u: UserSignIn): Observable<User> {
    debugger;
    return this.http.post<User>('http://localhost:59111/api/User/PostSignIn', u);
  }
  //שליחת גרף לשרת וקבלת אובייקט Equation
  sendStringGraphToDB(graph: GraphNew): Observable<Equation> {
    return this.http.post<Equation>('http://localhost:59111/api/Graph/PostImportGraphString', graph);
  }
  //קבלת נגזרת הפונקציה הנוכית
  getNigzeret(graph: Equation): Observable<Equation> {
    return this.http.post<Equation>('http://localhost:59111/api/Graph/PostNigzeret', graph);
  }
  //מחזירה את היסטוריית חיפושים של משתמש
  getHistori(user: User): Observable<Equation[]> {
    return this.http.post<Equation[]>('http://localhost:59111/aapi/Graph/PostHistori', user);
  }
}
