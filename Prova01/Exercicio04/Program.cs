using System;
using System.Collections.Generic;

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


    //- Variaveis
    /* ValorBoleto
     * DataVencimento (Data Vencimento Original)
     * DataPagamento (Data Vencimento Final)
     * 
     *- Saída
     * ValorBoletoRecalculado
     * ValorTotalJuros
     */
    class Program
    {
        private const float jurosDiario = 0.03f;
        private const float jurosMulta = 2f;

        static void Main(string[] args)
        {
            //Declarando as variáveis necessárias
            float valorBoleto, valorBoletoRecalculado, valorJuros;
            DateTime dataVencimento, dataPagamento;

            //Programa irá rodar infinitamente (Não especificado no requisto, usado para fins de teste)
            while (true)
            {
                Console.WriteLine("\n\n== Calculo Data de Vencimento de Boletos ==");

                try
                {

                    //Pegando entradas do usuário
                    Console.WriteLine("\n\nInforme a DATA DE VENCIMENTO ORIGINAL:");
                    dataVencimento = DateTime.Parse(Console.ReadLine());

                    Console.WriteLine("\nInforme o VALOR DO BOLETO:");
                    valorBoleto = float.Parse(Console.ReadLine());

                    Console.WriteLine("\nInforme a DATA DE VENCIMENTO NOVA:");
                    dataPagamento = DateTime.Parse(Console.ReadLine());

                    //Calculando Juros
                    valorJuros = CalculaJuros(dataVencimento, dataPagamento);

                    //Adicionando Juros calculado
                    valorBoletoRecalculado = valorBoleto + valorJuros;
                    Console.WriteLine($"\n\nO valor do boleto com a nova data de vencimento {dataPagamento.ToString("dd/MM/yyyy")} será de R${valorBoletoRecalculado.ToString("0.00")} sendo R${valorJuros.ToString("0.00")} de Juros!");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }

        private static float CalculaJuros(DateTime dataVencimento, DateTime dataPagamento)
        {
            var jurosCalculado = 0f;
            var diasSemPagar = 0;

            //Criando FLAGS para identificarmos se as datas informadas são dias Uteis
            var isDataVencDiaUtil = !(VerificaFeriado(dataVencimento) || VerificaFinalDeSemana(dataVencimento));

            //Caso a data de Pagamento seja Feriado ou FDS, adicionamos 1 dia ATÉ que seja dia Util
            bool isDataPagDiaUtil = !(VerificaFeriado(dataPagamento) || VerificaFinalDeSemana(dataPagamento));
            while (!isDataPagDiaUtil)
            {
                dataPagamento.AddDays(1);

                if(!(VerificaFeriado(dataPagamento) || VerificaFinalDeSemana(dataPagamento)))
                    isDataPagDiaUtil = true;
            }

            //1. Se a data de vencimento for final de semana ou feriado, e a data de pagamento no dia útil consecutivo, não deve ser cobrado juros nem multa.
            if (!isDataVencDiaUtil && isDataPagDiaUtil)
            {
                var diaAnteriorAoPagamento = dataPagamento.AddDays(-1);

                //3. Se a data de vencimento for feriado, e o pagamento no dia seguinte (dia útil), não deve ser cobrado juros nem multa
                if (VerificaFeriado(diaAnteriorAoPagamento) || VerificaFinalDeSemana(diaAnteriorAoPagamento))
                {
                    //4. Se a data de vencimento for feriado antecessor a um final de semana, e o pagamento for na segunda-feira (dia útil consecutivo), não deve ser cobrado juros nem multa
                    if (VerificaFeriado(dataVencimento) && VerificaFinalDeSemana(dataVencimento.AddDays(1)))
                        return jurosCalculado;

                    return jurosCalculado;
                }
                else
                {
                    //2. Se a data de vencimento for final de semana ou feriado, e o pagamento for posterior ao dia útil consecutivo, deve ser cobrado juros de todo o período
                    //5. Se a data de vencimento for feriado, e o pagamento dois dias úteis consecutivos após feriado, deve ser cobrado jutos de todo o período.
                    diasSemPagar = dataPagamento.Subtract(dataVencimento).Days;
                    return (jurosDiario * diasSemPagar) + jurosMulta;
                }
            }
            //6. Se o vencimento for dia útil, e o pagamento no mesmo dia, não deve ser cobrado juros nem multa
            else if(isDataVencDiaUtil && dataPagamento == dataVencimento)
            {
                return jurosCalculado;
            }
            //7. Se a data de pagamento for anterior à data de vencimento, não deve ser cobrado juros nem multa
            else if (dataPagamento < dataVencimento)
            {
                return jurosCalculado;
            }
            //8. Se o vencimento for dia útil, e o pagamento no dia útil consecutivo, dever ser cobrado juros e multa de apenas um período.Ex.: Vencimento 20/julho/2017 pagamento 21/julho/2017: um dia de juros + multa.
            else
            {
                diasSemPagar = dataPagamento.Subtract(dataVencimento).Days;
                return (jurosDiario * diasSemPagar) + jurosMulta;
            }
        }

        private static bool VerificaFinalDeSemana(DateTime valorData)
        {
            return valorData.DayOfWeek == DayOfWeek.Saturday || valorData.DayOfWeek == DayOfWeek.Sunday;
        }

        private static bool VerificaFeriado(DateTime valorData)
        {
            //Criando a coleção de datas que possuem feriados nacionais FIXOS
            //Utilizado como base: https://www.calendarr.com/brasil/feriados-nacionais-e-pontos-facultativos/

            HashSet<DateTime> diasDeFeriado = new HashSet<DateTime>();

            diasDeFeriado.Add(DateTime.Parse("01/01/" + valorData.Year)); //Virada do Ano
            diasDeFeriado.Add(DateTime.Parse("21/04/" + valorData.Year)); //Tiradentes
            diasDeFeriado.Add(DateTime.Parse("01/05/" + valorData.Year)); //Dia do Trabalho
            diasDeFeriado.Add(DateTime.Parse("07/09/" + valorData.Year)); //Independencia do Brasil
            diasDeFeriado.Add(DateTime.Parse("12/10/" + valorData.Year)); //Nossa Senhora Aparecida
            diasDeFeriado.Add(DateTime.Parse("02/11/" + valorData.Year)); //Finados
            diasDeFeriado.Add(DateTime.Parse("15/11/" + valorData.Year)); //Proclamação da Republica
            diasDeFeriado.Add(DateTime.Parse("25/12/" + valorData.Year)); //Natal

            diasDeFeriado.Add(CalcularFeriado(valorData.Year, FeriadoEnum.Carnaval)); //Carnaval
            diasDeFeriado.Add(CalcularFeriado(valorData.Year, FeriadoEnum.QuartaCinzas)); //Quarta-feira de Cinzas
            diasDeFeriado.Add(CalcularFeriado(valorData.Year, FeriadoEnum.SextaSanta)); //Sexta-Feira Santa
            diasDeFeriado.Add(CalcularFeriado(valorData.Year, FeriadoEnum.CorpusChristi)); //Corpus Christi

            return diasDeFeriado.Contains(valorData);
        }

        //Codigo para calcular os Feriados Flexiveis retirado de: http://hernaski.com.br/blog/calcular-data-de-pascoa-e-carnaval-em-c/5
        private static DateTime CalcularFeriado(int ano, FeriadoEnum feriado) 
        {
            DateTime data = CalcularPascoa(ano);

            switch (feriado)
            {
                case FeriadoEnum.Carnaval:
                    return data.AddDays(-47);
                case FeriadoEnum.QuartaCinzas:
                    return data.AddDays(-46);
                case FeriadoEnum.SextaSanta:
                    return data.AddDays(-2);
                case FeriadoEnum.CorpusChristi:
                    return data.AddDays(60);
            }

            return data;
        }

        private static DateTime CalcularPascoa(int ano)
        {
            int r1 = ano % 19;
            int r2 = ano % 4;
            int r3 = ano % 7;
            int r4 = (19 * r1 + 24) % 30;
            int r5 = (6 * r4 + 4 * r3 + 2 * r2 + 5) % 7;
            DateTime dataPascoa = new DateTime(ano, 3, 22).AddDays(r4 + r5);
            int dia = dataPascoa.Day;
            switch (dia)
            {
                case 26:
                    dataPascoa = new DateTime(ano, 4, 19);
                    break;
                case 25:
                    if (r1 > 10)
                        dataPascoa = new DateTime(ano, 4, 18);
                    break;
            }
            return dataPascoa.Date;
        }

        private enum FeriadoEnum
        {
            Carnaval,
            QuartaCinzas,
            SextaSanta,
            CorpusChristi,
        }
    }
}
