import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router'; 
import { AgenciasComponent } from './pages/agencias/agencias.component';

const routes: Routes = [
  {
    path: 'agencias',
    component: AgenciasComponent,
    data: { title: 'Lista of Agencias' }
  } 
  ,
  {
    path: 'listaagencias',
    component: AgenciasComponent 
  } 
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }