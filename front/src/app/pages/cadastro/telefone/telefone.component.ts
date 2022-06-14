import { Component, OnInit } from "@angular/core";
import { FormControl, FormGroup } from "@angular/forms";
import { ActivatedRoute, Router } from "@angular/router";
import { UserService } from "src/app/services/user.service";
import { TelefoneService } from "./telefone.service";
import { dateFields, selectOptions } from "./telefone.utils";

@Component({
  selector: "telefone",
  templateUrl: "telefone.component.html",
  styleUrls: ["./telefone.component.scss"]
})
export class TelefoneComponent implements OnInit {
  loading: boolean = true;
  selectControl = new FormControl("M");
  selectOptions = selectOptions
  userSelectedId: number | undefined;
  userCpf: number | undefined;

  constructor(
    private router: Router,
    private telefoneService: TelefoneService,
    private userService: UserService,
    private activatedRoute: ActivatedRoute
  ) { }

  arrFormGroup: FormGroup[] = []

  formGroup = new FormGroup({
    cpfCnpj: new FormControl(),
    id: new FormControl(),
    ddd: new FormControl(),
    idTipo: new FormControl(),
    numero: new FormControl(),
    envioSms: new FormControl()
  });

  async ngOnInit(): Promise<void> {
    const { id } = this.activatedRoute.snapshot.params
    if (!id && this.userService.getUser) {
      this.userSelectedId = this.userService.getUser.id;
      this.router.navigate(["cadastro", "telefone", this.userSelectedId])
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
    let { telefones, cpfCnpj, id: idCliente } = await this.telefoneService.getClientById(id);
    this.userService.setUser = { id: idCliente }
    this.userCpf = cpfCnpj
    for (const telefone of telefones) {
      this.arrFormGroup.push(new FormGroup({
        cpfCnpj: new FormControl(this.userCpf),
        id: new FormControl(telefone.id),
        ddd: new FormControl(telefone.ddd),
        idTipo: new FormControl(telefone.idTipo),
        numero: new FormControl(telefone.numero),
        envioSms: new FormControl(telefone.envioSms)
      }))
    }
  }

  async saveClient(formGroup: any) {
    const mode = formGroup?.controls?.new?.value === true ? "POST" : "PUT";
    const userData = {
      ...formGroup.value,
      ddd: Number(formGroup.value.ddd),
      id: Number(formGroup.value.id),
      idTipo: Number(formGroup.value.idTipo),
      numero: Number(formGroup.value.numero),
      idCliente: Number(this.userService.getUser.id),
      envioSms: formGroup.value.envioSms === "true" ? true : false
    }
    if (mode === "POST") {
      delete userData.id
    }
    delete userData.new
    delete userData.cpfCnpj
    this.loading = true
    try {
      await this.telefoneService.saveTelefone(userData, mode)
    } catch (error) {
      console.log(error)
    } finally {
      this.loading = false
    }
  }

  newAddres() {
    this.arrFormGroup.unshift(new FormGroup({
      cpfCnpj: new FormControl(this.userCpf),
      id: new FormControl(),
      ddd: new FormControl(),
      idTipo: new FormControl(),
      idCliente: new FormControl(this.userService.getUser.id),
      numero: new FormControl(),
      envioSms: new FormControl(),
      new: new FormControl(true)
    }))
  }
}