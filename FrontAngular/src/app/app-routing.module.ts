import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MainlandingComponent } from './mainlanding/mainlanding.component';

const routes: Routes = [{
  path: '', component: MainlandingComponent
}];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
