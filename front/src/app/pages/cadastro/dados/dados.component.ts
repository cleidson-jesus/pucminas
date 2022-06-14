import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { UserService } from 'src/app/services/user.service';
import { isoDateToLocale, localeDateToIsoString } from 'src/app/utils';
import { DadosGenericosService } from './dados.service';
import { dateFields, selectOptions } from './dados.utils';

@Component({
  selector: 'dados',
  templateUrl: 'dados.component.html',
  styleUrls: ['./dados.component.scss'],
})
export class DadosGenericosComponent implements OnInit {
  loading: boolean = true;
  selectControl = new FormControl('M');
  selectOptions = selectOptions;
  userSelectedId: number | undefined;

  constructor(
    private router: Router,
    private dadosGenericosService: DadosGenericosService,
    private userService: UserService,
    private activatedRoute: ActivatedRoute
  ) { }

  formGroup = new FormGroup({
    cpfCnpj: new FormControl(),
    nome: new FormControl(),
    idTipo: new FormControl(),
    dataHoraInclusao: new FormControl(),
    idrating: new FormControl(),
    exposicaoMidia: new FormControl(),
    pessoaPep: new FormControl(),
    email: new FormControl(),
    idGenero: new FormControl(),
    dataNascimento: new FormControl(),
    renda: new FormControl(),
    numeroDocIdentificacao: new FormControl(),
    dataHoraAtualizacao: new FormControl(),
    idCidadeNascimento: new FormControl(),
    dataFichaCadastral: new FormControl()
  });

  async ngOnInit(): Promise<void> {
    const { id } = this.activatedRoute.snapshot.params
    if (!id && this.userService.getUser) {
      this.userSelectedId = this.userService.getUser.id;
      this.router.navigate(["cadastro", "endereco", this.userSelectedId])
      return
    }
    if (!id && !this.userSelectedId) {
      this.goBack();
      return;
    }
    await this.getClientData(id).catch((_) => null);
    this.loading = false;
  }

  getControl(name: string): FormControl {
    const control = this.formGroup.get(name);
    return control as FormControl;
  }

  goBack() {
    this.router.navigate(['cadastro', 'consulta']);
  }

  async getClientData(id: number) {
    let userData = await this.dadosGenericosService.getClientById(id);
    this.userSelectedId = userData.id;
    this.userService.setUser = userData;
    for (let property of Object.keys(this.formGroup.controls)) {
      const control = this.formGroup.get(property);
      if (dateFields.includes(property)) {
        control?.setValue(isoDateToLocale(userData[property]));
      } else {
        control?.setValue(userData[property]);
      }
    }
  }

  async saveClient() {
    this.loading = true;
    const formatedClientData = {
      ...this.formGroup.value,
      cpfCnpj: Number(this.formGroup.value.cpfCnpj),
      dataFichaCadastral: localeDateToIsoString(this.formGroup.value.dataFichaCadastral),
      dataHoraAtualizacao: localeDateToIsoString(this.formGroup.value.dataHoraAtualizacao),
      dataHoraInclusao: localeDateToIsoString(this.formGroup.value.dataHoraInclusao),
      dataNascimento: localeDateToIsoString(this.formGroup.value.dataNascimento),
      id: this.userSelectedId,
      exposicaoMidia: this.formGroup.value.exposicaoMidia === "true" ? true : false,
      pessoaPep: this.formGroup.value.pessoaPep === "true" ? true : false,
      idGenero: Number(this.formGroup.value.idGenero),
      idrating: Number(this.formGroup.value.idrating)
    };
    try {
      await this.dadosGenericosService.saveClientDataById(formatedClientData)
    } catch (error) {
      console.log(error)
    } finally {
      this.loading = false;
    }
  }
}
