<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Prancheta.aspx.cs" Inherits="TotemTree.Prancheta" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<!DOCTYPE html>
<!--
Copyright (c) 2003-2019, CKSource - Frederico Knabben. All rights reserved.
For licensing, see LICENSE.md or https://ckeditor.com/legal/ckeditor-oss-license
-->

<html xmlns="http://www.w3.org/1999/xhtml">




<head runat="server">
    <meta charset="utf-8"/>
	<meta name="viewport" content="width-device-widht initial-scale=1"/>
    <script src="../ckeditor/ckeditor.js"></script>
    <script src="../ckeditor/samples/js/sample.js"></script>
	<!--Estilos CSS-->
	<link rel="shortcut icon" href="../Imagens/favicon.png"/>
	<link rel="stylesheet" type="text/css" href="../CSS/telasPrancheta1.css"/>

	<title>Prancheta</title>

    <script>
        function GetSelectedNodeVal() {
           
            var z = prompt("Nome do novo tema: ");
            document.getElementById('novoTemaHidden').value = z;
            document.forms(0).submit();
        }

        
    </script>

   

   
</head>

<body id="main">

    
<form id="form1" runat="server">

    <header>
		<div class="barra">
		   <nav>
			   <ul>
				   <li id="nome"><asp:Label runat="server" ID="lblNomeUser"></asp:Label></li>
			        <input type="hidden" id="hiddenUser" runat="server" value="" />
                   <li id="icone1"><a href="../AlterarCadastro.aspx"><img src="../Imagens/engrenagem.png" title="Configurações"/></a></li>
				   <li id="icone3"><a href="../TelaLogin.aspx"><img src="../Imagens/home.png" title="Logout"/></a></li>				
                   </ul>
		   </nav>
           
	   </div>
   </header>
   <!--Gerador de temas: título-->
   <section class="gerador">
     <div class="divBusca">
         
         <asp:TextBox runat="server" ID="txtBusca" ></asp:TextBox>
         <asp:ImageButton runat="server" CssClass="btnBusca" OnClick="Unnamed_Click" ImageUrl="~/Imagens/lupa.png"/>
    </div>
	</section>

	<!--Fundo árvore-->
	<section class="arvore">
		<div id="arvore" class="temaArvore">
            
                <asp:Panel ID="pnlBotoes" CssClass="panelButtons" runat="server">
                    <asp:ImageButton ID="imgMindMap" runat="server" CssClass="acaoPainel" ImageUrl="~/Imagens/expand.png" ToolTip="Visualizar Mapa" OnClick="imgMindMap_Click" />
                    <asp:ImageButton ID="imgNovo" runat="server" OnClientClick="GetSelectedNodeVal()" CssClass="acaoPainel" ImageUrl="~/Imagens/nota2.png" ToolTip="Novo Tema" OnClick="imgNovo_Click" />
                    <asp:ImageButton ID="imgSalvar" runat="server"  CssClass="acaoPainel" ImageUrl="~/Imagens/save2.png" ToolTip="Salvar Tema" OnClick="imgSalvar_Click" />                    
                    <asp:ImageButton ID="imgDeletar" runat="server" CssClass="acaoPainel" ImageUrl="~/Imagens/lixo2.png" ToolTip="Remover Tema" OnClientClick="return confirm('Deseja remover este tema e todos os que estão contidos nele?')" OnClick="imgDeletar_Click"/>

                </asp:Panel>
             
            <div id="quadro" class="quadroArvore">
                <input type="hidden" id="novoTemaHidden" runat="server" value="" />
            <asp:TreeView  runat="server"  SelectedNodeStyle-CssClass="selectedNode" NodeStyle-CssClass="tvUsuario_0" ID="tvUsuario" OnSelectedNodeChanged="tvUsuario_SelectedNodeChanged">
            </asp:TreeView>   
               
                </div>
		</div>
	</section>

	<!--Anúncios-->
	<section class="anuncio">
		<div id="anuncio"><img src="../Imagens/anuncio.png"/></div>
	</section>

	<!--Prancheta-->
        <div class="prancheta">
            <main>
                 <div class="grid-container">
                <div class="editorStyle">
                 <CKEditor:CKEditorControl ID="ckEditor"  BasePath="/ckeditor/" runat="server" BackColor="Black"></CKEditor:CKEditorControl>
                    </div>    
                   </div>   
                <%--    <div class="adjoined-bottom">
                    <div class="grid-container">
                        <div class="grid-width-100" id="printable">                                
                         <div id="editor">      
                             <CKEditor:CKEditorControl ID="ckEditor" BasePath="/ckeditor/" runat="server" BackColor="Black"></CKEditor:CKEditorControl>
                                                      
                              <asp:TextBox ID="descriptionTextBox" runat="server" TextMode="MultiLine"></asp:TextBox>
                                  <script type="text/javascript" lang="javascript">CKEDITOR.replace('<%=descriptionTextBox.ClientID%>');</script>     
                       

                         </div>
                        </div>
                    </div>
                </div>  --%>   
            </main>
        </div>
    </form>
<!--Inicializador JS-->
<script>
	initSample();
</script>

<!--Rodapé-->
<footer>
    <div class="rodape"></div>
</footer>

    <%--
    <div>
    
    </div>
    --%>
</body>
</html>
