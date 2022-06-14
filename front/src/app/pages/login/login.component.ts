import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { LoginService } from './login.service';

interface ILoginSuccess {
  token: string
}

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  loading: boolean = false;

  constructor(
    private loginService: LoginService,
    private router: Router
  ) { }

  loginControl = new FormControl("");
  senhaControl = new FormControl("");

  ngOnInit(): void {
    const token = localStorage.getItem("authToken");
    if (token) this.router.navigate(["cadastro"]);
  }

  async login() {
    try {
      const [login, senha] = [this.loginControl.value, this.senhaControl.value];
      this.loading = true
      const logged = <ILoginSuccess>(await this.loginService.login(login, senha));
      if (logged && logged.token) {
        localStorage.setItem("authToken", logged.token);
        localStorage.setItem("clientName", login);
        this.router.navigate(["cadastro"]);
      }
    } catch (error: any) {
      localStorage.clear()
      this.router.navigate(["login"]);
      alert(error.message)
    } finally {
      this.loading = false
    }
  }
}
