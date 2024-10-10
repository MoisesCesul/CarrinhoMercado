using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrinhoMercado
{
    public class AuditLogSpy
    {
        public bool LogFinalizacaoChamada { get; private set; }

        //metodo de finalização
        public void LogFinalizacao()
        {
            LogFinalizacaoChamada = true;
        }
        //metodo de Resetar
        public void Reset()
        {
            LogFinalizacaoChamada = false;
        }
    }

}
