using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TotemTree.BLL;
using TotemTree.Entities;
using TotemTree.Models;
using TotemTree.Views;

namespace TotemTree
{
    public partial class Cadastro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void CadastraUsuario(object sender, EventArgs e)
        {
            var ckbconcordo = String.Format("{0}", Request.Form["ckbconcordo"]);
            if (ckbconcordo == "1") { 
                Usuario usuario = new Usuario();

                var txtnome = String.Format("{0}", Request.Form["txtnome"]);
                var txtemail = String.Format("{0}", Request.Form["txtemail"]);
                var txtemail2 = String.Format("{0}", Request.Form["txtemail2"]);
                var txtsenha = String.Format("{0}", Request.Form["txtsenha"]);
                var txtsenha2 = String.Format("{0}", Request.Form["txtsenha2"]);
                var selgenero = String.Format("{0}", Request.Form["selgenero"]);
                var txtnascimento = String.Format("{0}", Request.Form["txtnascimento"]);
                        
                int erroValidacao = Validacoes(txtemail, txtemail2, txtsenha, txtsenha2);

                if (erroValidacao == 0)
                {
                    usuario.nomeCompleto = txtnome;
                    usuario.email = txtemail;
                    usuario.senha = txtsenha;
                    usuario.dataNascimento = Convert.ToDateTime(txtnascimento);
                    if (selgenero == "Masculino")
                        usuario.genero = "M";
                    if (selgenero == "Feminino")
                        usuario.genero = "F";
                    if (selgenero == "Outro")
                        usuario.genero = "O";

                    usuario.statusPerfil = true;
                    usuario.dataRegistro = DateTime.Now;
                    UsuarioBO usuarioBO = new UsuarioBO();
                    int id = usuarioBO.inserirUsuario(usuario);
                    
                    enviarEmail(usuario.email, id);
                    criarTemaPai(id);
                    Response.Redirect("welcome.html");

                }
                
                if (erroValidacao == 1)
                {
                    this.ExibirAlerta(Mensagem.TipoMensagem.Erro, "Os e-mails não coincidem");
                    
                }
                if (erroValidacao == 2)
                {
                    this.ExibirAlerta(Mensagem.TipoMensagem.Erro, "As senhas não coincidem");
                }
                if (erroValidacao == 3)
                {
                    this.ExibirAlerta(Mensagem.TipoMensagem.Erro, "Email já está cadastrado.");
                }
            }
            else
            {
                this.ExibirAlerta(Mensagem.TipoMensagem.Alerta, "É necessário aceitar os termos de uso.");
                
            }
        }

        private int Validacoes(string txtemail, string txtemail2, string txtsenha, string txtsenha2)
        {
            if (!txtemail.Equals(txtemail2))
                return 1;

            if (!txtsenha.Equals(txtsenha2))
                return 2;
            UsuarioBO usuarioBO = new UsuarioBO();
            Usuario u = null;
            u = usuarioBO.verificaEmailExistente(txtemail);

            if (u != null)
                return 3;

            return 0;
        }

        void criarTemaPai(int userId)
        {
            TemaBO temaBO = new TemaBO();
            Tema tema = new Tema();
            tema.titulo = "TotemTree";
            tema.idTemaPai = 0;
            tema.sequencia = 1;
            tema.idUsuario = userId;
            temaBO.inserirTema(tema);
        }

      void enviarEmail (string email, int idUser)
        {
            System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient();
            LinkButton link = new LinkButton();
            link.Text = "Validar Cadastro";
            link.PostBackUrl = "~/ConfirmarEmail.aspx";
            client.Host = "smtp.gmail.com";
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential("juuuzinha89@gmail.com", "burger01");
            MailMessage mail = new MailMessage();
            mail.Sender = new System.Net.Mail.MailAddress("juuuzinha89@gmail.com", "TotemTree");
            mail.From = new MailAddress("juuuzinha89@gmail.com", "TotemTree");
            mail.To.Add(new MailAddress(email, "RECEBEDOR"));
            mail.Subject = "TotemTree - Cadastro Efetuado";
            string url = "http://localhost:50965/ConfirmarEmail.aspx?MyU=" + idUser;
            mail.Body = " Mensagem do site:<br/> Olá! Bem vindo ao TotemTree! <br/> Para concluir o seu cadastro, por gentileza clique neste link de redirecionamento ao site: <a href=\'" + url + "'>Login</a> ";



            mail.Body = "<table align = 'center' border = '0' cellpadding = '0' cellspacing = '0' style = 'width:650px;' >" +
            "<tbody>" +
            "     <tr>" +
            "<td align = 'center' colspan = '2' valign = 'top'><img alt = '' border = '0' src = 'https://i.ibb.co/hF7X83m/logo-Menor.png' style = 'display: block;'/></td>" +
             "</tr>" +
             "<td><br/></td>" +
             "<tr> " +
             " <td style='width: 350px; font - family: arial; font - weight: bold; font - size:25px; color: #000000;text-align: center;padding-bottom:15px'>Seja bem vindo ao Totem Tree</td>" +
             "</tr>" +
             " <td><br/></td>" +
             "<tr>" +
             "<td style='width: 350px; font - family: arial; font - size:18px; color: #000000;text-align: center;line-height:18px;padding-bottom:15px; line-height:25px'>Agora você já pode organizar melhor os seus estudos!<br/>Para a efetivação do seu cadastro, por favor, acesse o link abaixo:</td>" +
             "</tr>" +
             "<td><br/></td>" +
             "</tbody>" +
             "</table>" +
             "<table align = 'center' border = '0' cellpadding = '0' cellspacing = '0' style = 'width:650px;'>" +
             "<tbody>" +
             "<td align = 'center'>" +
             "<a href =' " + url + "' style = 'color: #000000;text-decoration: none;'>" +
             "<table align = 'center' border = '0' cellpadding = '0' cellspacing = '0' style = 'height:35px;width:180px;'>" +
             "<tbody>" +
             "<tr><td style='font - family: arial; font - size:18px; color: #fff; background-color: #e67e22; text-align: center;line-height:13px; height:35px;width:180px;'>Acessar</td></tr>" +
             "</tbody>" +
             "</table>" +
             "</a>" +
             "</td>" +
             "</tbody>" +
             "</table>" +
             "<table align = 'center' border = '0' cellpadding = '0' cellspacing = '0' style = 'width:650px;'>" +
             "<tbody>" +
             "<td><br/></td>" +
             "<tr>" +
             "<td style = 'width:350px;font-family: arial;font-size:18px;color: #000000;text-align: center;line-height:18px;padding-bottom:15px; line-height:25px'> Caso você não tenha solicitado este e-mail,<br/> favor desconsiderar.</td>" +
             "</tr>" +
             "</tbody>" +
             "</table>";

            mail.IsBodyHtml = true;
            mail.Priority = MailPriority.High;
            try
            {
                client.Send(mail);
            }
            catch (System.Exception erro)
            {
                Mensagem.ExibirAlerta(this, Mensagem.TipoMensagem.Erro, "Problemas no servidor de e-mail. E-mail não enviado");
            }
            finally
            {
                mail = null;
            }

        }


    }
}