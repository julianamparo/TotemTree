using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TotemTree.BLL;
using TotemTree.Entities;
using TotemTree.Views;

namespace TotemTree
{
    public partial class AlterarCadastro : System.Web.UI.Page
    {
        UsuarioBO usuarioBO = new UsuarioBO();
        protected void Page_Load(object sender, EventArgs e)
        {
            carregarDadosUsuario();
        }

        private void carregarDadosUsuario()
        {
            var usuarioLogado = Session["usuarioLogado"];
            int userId = Convert.ToInt32(usuarioLogado);

            Usuario u = usuarioBO.buscarUsuario(userId);

            txtNome.Text = u.nomeCompleto;
            txtEmail.Text = u.email;
            txtEmail2.Text = u.email;
            txtSenha.Text = u.senha;
            txtSenha2.Text = u.senha;
        }

        protected void alterar_Click(object sender, EventArgs e)
        {
            var usuarioLogado = Session["usuarioLogado"];
            int userId = Convert.ToInt32(usuarioLogado);

            Usuario usuario = usuarioBO.buscarUsuario(userId);
            var txtnome = String.Format("{0}", Request.Form["txtNome"]);
            var txtemail = String.Format("{0}", Request.Form["txtEmail"]);
            var txtemail2 = String.Format("{0}", Request.Form["txtEmail2"]);
            var txtsenha = String.Format("{0}", Request.Form["txtSenha"]);
            var txtsenha2 = String.Format("{0}", Request.Form["txtSenha2"]);

            int erroValidacao = Validacoes(txtemail, txtemail2, txtsenha, txtsenha2);

            if (erroValidacao == 0)
            {
                usuario.nomeCompleto = txtnome;
                usuario.email = txtemail;
                usuario.senha = txtsenha;

                usuarioBO.updateUsuario(usuario);
                this.ExibirAlerta(Mensagem.TipoMensagem.Sucesso, "Dados alterados");
                carregarDadosUsuario();
            }

            if (erroValidacao == 1)
            {
                this.ExibirAlerta(Mensagem.TipoMensagem.Erro, "Os e-mails não coincidem");

            }
            if (erroValidacao == 2)
            {
                this.ExibirAlerta(Mensagem.TipoMensagem.Erro, "As senhas não coincidem");
            }

        }

        protected void prancheta_Click(object sender, EventArgs e)
        {

            Response.Redirect("~/Prancheta.aspx");

        }

        private int Validacoes(string txtemail, string txtemail2, string txtsenha, string txtsenha2)
        {
            if (!txtemail.Equals(txtemail2))
                return 1;

            if (!txtsenha.Equals(txtsenha2))
                return 2;

            return 0;
        }

        protected void excluir_Click1(object sender, EventArgs e)
        {
            var usuarioLogado = Session["usuarioLogado"];
            int userId = Convert.ToInt32(usuarioLogado);

            Usuario u = usuarioBO.buscarUsuario(userId);

            usuarioBO.deletarUsuario(u);

            Response.Redirect("contaExcluida.html");
        }
    }
}