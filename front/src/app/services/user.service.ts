import { Injectable } from "@angular/core";

@Injectable()
export class UserService {
    private selectedUser: any = undefined;

    set setUser(userData: any) {
        this.selectedUser = userData;
    }

    get getUser() {
        if (!this.selectedUser) return undefined;
        return this.selectedUser;
    }
}