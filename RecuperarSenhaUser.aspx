<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RecuperarSenhaUser.aspx.cs" Inherits="TotemTree.Views.View_2.RecuperarSenhaUser" %>

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
        <link rel="stylesheet" type="text/css" href="CSS/telasRecuperaSenha.css">

        <!--Imagem de fundo-->
        
        <!--Responsividade -->
        <meta name="viewport" content="width=device-width, initial-scale=1.0 maximum-scale=1">  

        <!--Imagem de fundo-->
        <style>body{background-image: url(Imagens/bkImage.jpg);}</style>
        
        <title>Recuperar senha</title>
</head>
<body>
    <header>
            <div class="cabecalho">
                <nav>
                    <ul>
                        <li><a href="sobre.html">sobre</a></li>
                        <li>|</li>
                        <li><a  href="termos.html">termos de uso</a></li>
                    </ul>
                </nav>
            </div>
        </header>

     <!--Logotipo-->
        <!--Logotipo-->
        <div class="logo">
            <a href="TelaLogin.aspx"><img src="Imagens/logoMenor.png"/></a>
        </div>

    <form id="form1" class="tela" runat="server">
    <div>
    <label for="perdeu" id="perdeu">Perdeu a senha?</label>
                <label for="texto" id="texto">Não se preocupe. Para recuperá-la, informe seu e-mail cadastrado:</label>
                <label for="login" id="login">E-mail</label>
                <input type="email" name="txtemail"  id="txtemail" placeholder="entre com o seu e-mail" title="o email deve conter @" required/>
                
                <asp:Button ID="btnEnviar" OnClick="btnEnviar_Click" Text="Enviar" runat="server" CssClass="enviar" />
                <button type="button" onclick="window.location='TelaLogin.aspx'" id="voltar">Voltar</button> 
   
    </div>
    </form>
    <!--Rodapé-->
        <footer>
            <div class="rodape">TTT 2019:&nbsp; F. Abarca - G. Shimokawa - J. Amparo</div>
        </footer>
</body>
</html>
