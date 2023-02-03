using Gestor_De_Estoque.Enum;
using System;

namespace Gestor_De_Cliente
{
    public class Program
    {
        static bool escolheuSair = false;

        static void Main(string[] args)
        {
            while (!escolheuSair)
            {
                MenuPrincipal();
            }
        }

        static void MenuPrincipal()
        {
            Console.WriteLine("\t\t\t\t--------------------------------");
            Console.WriteLine("\t\t\t\t\tSistema de Estoque");
            Console.WriteLine("\t\t\t\t--------------------------------\n\n");
            Console.WriteLine("1 - Listar\n2 - Adicionar\n3 - Remover\n4 - Registrar entrada\n5 - Registrar saída\n6 - Sair\n");
            Console.Write("Digite a opção desejada: ");
            int opInt = int.Parse(Console.ReadLine());

            if(opInt > 0 && opInt < 7)
            {
                Menu opcao = (Menu)opInt;

                switch (opcao)
                {
                    case Menu.Sair:
                        Console.Clear();
                        Console.WriteLine("Programa encerrado!\n");
                        escolheuSair = true;
                        break;
                    case Menu.Adicionar:
                        break;
                }
            } else
            {
                Console.WriteLine("Opção não encontrada!\n");
                escolheuSair = true;
            }
        }
    }
}