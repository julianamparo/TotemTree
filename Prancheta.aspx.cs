using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TotemTree.BLL;
using TotemTree.Entities;
using TotemTree.Views;

namespace TotemTree
{
    public partial class Prancheta : System.Web.UI.Page
    {
        ConteudoBO conteudoBO = new ConteudoBO();
        TemaBO temaBO = new TemaBO();
        UsuarioBO usuarioBO = new UsuarioBO();
        int userId;
        protected void Page_Load(object sender, EventArgs e)
        {           
            pnlBotoes.Visible = false;
           
            if (!IsPostBack)
            {
                var usuarioLogado = "1";
                usuarioLogado = Session["usuarioLogado"].ToString();
                hiddenUser.Value = usuarioLogado.ToString();
                userId = Convert.ToInt32(usuarioLogado);
                Usuario u = usuarioBO.buscarUsuario(userId);

                string[] nome = u.nomeCompleto.Split(' ');
                if (nome[0].Length > 12)
                {
                    nome[0] = nome[0].Substring(0, 12);
                }
                lblNomeUser.Text = "Olá, " + nome[0];
                criarTree();
            }
            
        }

        private void criarTree()
        {
            tvUsuario.Nodes.Clear();
            userId = Convert.ToInt32(hiddenUser.Value);
            Usuario u = usuarioBO.buscarUsuario(userId);
            carregarTemasPrincipais(u);
            tvUsuario.ExpandAll();
        }

        void carregarTemasPrincipais(Usuario u)
        {
          
            ArrayList listaTemas = new ArrayList();
            //montando os Pais
            listaTemas = temaBO.buscarTemasUsuario(u, 0);

            foreach (Tema tema in listaTemas)
            {
                TreeNode node = new TreeNode();
                node.Text = tema.titulo;
                node.Value = tema.idTema.ToString();
                node.ImageUrl = "~/Imagens/tema.png";
                if (tema.titulo == "TotemTree" && tema.idTemaPai == 0)
                    node.ImageUrl = "~/Imagens/logo24px.png";
                tvUsuario.Nodes.Add(node);
                carregarTemasUsuario(tema.idTema, node, u);
            }
        }
        
        void carregarTemasUsuario(int idTemaPai, TreeNode nodePai, Usuario u)
        {
            ArrayList listaTemas = new ArrayList();

            listaTemas = temaBO.buscarTemasUsuario(u, idTemaPai);

            foreach (Tema tema in listaTemas)
            {
                TreeNode node = new TreeNode();
                node.Value = tema.idTema.ToString();
                node.Text = tema.titulo;
                node.ImageUrl = "~/Imagens/tema.png";
                
                nodePai.ChildNodes.Add(node);
                carregarTemasUsuario(tema.idTema, node, u);

            }
        }

        protected void tvUsuario_SelectedNodeChanged(object sender, EventArgs e)
        {
            
            TreeNode node = tvUsuario.SelectedNode;
            pnlBotoes.Visible = true;
            imgDeletar.ToolTip = "Remover Tema";
            imgDeletar.Enabled = true;
             ckEditor.Text = conteudoBO.buscarConteudo(Convert.ToInt32(node.Value)).conteudo;
            if (node == tvUsuario.Nodes[0])
            {
                imgDeletar.Enabled = false;
                imgDeletar.ToolTip = "Não é possível remover o nó principal";
            }
            
        }

        protected void imgNovo_Click(object sender, ImageClickEventArgs e)
        {
            TreeNode node = tvUsuario.SelectedNode;
            int idTema = Convert.ToInt32(node.Value);
            Tema tema = new Tema();
            tema.titulo = novoTemaHidden.Value;
            tema.idTemaPai = idTema;
            userId = Convert.ToInt32(hiddenUser.Value);
            tema.idUsuario = userId;
            temaBO.inserirTema(tema);

            
            criarTree();

        }

        protected void imgSalvar_Click(object sender, ImageClickEventArgs e)
        {
            TreeNode node = tvUsuario.SelectedNode;
            var texto = ckEditor.Text;

            int idTema = Convert.ToInt32(node.Value);
            Conteudo novoConteudo = new Conteudo();
            novoConteudo.idTema = idTema;
            novoConteudo.conteudo = texto;

            conteudoBO.updateConteudo(novoConteudo);

        }

        protected void imgDeletar_Click(object sender, ImageClickEventArgs e)
        {            
            TreeNode node = tvUsuario.SelectedNode;
           
                int idTema = Convert.ToInt32(node.Value);
                conteudoBO.deletarConteudo(idTema);
                temaBO.deletarTema(idTema);
              
                criarTree();
            
        }

        protected void Unnamed_Click(object sender, ImageClickEventArgs e)
        {
            criarTree();
            if (!string.IsNullOrWhiteSpace(txtBusca.Text))
            {
                string trecho = RemoveAccents(txtBusca.Text);
                tvUsuario.CollapseAll();
                TreeNode totemTree = tvUsuario.Nodes[0];
                buscar(totemTree, trecho);
            }
            

        }

        void buscar(TreeNode nodePai, string trecho)
        {
            foreach (TreeNode node in nodePai.ChildNodes)
            {
                var nodeText = RemoveAccents(node.Text);
                if (nodeText.ToLower().Contains(trecho.ToLower()))
                {
                    openParents(node);
                    node.Text = "<span style='background-color:yellow'>" + node.Text + "</span>";
                }
                else {
                    node.Text = "<span style='background-color:#e1e1e1'>" + node.Text + "</span>";
                }
                if (node.ChildNodes.Count > 0)
                {
                    buscar(node, trecho);
                }

            }
        }

        void openParents (TreeNode node)
        {
            if (node.Parent != null)
            {
                node.Parent.Expand();
                openParents(node.Parent);
            }
            
        }
        string RemoveAccents(string text)
        {
            StringBuilder sbReturn = new StringBuilder();
            var arrayText = text.Normalize(NormalizationForm.FormD).ToCharArray();
            foreach (char letter in arrayText)
            {
                if (CharUnicodeInfo.GetUnicodeCategory(letter) != UnicodeCategory.NonSpacingMark)
                    sbReturn.Append(letter);
            }
            return sbReturn.ToString();
        }


        protected void imgMindMap_Click(object sender, ImageClickEventArgs e)
        {

            string queryString = "MindMap.aspx?Tema=" + tvUsuario.SelectedNode.Value;
            string newWin = "window.open('" + queryString + "');";
            ClientScript.RegisterStartupScript(this.GetType(), "pop", newWin, true);
        }

     
    }
}