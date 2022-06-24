using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio01
{
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

                CalculateDiscount(float.Parse(valueInput), short.Parse(yearInput));

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
