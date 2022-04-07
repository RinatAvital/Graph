import { Component, OnInit } from '@angular/core';
import { Equation } from 'src/app/models/Equation';
import { Graph } from 'src/app/models/Graph';
import { Parameter } from 'src/app/models/Parameter';
import { DbService } from 'src/app/service/db.service';

@Component({
  selector: 'app-graph',
  templateUrl: './graph.component.html',
  styleUrls: ['./graph.component.css']
})
export class GraphComponent implements OnInit {

  graph: Graph[] = [];
  equation: Equation[]=[];

  constructor(private dbService: DbService) { }

  ngOnInit(): void {

  }

  showGraph() {
    this.dbService.getGragh().subscribe(res => {
      console.log(res);
      this.graph = res;
    })
  }

  

  getEquation() {
    this.dbService.getOneEquation().subscribe(res => {      
      console.log(res);
      this.equation[0] = res;
    })
  }

}
