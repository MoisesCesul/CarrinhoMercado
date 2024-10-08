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

        public CarrinhoDeCompras()
        {
            produtos = new List<Produto>();
            this.auditLog = auditLog;
        }
        public void AdicionarProduto(Produto produto)
        {
            produtos.Add(produto);
        }
        public CarrinhoDeCompras(AuditLogSpy auditLog)
        {
            produtos = new List<Produto>();
            this.auditLog = auditLog;
        }
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

        public decimal CalcularTotal()
        {
            decimal total = 0;
            foreach (var produto in produtos)
            {
                total += produto.Preco;
            }
            return total;
        }

        public void MostrarProdutos()
        {
            Console.WriteLine("Produtos no carrinho:");
            foreach (var produto in produtos)
            {
                Console.WriteLine(produto);
            }
        }
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
