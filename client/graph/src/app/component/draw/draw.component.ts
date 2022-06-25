import { Component, OnInit, ViewEncapsulation, AfterViewInit, OnDestroy } from '@angular/core';
//import * as echarts from 'echarts/types/dist/echarts';
import { Equation } from 'src/app/models/Equation';
import { DbService } from 'src/app/service/db.service';
import { CanvasGraph } from '../../models/CanvasGraph';
import Keyboard from "simple-keyboard";
import { getInstanceByDom, connect } from 'echarts';
import * as util from 'zrender/lib/core/util';
import * as echarts from 'echarts';
import { GraphNew } from 'src/app/models/GraphNew';
import { Point } from 'src/app/models/Point';
import { Graph } from 'src/app/models/Graph';
import { Router } from '@angular/router';



@Component({
  selector: 'app-draw',
  templateUrl: './draw.component.html',
  styleUrls: ['./draw.component.css']
})
export class DrawComponent implements OnInit {

  point: Point[] = [];
  pointX: Point[] = [];
  pointK: Point[] = [];
  pointY: Point[] = [];
  p1: Point = { X: NaN, Y: NaN };
  p2: Point = { X: NaN, Y: NaN };
  p3: Point = { X: NaN, Y: NaN };
  p4: Point = { X: NaN, Y: NaN };

  histiryList: Graph[] = [];
  equation: Equation
  nigzeret: Equation
  myGraph: any;
  myChart: any;
  res: any;
  strNigzeret: string;


  constructor(private dbService: DbService, public router: Router) { }

  ngOnInit(): void {
    
  }

  drawFunc(x: number, equation: Equation) {
    let str = "";
    let s = "";
    let i = 0;
    //עובר על כל איבר בפונקציה
    for (let p of equation.Parameters) {
      let v = p.Value;
      let c = p.Class;
      let o = p.Operator;
      let X = "";
      let xx = "";
      for (let i = 0; i < c; i++) {
        X = `*${x}`;
        xx += X;
      }
      s = `${o}${v}${xx} `;
      str += s;
      console.log(str);
      i++;
    }
    //מחזיר את הפונקציה פתורה - מספר 
    return eval(str);
  }


  func(x: number) {
    x /= 10;
    // const str = "(+3)*5 ^2 (-2)*5^1 (-2)*5^0"
    // // const str = "(+3)*x*x -5"
    // let str = "";
    // let s = "";
    // let i = 0;

    // for (let p of this.equation.Parameters) {
    //   let v = p.Value;
    //   let c = p.Class;
    //   let o = p.Operator;
    //   let X = "";
    //   let xx = "";
    //   for (let i = 0; i < c; i++) {
    //     X = `*${x}`;
    //     xx += X;
    //   }
    //   s = `${o}${v}${xx} `;
    //   str += s;
    //   console.log(str);
    //   i++;
    // }
    // return eval(str);
    // //return eval("+2*x*x -5*x +7");
    // //return x * x * x;
    return this.drawFunc(x, this.equation);//שולח לפונקיית שרטוט 
  }
  func2(x: number) {
    x /= 10;
    return this.drawFunc(x, this.nigzeret);
  }
  // func3(x: number) {
  //   x/= 10;
  //   return x*x;
  // }
  generateDataEquation() {
    let data: any[] = [];
    for (let i = -200; i <= 200; i += 0.1) {
      data.push([i, this.func(i)]);
    }
    return data;
  }

  generateDataNigzeret() {
    let data: any[] = [];
    for (let i = -200; i <= 200; i += 0.1) {
      data.push([i, this.func(i)]);
      data.push([i, this.func2(i)]);
    }
    return data;
  }


  //Keyboard

  value = "";
  keyboard: Keyboard;

  ngAfterViewInit() {
    this.keyboard = new Keyboard({
      onChange: input => this.onChange(input),
      onKeyPress: (button: any) => this.onKeyPress(button)
    });
  };

  onChange = (input: string) => {
    this.value = input;
    console.log("Input changed", input);
  };

  onKeyPress = (button: string) => {
    console.log("Button pressed", button);
    /**
     * If you want to handle the shift and caps lock buttons
     */
    if (button === "{shift}" || button === "{lock}") this.handleShift();
  };

  onInputChange = (event: any) => {
    this.keyboard.setInput(event.target.value);
  };

  handleShift = () => {
    let currentLayout = this.keyboard.options.layoutName;
    let shiftToggle = currentLayout === "default" ? "shift" : "default";

    this.keyboard.setOptions({
      layoutName: shiftToggle
    });
  };


