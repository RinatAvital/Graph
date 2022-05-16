import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AppComponent } from './app.component';
import { DrawComponent } from './component/draw/draw.component';
import { EnterComponent } from './component/enter/enter.component';
import { GraphComponent } from './component/graph/graph.component';
import { HomeComponent } from './component/home/home.component';
import { SignInComponent } from './component/sign-in/sign-in.component';
import { SignUpComponent } from './component/sign-up/sign-up.component';


const routes: Routes = [
  { path: '', component: EnterComponent, pathMatch: 'full' },
  {
    path: 'home', component: HomeComponent,
    // children:[
    //   { path: 'sign-up', component: SignUpComponent },
    //   { path: 'sign-in', component: SignInComponent }
    // ]
  },
  { path: 'graph', component: GraphComponent, pathMatch: 'full' },
  { path: 'sign-up', component: SignUpComponent },
  { path: 'sign-in', component: SignInComponent },
  { path: 'draw', component: DrawComponent },
  { path: 'enter', component: EnterComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
