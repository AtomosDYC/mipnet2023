import { Injectable } from '@angular/core'

@Injectable({
  providedIn: 'root',
})

export class LoginValidationServices {

  errormensaje: any;

  formrules = {
    nonEmpty: '^[a-zA-Z0-9]+([_ -])?[a-zA-Z0-9]*$',
    emailMin: 5,
    passwordMin: 6,
    passwordPattern: '(?=.*\\d)(?=.*[a-z])(?=.*[A-Z]).{6,}'
  }

  formErrors = {
    email: '',
    password: ''
  }

  constructor(){
    this.errormensaje = {
       email: {
        require: 'Email es obligatorio',
        minLength: `Email debe contener ${this.formrules.emailMin} caracteres o más` ,
        pattern: 'Debe contener letras y numeros, sin espacios en blanco',
       },
       password: {
        require: 'Contraseña es obligatoria',
        pattern: 'Contraseña debe contener: numeros, letras mayusculas y minusculas',
        minLength: `Contraseña debe contener ${this.formrules.passwordMin} caracteres o más` ,
       }
    }
  }

}
