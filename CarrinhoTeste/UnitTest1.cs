using CarrinhoMercado;

namespace CarrinhoTeste
{
    public class CarrinhoDeComprasTests
    {
        [Fact]
        public void FinalizarCompra_CarrinhoVazio_DeveRetornarFalso()
        {
      
            var auditLogSpy = new AuditLogSpy();
            var carrinho = new CarrinhoDeCompras(auditLogSpy);

      
            var resultado = carrinho.FinalizarCompra();

            Assert.False(resultado);
            Assert.False(auditLogSpy.LogFinalizacaoChamada); 
        }

        [Fact]
        public void FinalizarCompra_CarrinhoComProdutos_DeveRetornarVerdadeiro()
        {
         
            var auditLogSpy = new AuditLogSpy();
            var carrinho = new CarrinhoDeCompras(auditLogSpy);
            var produto = new Produto("Camiseta", 29.90m);
            carrinho.AdicionarProduto(produto);

       
            var resultado = carrinho.FinalizarCompra();

           
            Assert.True(resultado);
            Assert.True(auditLogSpy.LogFinalizacaoChamada); 
        }

        [Fact]
        public void FinalizarCompra_DeveLimparCarrinhoApósFinalização()
        {
            var auditLogSpy = new AuditLogSpy();
            var carrinho = new CarrinhoDeCompras(auditLogSpy);
            var produto = new Produto("Camiseta", 29.90m);
            carrinho.AdicionarProduto(produto);

   
            carrinho.FinalizarCompra();

    
            Assert.Equal(0, carrinho.CalcularTotal());
            Assert.True(auditLogSpy.LogFinalizacaoChamada); 
        }
    }

}