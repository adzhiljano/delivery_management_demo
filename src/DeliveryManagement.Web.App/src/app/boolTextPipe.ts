import { Pipe, PipeTransform } from '@angular/core';

@Pipe({ name: 'boolText' })
export class BoolTextPipe implements PipeTransform {

    transform(value?: boolean): any {
        if (value !== undefined && value !== null) {
            return value ? "Yes" : "No";
        } else {
            return value;
        }
    }
}
