<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AlterarCadastro.aspx.cs" Inherits="TotemTree.AlterarCadastro" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>

        <!--Referencias para navegadores-->
        <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>

        <!--CSS e favicon-->
        <link rel="shortcut icon" href="Imagens/favicon.png"/>
        <link rel="stylesheet" type="text/css" href="CSS/telasCadastroAlterar.css">

        <title>Alterar cadastro</title>

     <!--Mostra Senha-->
    	<script>
			function mostrarSenha(){
			    var tipo = document.getElementById("txtSenha");
				if(tipo.type == "password"){
					tipo.type = "text";
				}else{
					tipo.type = "password";
				}
			}
			function mostrarSenha1() {
			    var tipo = document.getElementById("txtSenha2");
			    if (tipo.type == "password") {
			        tipo.type = "text";
			    } else {
			        tipo.type = "password";
			    }
			}
        </script>

        <!--Script do pop-up-->
        <!--<script src="JS/pop-upCadastro.js"></script>-->

    </head>
<body>

      <header>
                <div class="cabecalho">
                    <nav>
                        <ul>
                            <li><a href="sobre.html">sobre</a></li>
                            <li>|</li>
                            <li><a href="termos.html">termos de uso</a></li>
                        </ul>
                    </nav>
                </div>
            </header>


     <!--Logotipo-->
        <div class="logo">
            <img src="Imagens/logo100px.png"/>
        </div>

     <form class="telaCadastro" runat="server" enctype="multipart/form-data">
             <div id="nome">
                <label for="nome">Nome completo*</label>
                 <asp:TextBox runat="server" ID="txtNome" ToolTip="Digite seu nome completo" ></asp:TextBox><br />
                <%--<input type="text" placeholder="Digite aqui para alterar seu nome" title="Digite seu nome completo" required/>--%>
                 
            </div>

            <div id="email">
                <label for="e-mail*">E-mail*</label>
                    <asp:TextBox runat="server" ID="txtEmail" ToolTip="Digite seu e-mail" ></asp:TextBox><br />
            <%-- <input type="email" placeholder="Digite seu e-mail" title="Digite seu e-mail" required/>--%>
            </div>
            
            <div id="email2">
                <label for="confirmaE-mail">Confirme seu e-mail*</label>    
                <asp:TextBox runat="server" ID="txtEmail2" ToolTip="Confirme seu e-mail" ></asp:TextBox><br />
         
               <%-- <input type="email" placeholder="Confirme seu e-mail" title="Confirme seu e-mail" required/></br>
           --%> </div>
            
            <div id="senha">
                <label for="senha">Senha* (use letras e números)</label>
              <asp:TextBox runat="server" ID="txtSenha" TextMode="Password" ToolTip="Entre com a senha" ></asp:TextBox><br />
         <%--  <input type="password" placeholder="Entre com a senha" pattern="^.{6,8}" title="sua senha deve ter entre 6 e 8 carcteres" required/>
          --%>  </div>
            
            <div id="senha2">
                <label for="senha">Confirme sua senha*</label>
                   <asp:TextBox runat="server" ID="txtSenha2" TextMode="Password" ToolTip="Confirme sua senha" ></asp:TextBox><br />
      <%--   <input type="password" placeholder="Confirme sua senha" pattern="^.{6,8}" title="sua senha deve ter entre 6 e 8 carcteres" required/></br>
      --%>      </div>

            <asp:Button ID="alterar" Text="Salvar" runat="server" OnClick="alterar_Click"/>
            <asp:Button ID="prancheta" Text="Voltar" runat="server" OnClick="prancheta_Click"/>
            
              <div class="telaexcluir">
                    <label for="excluir" id="frase">Deseja excluir sua conta? </label>
                <asp:Button runat="server" ID="excluir" OnClientClick="return confirm('Essa ação não pode ser desfeita. Prosseguir?')" OnClick="excluir_Click1" Text="Excluir" /> 
                  
              </div>
                      <div>
             <%--<VER SENHA>--%>
            <input type="button" ID="verSenha" onclick="mostrarSenha()"/>
            <input type="button" ID="verSenha1" onclick="mostrarSenha1()"/>
            </div>
       

        </form>

             
          

        <!--Rodapé-->
        <footer>
            <div class="rodape">TTT 2019:&nbsp; F. Abarca - G. Shimokawa - J. Amparo</div>
        </footer>
    
    </body>

</html>
