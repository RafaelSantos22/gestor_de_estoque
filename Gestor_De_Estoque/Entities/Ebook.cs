using System.Globalization;

namespace Gestor_De_Estoque.Entities
{
    [Serializable]
    public class Ebook : Produto, IEstoque
    {
        public string Autor { get; set; }
        public int Vendas { get; private set; }

        public Ebook(string nome, double preco, string autor): base(nome, preco)
        {
            Autor = autor;
        }

        public void Exibir()
        {
            Console.WriteLine($"Nome: {Nome}\n" +
                             $"Autor: {Autor}\n" +
                             $"Preço: $ {Preco.ToString("F2", CultureInfo.InvariantCulture)}\n" +
                             $"Vendas: {Vendas}");
            Console.WriteLine("===============================");
        }

        public void AdicionarEntrada()
        {
            Console.Clear();
            Console.WriteLine("Não é possível dar entrada no estoque de um E-book, pois é um produto digital!");
            Console.ReadLine();
        }

        public void AdicionarSaida()
        {
            Console.Clear();
            Console.WriteLine($"Adicionar vendas no {Nome}\n");
            Console.Write("Digite a quantidade de vendas que você quer dar entrada: ");
            int saida = int.Parse(Console.ReadLine());
            Vendas += saida;
            Console.WriteLine("\nSaída registrada!");
            Console.ReadLine();
        }
    }
}
