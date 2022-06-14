import { Component, Input, OnInit } from "@angular/core";
import { Router } from "@angular/router";
import { UserService } from "src/app/services/user.service";

interface IMenuItems {
  title: string;
  route: string;
}

export interface IMenu {
  category: string;
  items: IMenuItems[]
}
@Component({
  selector: "sidebar",
  templateUrl: "./sidebar.component.html",
  styleUrls: ["./sidebar.component.scss"],
})
export class SidebarComponent implements OnInit {
  @Input("username") username: string = "NOME DE USUÁRIO";
  @Input("image") userImage: string = "https://img.freepik.com/fotos-gratis/imagem-aproximada-em-tons-de-cinza-de-uma-aguia-careca-americana-em-um-fundo-escuro_181624-31795.jpg?w=2000";
  @Input("subMenu") subMenu: IMenu[] = [];

  constructor(
    private router: Router,
    private userService: UserService
    ) { }

  ngOnInit(): void {
    const clientName = localStorage.getItem("clientName");
    if (clientName) {
      this.username = clientName
    }
  }

  goTo(route: string) {
    if(!route.includes("consulta") && !this.userService.getUser) {
      return;
    }
    if (route) {
      this.router.navigate([route]);
    }
  }

  logout(){
    localStorage.clear()
    this.router.navigate(["login"]);
  }
}