import { Injectable } from '@angular/core';
@Injectable()

export class LogService {
    log(msg: any) {
        console.log(new Date().toLocaleTimeString() + ": \n" + JSON.stringify(msg));
    }
}
