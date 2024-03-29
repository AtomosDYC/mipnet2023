
export function calcularVerificador(numero: string):string {
        let sum = 0;
        let mul = 2;
      
        let i = numero.length;
        while (i--) {
          sum = sum + parseInt(numero.charAt(i)) * mul;
          if (mul % 7 === 0) {
            mul = 2;
          } else {
            mul++;
          }
        }
      
        const res = sum % 11;
      
        if (res === 0) {
          return '0';
        } else if (res === 1) {
          return 'k';
        }
      
        return `${11 - res}`;
      }
