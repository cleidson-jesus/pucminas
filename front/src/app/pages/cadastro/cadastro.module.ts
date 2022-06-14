import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { ReactiveFormsModule } from "@angular/forms";
import { RouterModule, Routes } from "@angular/router";
import { ComponentsModule } from "src/app/components/components.module";
import { HttpService } from "src/app/services/http.service";
import { UserService } from "src/app/services/user.service";
import { CadastroComponent } from "./cadastro.component";
import { ConsultaComponent } from './consulta/consulta.component';
import { ConsultaService } from "./consulta/consulta.service";
import { DadosGenericosComponent } from "./dados/dados.component";
import { DadosGenericosService } from "./dados/dados.service";
import { EnderecoComponent } from "./endereco/endereco.component";
import { EnderecoService } from "./endereco/endereco.service";
import { TelefoneComponent } from "./telefone/telefone.component";
import { TelefoneService } from "./telefone/telefone.service";

const routes: Routes = [
  {
    path: '',
    component: CadastroComponent,
    children: [
      {
        path: "consulta",
        component: ConsultaComponent
      },
      {
        path: "dados/:id",
        component: DadosGenericosComponent
      },
      {
        path: "dados",
        component: DadosGenericosComponent
      },
      {
        path: "endereco/:id",
        component: EnderecoComponent
      },
      {
        path: "endereco",
        component: EnderecoComponent
      },
      {
        path: "telefone/:id",
        component: TelefoneComponent
      },
      {
        path: "telefone",
        component: TelefoneComponent
      },
      {
        path: '',
        redirectTo: 'consulta',
        pathMatch: 'full'
      }
    ]
  }
];

@NgModule({
  declarations: [
    CadastroComponent,
    ConsultaComponent,
    DadosGenericosComponent,
    EnderecoComponent,
    TelefoneComponent
  ],
  imports: [
    RouterModule.forChild(routes),
    CommonModule,
    ReactiveFormsModule,
    ComponentsModule
  ],
  providers: [
    DadosGenericosService,
    HttpService,
    ConsultaService,
    UserService,
    EnderecoService,
    TelefoneService
  ],
  exports: [RouterModule]
})
export class CadastroModule { }