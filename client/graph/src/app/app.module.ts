import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { GraphComponent } from './component/graph/graph.component';
import { DrawComponent } from './component/draw/draw.component';
import { UserComponent } from './component/user/user.component';
import { SignUpComponent } from './component/sign-up/sign-up.component';
import { SignInComponent } from './component/sign-in/sign-in.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CommonModule }   from '@angular/common';

import * as echarts from 'echarts';
import { NgxEchartsModule } from 'ngx-echarts';
import { DemeComponent } from './component/deme/deme.component';


@NgModule({
  declarations: [
    AppComponent,
    GraphComponent,
    DrawComponent,
    UserComponent,
    SignUpComponent,
    SignInComponent,
    DemeComponent
  ],
  imports: [
    CommonModule,
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    NgxEchartsModule.forRoot({
      echarts
    })
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }




