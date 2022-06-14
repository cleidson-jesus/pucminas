import { Component, OnInit } from '@angular/core';
import { IMenu } from 'src/app/components/Sidebar/sidebar.component';

@Component({
  selector: 'app-cadastro',
  templateUrl: './cadastro.component.html',
  styleUrls: ['./cadastro.component.scss']
})
export class CadastroComponent implements OnInit {

  constructor() { }

  subMenu: IMenu[] = [
    {
      category: "CONSULTAR",
      items: [
        {
          title: "Consultar cliente",
          route: "consulta"
        }
      ]
    },
    {
      category: "EDITAR DADOS DO CLIENTE",
      items: [
        {
          title: "Dados cadastrais",
          route: "cadastro/dados"
        },
        {
          title: "Endereço",
          route: "cadastro/endereco"
        },
        {
          title: "Telefone",
          route: "cadastro/telefone"
        }
      ]
    }
  ]

  ngOnInit(): void {
  }

}
