using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio04
{
//4. Escreva um algoritmo em Portugol(ou na linguagem de sua preferência), para realizar o recálculo de Boletos.
//Ele deverá ler a data de vencimento original, a data de vencimento nova (data de pagamento) e valor do boleto, e deverá apresentar o valor do boleto recalculado, e o valor total dos juros do período.

//Você deve considerar:

//- Valor dos juros por dia: R$ 0,03 (3%) e Valor da multa: R$ 2,00 (valores fixos)
//- As datas podem ser informadas com o tipo de dados data
//- As datas podem ser comparadas com os Operadores Relacionais, e podem ser usados Operadores Aritméticos
//- Ex.: data<- data + 1 // Acrescenta um dia na data
//- Ex.: numDias<- dataFim - dataInicio // Retorna o número de dias entre as duas datas
//- Existe uma função VerificaFeriado(data : data) : lógico
//- Essa função retorna VERDADEIRO quando uma data for feriado, e FALSO caso contrário
//- Existe uma função VerificaFinalDeSemana(data : data) : lógico
//- Essa função retorna VERDADEIRO quando uma data for final de semana, e FALTO caso contrário

//As regras de recálculo que devem ser respeitadas:

//1. Se a data de vencimento for final de semana ou feriado, e a data de pagamento no dia útil consecutivo, não deve ser cobrado juros nem multa.Ex.: Vencimento sábado e pagamento na segunda-feira;
//2. Se a data de vencimento for final de semana ou feriado, e o pagamento for posterior ao dia útil consecutivo, deve ser cobrado juros de todo o período.Ex.: Vencimento sábado e pagamento na terça-feira: três dias de juros + multa.
//3. Se a data de vencimento for feriado, e o pagamento no dia seguinte (dia útil), não deve ser cobrado juros nem multa.Ex.: Vencimento 15/junho/2017 e pagamento 16/junho/2017;
//4. Se a data de vencimento for feriado antecessor a um final de semana, e o pagamento for na segunda-feira(dia útil consecutivo), não deve ser cobrado juros nem multa.Ex.: Vencimento 21/abril/2017 e pagamento 24/abril/2017;
//5. Se a data de vencimento for feriado, e o pagamento dois dias úteis consecutivos após feriado, deve ser cobrado jutos de todo o período.Ex.Vencimento 14/abril/2017 e pagamento 18/abril/2017: quatro dias de juros + multa;
//6. Se o vencimento for dia útil, e o pagamento no mesmo dia, não deve ser cobrado juros nem multa;
//7. Se a data de pagamento for anterior à data de vencimento, não deve ser cobrado juros nem multa;
//8. Se o vencimento for dia útil, e o pagamento no dia útil consecutivo, dever ser cobrado juros e multa de apenas um período.Ex.: Vencimento 20/julho/2017 pagamento 21/julho/2017: um dia de juros + multa.


    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
