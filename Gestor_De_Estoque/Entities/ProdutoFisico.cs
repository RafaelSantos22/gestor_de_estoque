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
            
        }

        public void AdicionarSaida()
        {
            
        }
    }
}
