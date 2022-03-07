import { Component, OnInit } from '@angular/core';
import * as echarts from 'echarts/types/dist/echarts';

@Component({
  selector: 'app-deme',
  templateUrl: './deme.component.html',
  styleUrls: ['./deme.component.css']
})
export class DemeComponent implements OnInit {

  myChart:any;

  ngOnInit(): void {


    this.myChart.setOption({
      title: {
        text: 'ECharts Getting Started Example'
      },
      tooltip: {},
      xAxis: {
        data: ['shirt', 'cardigan', 'chiffon', 'pants', 'heels', 'socks']
      },
      yAxis: {},
      series: [
        {
          name: 'sales',
          type: 'bar',
          data: [5, 20, 36, 10, 10, 20]
        }
      ]
    });

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
          splitLine: {
              lineStyle: {
                  color: '#999'
              }
          },
          minorSplitLine: {
              show: true,
              lineStyle: {
                  color: '#ddd'
              }
          }
      },
      yAxis: {
          name: 'y',
          min: -100,
          max: 100,
          minorTick: {
              show: true
          },
          splitLine: {
              lineStyle: {
                  color: '#999'
              }
          },
          minorSplitLine: {
              show: true,
              lineStyle: {
                  color: '#ddd'
              }
          }
      },
      dataZoom: [{
          show: true,
          type: 'inside',
          filterMode: 'none',
          xAxisIndex: [0],
          startValue: -20,
          endValue: 20
      }, {
          show: true,
          type: 'inside',
          filterMode: 'none',
          yAxisIndex: [0],
          startValue: -20,
          endValue: 20
      }],
      series: [
          {
              type: 'line',
              showSymbol: false,
              clip: true,
              data: generateData()
          }
      ]
  };
  }

}