  send() {
    //להפעיל פונקציה שנשגת לשרת
    //הפונקציה תקבל מחרוזת וגם קוד משתמש:
    debugger
    var dom = document.getElementById("container")!;
    var myChart = echarts.init(dom);
    var app = {};
    var option;

    var graphStringHTML = (<HTMLInputElement>document.getElementById("func")).value
    if (graphStringHTML == "") {
      alert("הכנס משוואת פונקציה");
      return;
    }
    debugger;
    console.log(this.dbService.user2.Code);
    if (this.dbService.user2.Code == undefined) {
      alert("הינך צריך להירשם או להתחבר ");
      this.router.navigate(['/home']);
      return;
    }
    console.log(graphStringHTML);
    console.log(this.dbService.user2);
    console.log(this.dbService.user2.Code);
    const newGraph: GraphNew = {
      graphString: graphStringHTML,
      userCode: this.dbService.user2.Code
    }
    this.dbService.sendStringGraphToDB(newGraph).subscribe(res => {
      console.log(res);
      this.equation = res;
      this.res = res;
      console.log(this.equation);
      debugger
      if (res == null)
        alert("שגיאת שרת");
      else {
        console.log("getAllEquation!");
        console.log(res);
        this.equation = res;
        this.res = res;
        console.log(this.equation);

        const data = [
          [0, 0],
          [1, 1],
          [5, 5],

        ];

        option = {
          animation: false,
          grid: {
            top: 40,
            left: 50,
            right: 40,
            bottom: 50
          },
          hoverLayerThreshold: 3000,
          tooltip: {
            triggerOn: 'none',
            formatter: function (params) {
              return (
                'X: ' +
                params.data[0].toFixed(2) +
                '<br>Y: ' +
                params.data[1].toFixed(2)
              );
            }
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
              id: 'a',
              type: 'line',
              showSymbol: false,
              clip: true,
              symbolSize: 30,
              data: this.generateDataEquation()
            }
          ]
        };
        if (option && typeof option === 'object') {
          myChart.setOption(option);
        }
      }
    })
  }

  ShowNigzeret() {
    var dom = document.getElementById("container")!;
    var myChart = echarts.init(dom);
    var app = {};
    var option;


    if (this.equation == undefined) {
      alert("קודם שלח פונקציית משוואה ורק לאחר מכן שלח ניגזרת");
      return;
    }
    this.dbService.getNigzeret(this.equation).subscribe(res => {
      this.p1 = this.p2 = this.p3 = this.p4 = { X: 0, Y: 0 };;
      console.log(res);
      this.nigzeret = res;
      console.log(this.equation);
      debugger
      if (res == null)
        alert("שגיאת");
      else {
        this.equation = res;
        this.res = res;
        console.log(this.equation);
        debugger;
        this.strNigzeret = this.findStrNigzeret(this.equation);
        this.value = this.strNigzeret;

        const data = [
          [0, 0],
          [1, 1],
          [5, 5],

        ];

        option = {
          animation: false,
          grid: {
            top: 40,
            left: 50,
            right: 40,
            bottom: 50
          },
          hoverLayerThreshold: 3000,
          tooltip: {
            triggerOn: 'none',
            formatter: function (params) {
              return (
                'X: ' +
                params.data[0].toFixed(2) +
                '<br>Y: ' +
                params.data[1].toFixed(2)
              );
            }
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
              id: 'a',
              type: 'line',
              showSymbol: false,
              clip: true,
              symbolSize: 30,
              data: this.generateDataNigzeret()
            }
          ]
        };

        
        if (option && typeof option === 'object') {
          myChart.setOption(option);
        }
      }
    })

  }

  findStrNigzeret(eq: Equation) {
    //מציאת מחרוזת הנגזרת
    let strNigz = "";
    let temp = "";

    for (let key of eq.Parameters) {
      if (key.Class < 2) {
        if (key.Class == 0) {
          temp = `${key.Operator}${key.Value} `;;
        }
        if (key.Class == 1) {
          temp = `${key.Operator}${key.Value}x `
        }
      }
      else {
        temp = `${key.Operator}${key.Value}x^${key.Class} `
      }
      strNigz += temp;
    }
    return strNigz;
  }

  showPoint() {
    debugger;
    if (this.equation == undefined) {
      alert("הכנס פונקציה לשליחה");
      return;
    }
    if (this.equation.Class > 2) {
      alert("המערכת מציגה נקודות רק עד המעלה 3");
      return;
    }

    this.dbService.getPointGraph(this.equation).subscribe(res => {
      debugger;
      this.point = res;
      if (this.point.length < 3) {
        this.p1 = this.point[0];
        this.p3 = this.point[1];
      }
      else {
        this.p1 = this.point[0];
        this.p2 = this.point[1];
        this.p3 = this.point[2];
        this.p4 = this.point[3];
      }
      debugger;
      console.log(this.point);
      console.log(this.p1);
      console.log(this.p2);
      console.log(this.p3);
      console.log(this.p4);
    })
  }
  history() {
    debugger;
    this.dbService.getHistory(this.dbService.user2).subscribe(res => {
      debugger;
      this.histiryList = res;
      console.log(res);
    })
  }
  clickHistory(s: string) {
    debugger;
    console.log(s);
    this.value = s;
  }
}







