using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace TotemTree.Views
{
    public static class Mensagem
    {
        public enum TipoMensagem
        {
            Alerta  = 1,
            Sucesso = 2,
            Erro    = 3
        }

        public static void ExibirAlerta(this System.Web.UI.Page page, TipoMensagem tipo, string texto)
        {
            switch (tipo)
            {
                case Mensagem.TipoMensagem.Alerta:
                    texto = "Atenção! \\n\\n" + texto;
                    break;
                case Mensagem.TipoMensagem.Erro:
                    texto = "Erro! \\n\\n" + texto;
                    break;
                case Mensagem.TipoMensagem.Sucesso:
                    texto = "Sucesso! \\n\\n" + texto;
                    break;
            }

            string script = "alert('" + texto + "');";
            ScriptManager.RegisterClientScriptBlock(page, page.GetType(), "Alert", script, true);
        }
    }
}