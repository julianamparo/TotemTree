using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TotemTree.BLL;
using TotemTree.Models;

namespace TotemTree.Views
{
    public partial class ConfirmarEmail : System.Web.UI.Page
    {
        UsuarioBO usuarioBO = new UsuarioBO();
        protected void Page_Load(object sender, EventArgs e)
        {
            int userId = Convert.ToInt32(Request.QueryString["MyU"]);
            usuarioBO.ativarUsuario(userId);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/TelaLogin.aspx");
        }
    }
}