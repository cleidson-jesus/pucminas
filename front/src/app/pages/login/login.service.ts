import { Injectable } from '@angular/core';
import { HttpService } from '../../services/http.service';

@Injectable()
export class LoginService {
  constructor(private http: HttpService) {}

  login(login: string, senha: string): Promise<any> {
    return new Promise(async (resolve, reject) => {
      setTimeout(() => {
        if (login === 'usuario' && senha === 'senh@123') {
          return resolve({ token: 'QpwL5tke4Pnpja7X4' });
        } else {
          return reject({ message: 'Credenciais incorretas' });
        }
      }, 2000);
    });
  }
}
