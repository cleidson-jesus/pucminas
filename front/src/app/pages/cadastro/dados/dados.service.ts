import { Injectable } from '@angular/core';
import { HttpService } from 'src/app/services/http.service';
import { environment } from 'src/environments/environment';

@Injectable()
export class DadosGenericosService {
  constructor(private http: HttpService) {}

  getClientById(id: number): Promise<any> {
    return new Promise(async (resolve, reject) => {
      try {
        const response = await this.http.GET(
          `${environment.myCustomersAPI}/pessoa-fisica/${id}`
        );
        return resolve(response);
      } catch (error) {
        return reject(error);
      }
    });
  }

  saveClientDataById(clientData: any): Promise<any> {
    return new Promise(async (resolve, reject) => {
      try {
        const response = await this.http.PUT(
          `${environment.myCustomersAPI}/pessoa-fisica`,
          clientData
        );
        return resolve(response);
      } catch (error) {
        return reject(error);
      }
    });
  }
}