import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FormControl, FormGroup } from '@angular/forms';
import { ChartType, ChartOptions } from 'chart.js';
import { SingleDataSet, Label, monkeyPatchChartJsLegend, monkeyPatchChartJsTooltip } from 'ng2-charts';

@Component({
  selector: 'token',
  templateUrl: './token.component.html'
})
export class TokenComponent {
  public tokens: Token[];
  public formToken: FormGroup;
  // public pieChartLabels: string[];
  // public pieChartData: number[];
  public pieChartLabels: Label[] = [];
  public pieChartData: SingleDataSet = [];
  public pieChartType: ChartType = 'pie';
  public pieChartLegend = true;
  public pieChartOptions: ChartOptions = {
    responsive: true,
  };

  public pieChartColors: Array < any > = [{
    backgroundColor:["#FF7360", "#6FC8CE", "#FAFFF2", "#FFFCC4", "#B9E8E0", "RED"] 
  }];
  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
    monkeyPatchChartJsTooltip();
    monkeyPatchChartJsLegend();
    this.getAllToken();
    this.drawChart();
    this.onCreateForm();
  }


  getAllToken() {
    this.http.get<Token[]>(this.baseUrl + 'token').subscribe((result: Token[]) => {
      this.tokens = result;
    }, error => console.error(error));
    
  }


  drawChart() {
    this.http.get<Token[]>(this.baseUrl + 'token/drawchart').subscribe((result: any) => {
      this.pieChartData = result.chartData;
      this.pieChartLabels = result.chartLabels;
    }, error => console.error(error));
  }

  onCreateForm(){
    this.formToken = new FormGroup({
      contractAddress: new FormControl(''),
      id: new FormControl(''),
      name: new FormControl(''),
      symbol: new FormControl(''),
      totalHolders: new FormControl(''),
      totalSupply: new FormControl(''),
    });
  }
  onSubmit(){
    this.http.put(this.baseUrl + 'token/updatetoken', this.formToken.getRawValue()).subscribe((result: any) => {
      console.log(result)
    }, error => console.error(error));
  }

  onUpdateAction(token: Token){
    this.formToken.patchValue(token)
  }
}

interface Token {
  id: number
  contractAddress: string
  name: string
  symbol: string
  totalHolders: number
  totalSupply: number
}
interface ChartTokenViewModel {
  chartLabels: string[],
  chartData: number[]
}