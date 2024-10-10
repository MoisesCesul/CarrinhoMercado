using CarrinhoMercado;

namespace CarrinhoTeste
{
    public class CarrinhoDeComprasTests
    {
        [Fact]

        //Teste de verificação se carrinho esta vazio, e o spy deve retorna false
        public void FinalizarCompra_CarrinhoVazio_DeveRetornarFalso()
        {
            //instancia Classe SPY
            var auditLogSpy = new AuditLogSpy();
              //instancia Classe Carrinho de comprsas
            var carrinho = new CarrinhoDeCompras(auditLogSpy);

              //Finaliza compra com produtos vazios
            var resultado = carrinho.FinalizarCompra();
              //Verificação do esperado
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
        public void FinalizarCompra_DeveLimparCarrinhoAp�sFinaliza��o()
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