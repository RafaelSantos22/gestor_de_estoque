using Gestor_De_Estoque;
using Gestor_De_Estoque.Entities;
using Gestor_De_Estoque.Enum;
using System;
using System.Globalization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Gestor_De_Cliente
{
    public class Program
    {
        static List<IEstoque> produtos = new List<IEstoque>();
        static bool escolheuSair = false;

        static void Main(string[] args)
        {
            Carregar();
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

            if (opInt > 0 && opInt < 7)
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
                        Cadastro();
                        break;
                    case Menu.Remover:
                        Remover();
                        break;
                    case Menu.Listar:
                        Listagem();
                        break;
                    case Menu.Entrada:
                        Entrada();
                        break;
                    case Menu.Saida:
                        Saida();
                        break;
                }
            }
            else
            {
                Console.WriteLine("Opção não encontrada!\n");
                escolheuSair = true;
            }
        }

        static void Listagem()
        {
            Console.Clear();
            Console.WriteLine("\t\t\t\t\tLista de Produtos");
            int i = 0;
            if(produtos.Count > 0)
            {
                foreach (IEstoque produto in produtos)
                {

                    Console.WriteLine($"ID: {i}");
                    produto.Exibir();
                    i++;
                }
            } else
            {
                Console.WriteLine("Não há produtos cadastrados!");
            }
        }

        static void Remover()
        {
            Listagem();
            Console.Write("\nDigite o ID do produto que deseja remover: ");
            int id = int.Parse(Console.ReadLine());
            if(id >= 0 && id < produtos.Count)
            {
                produtos.RemoveAt(id);
                Salvar();
            }
            Console.Clear();
            Console.WriteLine("Produto removido com sucesso!");
        }

        static void Entrada()
        {
            Listagem();
            Console.Write("\nDigite o ID do produto que deseja dar entrada: ");
            int id = int.Parse(Console.ReadLine());
            if (id >= 0 && id < produtos.Count)
            {
                produtos[id].AdicionarEntrada();
                Salvar();
            }
        }

        static void Saida()
        {
            Listagem();
            Console.Write("\nDigite o ID do produto que deseja dar baixa: ");
            int id = int.Parse(Console.ReadLine());
            if (id >= 0 && id < produtos.Count)
            {
                produtos[id].AdicionarSaida();
                Salvar();
            }
        }

        static void Cadastro()
        {
            Console.Clear();
            Console.WriteLine("\t\t\t\tCadastro de Produto\n\n");
            Console.WriteLine("1 - Produto Fisico\n2 - Ebook\n3 - Curso\n");
            Console.Write("Escolha a opção desejada: ");
            int opcao = int.Parse(Console.ReadLine());
            switch (opcao)
            {
                case 1:
                    CadastrarPFisico();
                    break;
                case 2:
                    CadastrarEbook();
                    break;
                case 3:
                    CadastrarCurso();
                    break;
            }
        }

        static void CadastrarPFisico()
        {
            Console.Clear();
            Console.WriteLine("Cadastrando produto fisico\n");
            Console.Write("Nome: ");
            string nome = Console.ReadLine();
            Console.Write("Preço: ");
            double preco = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.Write("Frete: ");
            double frete = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            produtos.Add(new ProdutoFisico(nome, preco, frete));
            Salvar();
            Console.Clear();
            Console.WriteLine("Produto cadastrado com sucesso!\n");
        }

        static void CadastrarEbook()
        {
            Console.Clear();
            Console.WriteLine("Cadastrando Ebook\n");
            Console.Write("Nome: ");
            string nome = Console.ReadLine();
            Console.Write("Preço: ");
            double preco = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.Write("Autor: ");
            string autor = Console.ReadLine();
            produtos.Add(new Ebook(nome, preco, autor));
            Salvar();
            Console.Clear();
            Console.WriteLine("Produto cadastrado com sucesso!\n");
        }

        static void CadastrarCurso()
        {
            Console.Clear();
            Console.WriteLine("Cadastrando Curso\n");
            Console.Write("Nome: ");
            string nome = Console.ReadLine();
            Console.Write("Preço: ");
            double preco = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.Write("Autor: ");
            string autor = Console.ReadLine();
            produtos.Add(new Curso(nome, preco, autor));
            Salvar();
            Console.Clear();
            Console.WriteLine("Produto cadastrado com sucesso!\n");
        }

        static void Salvar()
        {
            FileStream stream = new FileStream("estoque.txt", FileMode.OpenOrCreate);
            BinaryFormatter enconder = new BinaryFormatter();

            enconder.Serialize(stream, produtos);
            stream.Close();
        }

        static void Carregar()
        {
            FileStream stream = new FileStream("estoque.txt", FileMode.OpenOrCreate);
            BinaryFormatter enconder = new BinaryFormatter();

            try
            {
                produtos = (List<IEstoque>)enconder.Deserialize(stream);

                if(produtos == null)
                {
                    produtos = new List<IEstoque>();
                }

            }
            catch(Exception e)
            {
                produtos = new List<IEstoque>();
            }
            stream.Close();
        }
    }
}