import { Component, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import { Router } from '@angular/router';
import { ITableComponents } from 'src/app/components/Table/table.component';
import { UserService } from 'src/app/services/user.service';
import { ConsultaService } from './consulta.service';

interface IUserInfo {
  nome: string;
  cpfCnpj: string;
  id: number;
}

@Component({
  selector: 'app-consulta',
  templateUrl: './consulta.component.html',
  styleUrls: ['./consulta.component.scss']
})
export class ConsultaComponent implements OnInit {
  loading: boolean = false;
  componentes: ITableComponents = {
    headers: ["Nome", "CPF"],
    values: [],
    ignore: ["id"]
  };
  searchControl = new FormControl()

  constructor(
    private router: Router,
    private consultaService: ConsultaService,
    private userService: UserService
  ) { }

  ngOnInit(): void {
    if (this.consultaService.clients && this.consultaService.clients.length > 0) {
      this.componentes.values = this.consultaService.clients
    }
  }

  goToGenericData(id: string | number) {
    this.router.navigate(["cadastro", "dados", id]);
  }

  userClicked(user: IUserInfo) {
    if (user && user.id) {
      this.userService.setUser = user;
      this.goToGenericData(user.id);
    }
  }

  async searchClient() {
    try {
      this.loading = true;
      const regexNumbers = Number(this.searchControl.value.replace(/\D/g, ''))
      const type = regexNumbers === 0 || Number.isNaN(regexNumbers) ? "nome" : "cpfcnpj"
      const clientInfo = await this.consultaService.getClientData(this.searchControl.value, type);
      if (clientInfo) {
        const result = !Array.isArray(clientInfo) ? [clientInfo] : clientInfo;
        const client = result.map(({ cpfCnpj, nome, id }) => ({ cpfCnpj, nome, id }))
        this.consultaService.clients = client
        this.componentes.values = this.consultaService.clients;
      }
      this.loading = false;
    } catch (error) {
      this.loading = false;
      this.componentes.values = []
    }
  }


}
