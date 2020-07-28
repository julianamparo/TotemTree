using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TotemTree.BLL;
using TotemTree.Entities;

namespace TotemTree.Views.View_2
{
    public partial class RecuperarSenhaUser : System.Web.UI.Page
    {
        UsuarioBO usuarioBO;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            var email = String.Format("{0}", Request.Form["txtemail"]);
            usuarioBO = new UsuarioBO();
            Usuario usuario = usuarioBO.verificaEmailExistente(email);
            if (usuario != null)
            {
                usuario = usuarioBO.buscarUsuario(usuario.idUsuario);
                string pw = enviarEmail(email);
                usuario.senha = pw;
                usuarioBO.updateUsuario(usuario);
            }
            else
            {
                this.ExibirAlerta(Mensagem.TipoMensagem.Alerta, "E-mail não cadastrado");
            }

        }

        string enviarEmail(string email)
        {
            string password = RandomString(8, true);
            System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient();
            client.Host = "smtp.gmail.com";
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            string url = "http://localhost:50965/TelaLogin.aspx";
            client.Credentials = new System.Net.NetworkCredential("juuuzinha89@gmail.com", "burger01");
            MailMessage mail = new MailMessage();
            mail.Sender = new System.Net.Mail.MailAddress("juuuzinha89@gmail.com", "TotemTree");
            mail.From = new MailAddress("juuuzinha89@gmail.com", "TotemTree");
            mail.To.Add(new MailAddress(email, "RECEBEDOR"));
            mail.Subject = "TotemTree - Recuperação de senha";
            mail.Body = "<table align = 'center' border = '0' cellpadding = '0' cellspacing = '0' style = 'width:650px;' >" +
            "<tbody>" +
            "     <tr>" +
            "<td align = 'center' colspan = '2' valign = 'top'><img alt = '' border = '0' src = 'https://i.ibb.co/hF7X83m/logo-Menor.png' style = 'display: block;'/></td>" +
             "</tr>" +
             "<td><br/></td>" +
             "<tr> " +
             "<td style = 'width:350px;font-family: arial;font-weight: bold;font-size:25px;color: #000000;text-align: center;padding-bottom:15px' > Perdeu a sua senha? </td> " +
             "</tr>" +
             " <td><br/></td>" +
             "<tr>" +
             "<td style = 'width:350px;font-family: arial;font-size:18px;color: #000000;text-align: center;line-height:18px;padding-bottom:15px; line-height:25px' > Sua senha foi redefinida para <b> " + password + "</b>. Para alterá-la, basta acessar a área de configurações de sua página.</td>" +
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
             "<tr><td style = 'font-family: arial;font-size:18px;color: #fff; background-color: #e67e22; text-align: center;line-height:13px; height:35px;width:180px;'> Acessar </td></tr>" +
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
                this.ExibirAlerta(Mensagem.TipoMensagem.Sucesso, "Email enviado ao usuário");
            }
            catch (System.Exception erro)
            {
                Mensagem.ExibirAlerta(this, Mensagem.TipoMensagem.Erro, "Problemas no servidor de e-mail. E-mail não enviado");
            }
            finally
            {
                mail = null;
            }
            return password;

        }

        public string RandomString(int size, bool lowerCase)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            if (lowerCase)
                return builder.ToString().ToLower();
            return builder.ToString();
        }

    }
}