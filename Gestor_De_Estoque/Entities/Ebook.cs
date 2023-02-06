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
        }

        public void AdicionarSaida()
        {
        }
    }
}
