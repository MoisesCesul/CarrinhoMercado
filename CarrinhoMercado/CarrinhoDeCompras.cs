using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrinhoMercado
{
    public class CarrinhoDeCompras
    {
        private List<Produto> produtos;
        private AuditLogSpy auditLog;


        //adiciona um produto
        public void AdicionarProduto(Produto produto)
        {
            produtos.Add(produto);
        }

        //construtor da classe

        public CarrinhoDeCompras(AuditLogSpy auditLog)
        {
            produtos = new List<Produto>();
            this.auditLog = auditLog;
        }
        //remove produto
        public void RemoverProduto(Produto produto)
        {
            if (produtos.Remove(produto))
            {
                Console.WriteLine($"Produto removido: {produto}");
            }
            else
            {
                Console.WriteLine("Produto não encontrado no carrinho.");
            }
        }
        //calcula preço
        public decimal CalcularTotal()
        {
            decimal total = 0;
            foreach (var produto in produtos)
            {
                total += produto.Preco;
            }
            return total;
        }
        //mostra os produtos
        public void MostrarProdutos()
        {
            Console.WriteLine("Produtos no carrinho:");
            foreach (var produto in produtos)
            {
                Console.WriteLine(produto);
            }
        }
        //finaliza a compra
        public bool FinalizarCompra()
        {
            if (produtos.Count == 0)
            {
                return false;
            }

            auditLog.LogFinalizacao(); 
            produtos.Clear(); 
            return true;
        }
    }
}
