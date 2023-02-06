using System.Globalization;

namespace Gestor_De_Estoque.Entities
{
    [Serializable]
    public class Curso : Produto, IEstoque
    {
        public string Autor { get; set; }
        public int Vagas { get; private set; }

        public Curso(string nome, double preco, string autor): base(nome, preco)
        {
            Autor = autor;
        }

        public void Exibir()
        {
            Console.WriteLine($"Nome: {Nome}\n" +
                              $"Autor: {Autor}\n" +
                              $"Preço: $ {Preco.ToString("F2", CultureInfo.InvariantCulture)}\n" +
                              $"Vagas restantes: {Vagas}");
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
