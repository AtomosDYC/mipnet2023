import { FormControl } from '@angular/forms';

export interface ValidationResult {
    [key: string]: boolean | null;
}

export class PasswordValidator {

    public static strong(control: FormControl): ValidationResult | null {
        let hasNumber = /\d/.test(control.value);
        let hasUpper = /[A-Z]/.test(control.value);
        let hasLower = /[a-z]/.test(control.value);
        let NonAlpha = /[~!@#$%^&*()-+=?/<>|{}_ :;.,\`]/.test(control.value);
        // //console.log('Num, Upp, Low', hasNumber, hasUpper, hasLower);
        const valid = hasNumber && hasUpper && hasLower && NonAlpha;
        if (!valid) {
            // return what´s not valid
            return { strong: true };
        }
        return null;
    }
}