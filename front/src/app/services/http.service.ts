import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { lastValueFrom, map, of } from "rxjs";

@Injectable()
export class HttpService {

  constructor(
    private http: HttpClient
  ) {

  }

  GET(url: string, headers?: any) {
    return new Promise(async (resolve, reject) => {
      try {
        const response = await lastValueFrom(this.http.get(url, { headers }).pipe(map((res: any) => (res))));
        return resolve(response);
      } catch (error) {
        return reject(error);
      }
    })
  }

  POST(url: string, body: any, headers?: any) {
    return new Promise(async (resolve, reject) => {
      try {
        const response = await lastValueFrom(this.http.post(url, body, { headers }).pipe(map((res: any) => (res))));
        return resolve(response);
      } catch (error) {
        return reject(error);
      }
    })
  }

  PUT(url: string, body: any, headers?: any) {
    return new Promise(async (resolve, reject) => {
      try {
        const response = await lastValueFrom(this.http.put(url, body, { headers }).pipe(map((res: any) => (res))));
        return resolve(response);
      } catch (error) {
        return reject(error);
      }
    })
  }

}