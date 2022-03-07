import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DrawComponent } from './component/draw/draw.component';
import { GraphComponent } from './component/graph/graph.component';
import { SignInComponent } from './component/sign-in/sign-in.component';
import { SignUpComponent } from './component/sign-up/sign-up.component';


const routes: Routes = [
  { path: 'graph', component: GraphComponent, pathMatch: 'full' },
  { path: 'sign-up', component: SignUpComponent },
  { path: 'sign-in', component: SignInComponent },
  { path: 'draw', component: DrawComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
