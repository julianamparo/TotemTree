using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TotemTree.Models;
using System.IO;
using TotemTree.Entities;
using TotemTree.Views;
using TotemTree.BLL;
using System.Web.Security;

namespace TotemTree
{
    public partial class TelaLogin : System.Web.UI.Page
    {

        UsuarioBO usuarioBO = new UsuarioBO();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {

            Usuario usuario = new Usuario();
            var email = String.Format("{0}", Request.Form["txtEmail"]);
            var senha = String.Format("{0}", Request.Form["txtSenha"]);

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(senha))
            {
                this.ExibirAlerta(Mensagem.TipoMensagem.Alerta, "Usuário e/ou senha não informado");
            }
            else
            {
                Usuario u = null;
                u = usuarioBO.autenticarUsuario(email, senha);
                if (u.idUsuario != 0)
                {
                    Session["usuarioLogado"] = u.idUsuario;
                    Response.Redirect("~/Prancheta.aspx");
                }
                else
                {
                    this.ExibirAlerta(Mensagem.TipoMensagem.Alerta, "Usuário não existe/está inativo");
                }


            }


        }

    
    }
}