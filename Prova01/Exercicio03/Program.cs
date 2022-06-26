using System;

namespace Exercicio03
{

    //3. Considere o seguinte algoritmo:

    //algoritmo "Triângulos"
    //var
    //    a, b, c: inteiro
    //    mens: caractere
    //inicio
    //    ler a, b, c
    //   se(a<b+c) e (b<a+c) e (c<a+b) entao
    //      se(a = b) e (b = c) entao
    //          mens <- "Triângulo Equilátero"
    //      senao
    //          se (a = b) ou (b = c) ou (a = c) então
    //              mens <- "Triângulo Isósceles"
    //          senao
    //              mens <- "Triângulo Escaleno"
    //          fim-se
    //      fim-se
    //   senao
    //      mens <- "Não e possível formar um triângulo"
    //   fim-se
    //   mostrar mens
    //fim

    //Faça um teste de mesa e complete os campos a seguir para os seguintes valores das variáveis:

    //a) a = 1, b = 2, c = 3
    //b) a = 3, b = 4, c = 5
    //c) a = 2, b = 2, c = 4
    //d) a = 4, b = 4, c = 4
    //e) a = 5, b = 3, c = 3

    //RESPOSTAS:
    //A) "Não é possível formar um triângulo"
    //B) "Triângulo Escaleno"
    //C) "Não é possível formar um triângulo"
    //D) "Triângulo Equilátero"
    //E) "Triângulo Isósceles"

    class Program
    {
        static void Main(string[] args)
        {
            //Loop para permitir o uso continuo do programa 
            while (true)
            {
                int a, b, c;
                string mens;

                a = int.Parse(Console.ReadLine());
                b = int.Parse(Console.ReadLine());
                c = int.Parse(Console.ReadLine());

                if (a < b + c && b < a + c && c < a + b)
                {
                    if (a == b && b == c)
                        mens = "Triângulo Equilátero";
                    else
                    {
                        if (a == b || b == c || a == c)
                            mens = "Triângulo Isósceles";
                        else
                            mens = "Triângulo Escaleno";
                    }
                }
                else
                {
                    mens = "Não é possível formar um triângulo";
                }

                Console.WriteLine(mens);
            }
        }
    }
}
