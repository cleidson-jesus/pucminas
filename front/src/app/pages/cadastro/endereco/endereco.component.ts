import { Component, OnInit } from "@angular/core";
import { FormControl, FormGroup } from "@angular/forms";
import { ActivatedRoute, Router } from "@angular/router";
import { UserService } from "src/app/services/user.service";
import { EnderecoService } from "./endereco.service";
import { selectOptions } from "./endereco.utils";

@Component({
  selector: "endereco",
  templateUrl: "endereco.component.html",
  styleUrls: ["./endereco.component.scss"]
})
export class EnderecoComponent implements OnInit {
  loading: boolean = true;
  selectControl = new FormControl("M");
  selectOptions = selectOptions
  userSelectedId: number | undefined;
  userCpf: number | undefined;

  constructor(
    private router: Router,
    private enderecoService: EnderecoService,
    private userService: UserService,
    private activatedRoute: ActivatedRoute
  ) { }

  arrFormGroup: FormGroup[] = []

  formGroup = new FormGroup({
    cpfCnpj: new FormControl(),
    id: new FormControl(),
    cep: new FormControl(),
    logradouro: new FormControl(),
    numero: new FormControl()
  });

  async ngOnInit(): Promise<void> {
    const { id } = this.activatedRoute.snapshot.params
    if (!id && this.userService.getUser) {
      this.userSelectedId = this.userService.getUser.id;
      this.router.navigate(["cadastro", "endereco", this.userSelectedId])
      return
    }
    if (!id && !this.userSelectedId) {
      this.goBack()
      return
    }
    await this.getClientData(id || this.userSelectedId).catch(error => console.log(error))
    this.loading = false
  }

  getControl(name: string): FormControl {
    const control = this.formGroup.get(name);
    return control as FormControl;
  }

  getControlOnArray(formGroup: FormGroup, name: string) {
    const control = formGroup.get(name);
    return control as FormControl;
  }


  goBack() {
    this.router.navigate(["cadastro", "consulta"]);
  }

  async getClientData(id: number) {
    let { enderecos, cpfCnpj, id: clientId } = await this.enderecoService.getClientById(id);
    this.userService.setUser = { id: clientId }
    this.userCpf = cpfCnpj
    for (const endereco of enderecos) {
      this.arrFormGroup.push(new FormGroup({
        cpfCnpj: new FormControl(this.userCpf),
        id: new FormControl(endereco.id),
        idCliente: new FormControl(endereco.idCliente),
        cep: new FormControl(endereco.cep),
        logradouro: new FormControl(endereco.logradouro),
        numero: new FormControl(endereco.numero)
      }))
    }
  }

  async saveClient(formGroup: any) {
    const mode = formGroup?.controls?.new?.value === true ? "POST" : "PUT";
    const userData = {
      ...formGroup.value,
      cep: Number(formGroup.value.cep),
      id: Number(formGroup.value.id),
      numero: Number(formGroup.value.numero)
    }
    if (mode === "POST") {
      delete userData.id
    } 
    delete userData.new
    delete userData.cpfCnpj
    this.loading = true
    try {
      await this.enderecoService.saveEndereco(userData, mode)
    } catch (error) {
      console.log(error)
    } finally {
      this.loading = false
    }
  }

  newAddres() {
    this.arrFormGroup.unshift(new FormGroup({
      cpfCnpj: new FormControl(this.userCpf),
      id: new FormControl(""),
      cep: new FormControl(""),
      logradouro: new FormControl(""),
      numero: new FormControl(""),
      new: new FormControl(true)
    }))
  }
}