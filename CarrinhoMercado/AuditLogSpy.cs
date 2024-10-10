using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CarrinhoMercado
{
    public class AuditLogSpy //classe serve "espiar" se uma ação foi realizada.
    {
        public bool LogFinalizacaoChamada { get; private set; } //propriedade Log... tipo boleano
                                                                //que indica se o método LogFinalizacao() foi chamado ou não.
                                                                //tem o private pq so pode ser alterada dentro da propria classe
        public void LogFinalizacao() // criando o metodo
        {
            LogFinalizacaoChamada = true;      // define como true
        }

        public void Reset() // criado metodo reset
        {
            LogFinalizacaoChamada = false; //definida como false para pode resetar o SPY
        }
    }

}