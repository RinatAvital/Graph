import { Component, OnInit, ViewEncapsulation, AfterViewInit, OnDestroy } from '@angular/core';
//import * as echarts from 'echarts/types/dist/echarts';
import { Equation } from 'src/app/models/Equation';
import { DbService } from 'src/app/service/db.service';
import { CanvasGraph } from '../../models/CanvasGraph';
import Keyboard from "simple-keyboard";
import { getInstanceByDom, connect } from 'echarts';
import * as util from 'zrender/lib/core/util';
import * as echarts from 'echarts';



@Component({
  selector: 'app-draw',
  templateUrl: './draw.component.html',
  styleUrls: ['./draw.component.css']
})
export class DrawComponent implements OnInit {


  equation: Equation
  myGraph: any;
  myChart: any;
  res: any


  constructor(private dbService: DbService) { }

  ngOnInit(): void {
    debugger;
    var dom = document.getElementById("container")!;
    var myChart = echarts.init(dom);
    var app = {};
    var option;


    this.dbService.getAllEquation().subscribe(res => {
      console.log(res);
      this.equation = res;
      this.res = res;
      console.log(this.equation);
    })

    const data = [
      [0, 0],
      [1, 1],
      [5, 5],
      
    ];
    debugger;
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
          data: this.generateData()
        }
      ]
    };

    var zr = myChart.getZr();
    
    zr.on('mousemove', function (params) {
      var pointInPixel = [params.offsetX, params.offsetY];
      zr.setCursorStyle(
        myChart.containPixel('grid', pointInPixel) ? 'copy' : 'default'
      );
    });
    debugger;
    if (option && typeof option === 'object') {
      myChart.setOption(option);
    }




    // debugger;
    // let myGraph = new CanvasGraph({
    //   canvasId: "myCanvas",
    //   minX: -10,
    //   minY: -10,
    //   maxX: 10,
    //   maxY: 10,
    //   unitsPerTick: 1
    // });

    //   myGraph.drawEquation((x: number) => {

    //     //const str = "(+3)*5 ^2 (-2)*5^1 (-2)*5^0"
    //     let str = "";

    //     let i = 0;
    //     debugger;
    //     for (let p of this.equation.Parameters) {
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
    //     return -2 * (x * x) + 8
    //   }, "red", 3);


    // function showTooltip(dataIndex) {
    //   myChart.dispatchAction({
    //     type: 'showTip',
    //     seriesIndex: 0,
    //     dataIndex: dataIndex
    //   });
    // }

  }


  func(x: number) {
    x /= 10;
    // const str = "(+3)*5 ^2 (-2)*5^1 (-2)*5^0"
    // const str = "(+3)*x*x -5"
    let str = "";

    let i = 0;
    for (let p of this.equation.Parameters) {
      let v = p.Value;
      let c = p.class;
      let o = p.Operator;
      str += "o*v*x^c ";
      i++;
    }
    return eval(str);
    //return x * x * x;
  }
  func2(x: number) {
    x /= 10;
    return x + 1;
  }
  generateData() {
    let data: any[] = [];
    for (let i = -200; i <= 200; i += 0.1) {
      data.push([i, this.func(i)]);
    }
    for (let i = -200; i <= 200; i += 0.1) {
      data.push([i, this.func2(i)]);
    }
    return data;
  }












  value = "";
  keyboard: Keyboard;

  ngAfterViewInit() {
    this.keyboard = new Keyboard({
      onChange: input => this.onChange(input),
      onKeyPress: (button: any) => this.onKeyPress(button)
    });
  }

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









}







