<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TelaLogin.aspx.cs" Inherits="TotemTree.TelaLogin" %>
<!--
    Projeto TCC Totem Tree
    @Dev Frontend Fernanda Carolina Aguilera Abarca
    @Dev Backend Gilberto Shimokawa Falcão e Juliana Amaparo
    @Data   18/02/2018
-->
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <!--Referencias para navegadores-->
        <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
        <meta name="description" content="Totem Tree: Sua árvore de conhecimento"/>
		<meta name="keyword" content="mapa-mental, editor de texto"/>
        <meta name="viewport" content="width-device-widht initial-scale=1"/>
       
        <!--CSS e favicon-->
        <link rel="shortcut icon" href="Imagens/favicon.png"/>
        <link rel="stylesheet" type="text/css" href="CSS/telasLogin.css">

        <!--Imagem de fundo-->
        <style>body{background-image: url(Imagens/bkImage.jpg);}</style>

        <!--Mostra Senha-->
    	<script>
			function mostrarSenha(){
				var tipo = document.getElementById("senha");
				if(tipo.type == "password"){
					tipo.type = "text";
				}else{
					tipo.type = "password";
				}
			}
        </script>
        
        <title>Totem Tree</title>
</head>
<body>

     <!--Cabeçalho-->
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
            <img src="Imagens/logoMenor.png"/>
        </div>
          
        <!--Login-->
        <form id="form1" class="tela" runat="server">
        
         <label for="login">login</label>
         <input type="email" name="txtEmail" placeholder="entre com o seu e-mail" title="o email deve conter @" />
         <label for="senha">senha</label>
         <input type="password" name="txtSenha" placeholder="entre com a senha" pattern="^.{6,20}" title="sua senha deve ter entre 6 e 20 carcteres" id="senha"/>

        <%--<VER SENHA>--%>
        <input type="button" ID="verSenha" onclick="mostrarSenha()"/>
                    

         <%--<button type="button" onclick="window.location='prancheta.html'">Continuar</button>--%>
        <asp:Button ID="btnLogin" Text="Entrar" runat="server" OnClick="btnLogin_Click"/>

         <p id="cadastro"><a href="../Cadastro.aspx">- Cadastre-se</a></p>
         <p id="esqueci"><a href="../RecuperarSenhaUser.aspx">- Esqueci minha senha/login</a></p>

   <%-- <div>   
         Email:
         <asp:TextBox ID="txtEmail" placeholder="entre com o login" runat="server"></asp:TextBox>
         Senha:
         <asp:TextBox ID="txtSenha"   TextMode="Password"  placeholder="entre com a senha" runat="server"></asp:TextBox>
    </div>

        <div>
            <asp:Button ID="btnLogin" Text="Entrar" runat="server" OnClick="AutenticaUsuario"/>
            <p id="esqueci"><a href="#">- Esqueci minha senha/login</a></p>
            <p id="cadastro"><a href="#">- Cadastro</a></p>
            <p id="incorreto"> <asp:Label ID="lblRetorno" runat="server"></asp:Label></p>
        </div>--%>
     
        </form>

         <!--Rodapé-->
            <footer>
            <div class="rodape">TTT 2019:&nbsp; F. Abarca - G. Shimokawa - J. Amparo</div>
        </footer>
</body>
</html>
    