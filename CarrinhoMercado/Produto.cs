using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrinhoMercado
{
    public class Produto
    {
        public string Nome { get; set; }
        public decimal Preco { get; set; }

        public Produto(string nome, decimal preco)
        {
            Nome = nome;
            Preco = preco;
        }
        //toda classe por padrão extende uma classe chamada object, nela tem toString no qual eu estou sobrescrevendo
        public override string ToString()
        {
            return $"{Nome} - R$ {Preco:F2}";
        }
    }
}
