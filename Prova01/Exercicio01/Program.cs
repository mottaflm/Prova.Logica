using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio01
{
    //1. Uma concessionária de carros está vendendo os seus veículos com desconto.
    //Faça um algoritmo em Portugol(ou na linguagem de sua preferência) que calcule e exiba o valor do desconto e o valor a ser pago pelo cliente de vários carros.

    //O desconto deverá ser calculado de acordo com o ano do veículo.

    //Até 2000 - 12%
    //Acima de 2000 - 7%

    //O algoritmo deverá perguntar se deseja continuar calculando desconto até que a resposta seja “N” (Não).
    //Informar total de carros com ano até 2000 e total geral.

    public class Program
    {

        public static int NewCarsCounter = 0;
        public static int OldCarsCounter = 0;

        static void Main(string[] args)
        {
            Console.WriteLine("Calculo de Desconto de Veículos\n");

            var resposta = "Y";

            while(resposta != "N")
            {
                Console.WriteLine("\nInforme o valor do veículo:");
                var valueInput = Console.ReadLine();

                Console.WriteLine("\nInforme o ano do veículo:");
                var yearInput = Console.ReadLine();

                try
                {
                    CalculateDiscount(float.Parse(valueInput), short.Parse(yearInput));
                }
                catch(Exception e)
                {
                    Console.WriteLine(e);
                }

                Console.WriteLine("\nDeseja continuar calculando desconto de veículos? (Y/N):");
                resposta = Console.ReadLine().ToUpper();
            }

            Console.WriteLine($"\n\nTotal de Carros até 2000: {OldCarsCounter}\nTotal de Carros cadastrados: {NewCarsCounter + OldCarsCounter}");

            Console.WriteLine("\n\nPressione qualquer tecla para sair...");
            Console.ReadLine();
        }

        private static void CalculateDiscount(float value, short year)
        {
            float result;

            if (year > 2000)
            {
                result = value - (7 * value / 100);
                Console.WriteLine($"\nO valor de R${value} de um veículo de {year} sai com desconto de 7% totalizando: R${result}");
                NewCarsCounter++;
                return;
            }

            result = value - (12 * value / 100);
            Console.WriteLine($"\nO valor de R${value} de um veículo de {year} sai com desconto de 12% totalizando: R${result}");
            OldCarsCounter++;
        }
    }
}
