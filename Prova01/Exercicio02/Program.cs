using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio02
{
    //2. Escreva um algoritmo em Portugol(ou na linguagem de sua preferência), que leia um número não determinado de valores.
    //Cada conjunto formado por número do aluno (código) e suas três notas.

    //Calcular para cada aluno a média ponderada com pesos respectivos de 4 para a MAIOR nota, e 3 para as outras duas notas.
    //Escrever o número do aluno (código), suas 3 notas, a média calculada e uma mensagem (APROVADO), se a média for ≥ 6 e (REPROVADO) se a média for < 6.

    //Encerrar a leitura de valores assim que for digitado 0 no código de aluno.

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Calculo de Média e Aprovação");

            int codAluno = -1;
            float nota01 = 0f;
            float nota02 = 0f;
            float nota03 = 0f;
            float notaFinal = 0f;

            while(true)
            {
                try
                {
                    Console.WriteLine("\n\nInforme o código do Aluno:");
                    codAluno = int.Parse(Console.ReadLine());

                    if (codAluno == 0)
                        return;

                    Console.WriteLine("\nInforme a primeira nota: ");
                    nota01 = float.Parse(Console.ReadLine());

                    Console.WriteLine("\nInforme a segunda nota: ");
                    nota02 = float.Parse(Console.ReadLine());

                    Console.WriteLine("\nInforme a terceira nota: ");
                    nota03 = float.Parse(Console.ReadLine());

                    notaFinal = ((4 * nota01) + (3 * nota02) + (3 * nota03)) / 10f;

                    Console.WriteLine($"\n\nNota 01: {nota01}\nNota 02: {nota02}\nNota 03: {nota03}\nMédia: {notaFinal}");

                    if (notaFinal >= 6)
                        Console.WriteLine("\n\nAluno foi APROVADO!");
                    else if (notaFinal < 6)
                        Console.WriteLine("\n\nAluno foi REPROVADO!");
                }
                catch(Exception e)
                {
                    Console.WriteLine(e);
                }
            }          
        }
    }
}
