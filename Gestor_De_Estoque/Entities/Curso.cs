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
            Console.Clear();
            Console.WriteLine($"Adicionar vagas no curso {Nome}\n");
            Console.Write("Digite a quantidade vagas que você quer dar entrada: ");
            int entrada = int.Parse(Console.ReadLine());
            Vagas += entrada;
            Console.WriteLine("\nEntrada registrada!");
            Console.ReadLine();
        }

        public void AdicionarSaida()
        {
            Console.Clear();
            Console.WriteLine($"Consumir vagas no curso {Nome}\n");
            Console.Write("Digite a quantidade de vagas que você quer dar consumir: ");
            int saida = int.Parse(Console.ReadLine());
            Vagas -= saida;
            Console.WriteLine("\nSaída registrada!");
            Console.ReadLine();
        }
    }
}
