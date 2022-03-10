import { Component, OnInit } from '@angular/core';
import * as echarts from 'echarts/types/dist/echarts';
import { Equation } from 'src/app/models/Equation';
import { DbService } from 'src/app/service/db.service';
import { CanvasGraph } from '../../models/CanvasGraph';



var chartDom = document.getElementById('main');
var myChart = echarts.init(chartDom);
var option;

echarts.use(const [
  GridComponent,
  DataZoomComponent,
  LineChart,
  CanvasRenderer,
  UniversalTransition
]);

@Component({
  selector: 'app-draw',
  templateUrl: './draw.component.html',
  styleUrls: ['./draw.component.css']
})
export class DrawComponent implements OnInit {


  equation: Equation[] = [];
  myGraph: any;
  myChart:any;



  
  constructor(private dbService: DbService) { }
  res:any
  ngOnInit(): void {

    function func(x:number) {
        x /= 10;
        return Math.sin(x) * Math.cos(x * 2 + 1) * Math.sin(x * 3 + 2) * 50;
      }
      function generateData() {
        let data = [];
        for (let i = -200; i <= 200; i += 0.1) {
          data.push([i, func(i)]);
        }
        return data;
      }
      let option = {
        animation: false,
        grid: {
          top: 40,
          left: 50,
          right: 40,
          bottom: 50
        },
        xAxis: {
          name: 'x',
          minorTick: {
            show: true
          },
          minorSplitLine: {
            show: true
          }
        },
        yAxis: {
          name: 'y',
          min: -100,
          max: 100,
          minorTick: {
            show: true
          },
          minorSplitLine: {
            show: true
          }
        },
        dataZoom: [
          {
            show: true,
            type: 'inside',
            filterMode: 'none',
            xAxisIndex: [0],
            startValue: -20,
            endValue: 20
          },
          {
            show: true,
            type: 'inside',
            filterMode: 'none',
            yAxisIndex: [0],
            startValue: -20,
            endValue: 20
          }
        ],
        series: [
          {
            type: 'line',
            showSymbol: false,
            clip: true,
            data: generateData()
          }
        ]
      };
      

   

   

  //   this.dbService.getAllEquation().subscribe(res => {
  //     console.log(res);
  //     this.equation[0] = res;
  //     this.res=res;
  //     console.log(res);
  //   })

  //   debugger;
  //   let myGraph = new CanvasGraph({
  //     canvasId: "myCanvas",
  //     minX: -10,
  //     minY: -10,
  //     maxX: 10,
  //     maxY: 10,
  //     unitsPerTick: 1
  //   });

  //   myGraph.drawEquation((x: number) => {

  //     //const str = "(+3)*5 ^2 (-2)*5^1 (-2)*5^0"
  //     let str = "";
      
  //     let i=0;
  //     debugger;
  //     for(let p of this.equation[0].Parameters) {
  //       let v = p.Value;
  //       let c = p.class;
  //       let o = p.Operator;
  //       str += "o*v*x^c ";
  //       i++;
  //     }
  //     return eval(str);

  //   }, "green", 3);

  //   myGraph.drawEquation(function (x: number) {
  //     return eval('-x * x * x + 2');
  //   }, "blue", 3);

  //   myGraph.drawEquation(function (x: number) {
  //     return -2*(x*x)+8
  //   }, "red", 3);
  // }

 





  



}
}
