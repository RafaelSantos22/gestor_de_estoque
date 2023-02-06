using System.Globalization;

namespace Gestor_De_Estoque.Entities
{
    [Serializable]
    public class ProdutoFisico : Produto, IEstoque
    {
        public double Frete { get; set; }
        public int Estoque { get; private set; }

        public ProdutoFisico(string nome, double preco, double frete): base(nome, preco)
        {
            Frete = frete;
        }

        public void Exibir()
        {
            Console.WriteLine($"Nome: {Nome}\n" +
                             $"Frete: $ {Frete.ToString("F2", CultureInfo.InvariantCulture)}\n" +
                             $"Preço: $ {Preco.ToString("F2", CultureInfo.InvariantCulture)}\n" +
                             $"Estoque: {Estoque}");
            Console.WriteLine("===============================");
        }

        public void AdicionarEntrada()
        {
            Console.Clear();
            Console.WriteLine($"Adicionar entrada no estoque do produto {Nome}\n");
            Console.Write("Digite a quantidade que você quer dar entrada: ");
            int entrada = int.Parse( Console.ReadLine());
            Estoque += entrada;
            Console.WriteLine("\nEntrada registrada!");
            Console.ReadLine();
        }

        public void AdicionarSaida()
        {
            Console.Clear();
            Console.WriteLine($"Adicionar saída no estoque do produto {Nome}\n");
            Console.Write("Digite a quantidade que você quer dar baixa: ");
            int saida = int.Parse(Console.ReadLine());
            Estoque -= saida;
            Console.WriteLine("\nSaída registrada!");
            Console.ReadLine();
        }
    }
}
