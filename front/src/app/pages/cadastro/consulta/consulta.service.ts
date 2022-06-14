import { Injectable } from "@angular/core";
import { HttpService } from "src/app/services/http.service";
import { environment } from "src/environments/environment";

@Injectable()
export class ConsultaService {

    clients: any;

    constructor(private http: HttpService) { }

    async getClientData(input: string, mode: "nome" | "cpfcnpj") {
        const response = await this.http.GET(`${environment.myCustomersAPI}/Cliente/${mode}/${input}`);
        return response;
    }
}