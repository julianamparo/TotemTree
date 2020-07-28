 <%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cadastro.aspx.cs" Inherits="TotemTree.Cadastro" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
 <head>

        <!--Referencias para navegadores-->
        <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>

        <!--CSS e favicon-->
        <link rel="shortcut icon" href="Imagens/favicon.png"/>
        <link rel="stylesheet" type="text/css" href="CSS/telasCadastro.css">

        <title>Cadastre-se</title>
        
     <!--Mostra Senha-->
    	<script>
			function mostrarSenha(){
			    var tipo = document.getElementById("senhaA");
				if(tipo.type == "password"){
					tipo.type = "text";
				}else{
					tipo.type = "password";
				}
			}
			function mostrarSenha1() {
			    var tipo = document.getElementById("senhaB");
			    if (tipo.type == "password") {
			        tipo.type = "text";
			    } else {
			        tipo.type = "password";
			    }
			}
        </script>
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
            <img src="Imagens/logo100px.png"/>
        </div>

         <!--Caixa de Cadastro-->
         <form class="telaCadastro" runat="server" enctype="multipart/form-data">
             <div id="nome">
                <label for="nome">Nome completo*</label>
                <input type="text" name="txtnome" placeholder="Digite seu nome completo" title="Digite seu nome completo" required/></br>
            </div>

            <div id="email">
                <label for="e-mail*">E-mail*</label>
                <input type="email" name="txtemail" id="txtemail" placeholder="Digite seu e-mail" title="Digite seu e-mail" value="" required/>
            </div>
            
            <div id="email2">
                <label for="confirmaE-mail">Confirme seu e-mail*</label>
                <input type="email" name="txtemail2" id="txtemail2" placeholder="Confirme seu e-mail" title="Confirme seu e-mail" required/></br>
            </div>
            
            <div id="senha">
                <label for="senha">Senha* (recomendamos mesclar letras e números)</label>
                <input type="password" id="senhaA" name="txtsenha" placeholder="Entre com a senha" pattern="^.{6,20}" title="sua senha deve ter entre 6 e 8 carcteres" required/>
            </div>
            
            <div id="senha2">
                <label for="senha">Confirme sua senha*</label>
                <input type="password" id="senhaB" name="txtsenha2" placeholder="Confirme sua senha" pattern="^.{6,20}" title="sua senha deve ter entre 6 e 8 carcteres" required/></br>
            </div>

             <div>
                 <%--<VER SENHA>--%>
            <input type="button" ID="verSenha" onclick="mostrarSenha()"/>
            <input type="button" ID="verSenha1" onclick="mostrarSenha1()"/>
             </div>

            
            <div id="genero">
                <label for="genero">Selecione&nbsp;o seu gênero</label>
                    <select title="Selecione o seu gênero" name="selgenero">
                        <option>Masculino</option>
                        <option>Feminino</option>
                        <option>Outro</option>
                    </select>
            </div>
            
            <div id="aniversario">
                <label for="data">Data de nascimento</label>
                <input type="date" name="txtnascimento" id="data"/>
            </div>

            <!--Box "concordo com os termos de uso"-->
            <div id="borda">
                <div id="concordo">
                    <label for="concordo">Concordo com os termos de uso apresentados <a href="termos.html" required>aqui</a>.</label>
                    <input type="checkbox" name="ckbconcordo" id="concordo" value="1"/></br>
                </div>
            </div>

            <button type="button" onclick="window.location='TelaLogin.aspx'" id="cancelar">Cancelar</button>
            <!--<button type="button" onclick="window.location='prancheta.html'" id="continuar">Continuar</button>
            <button id="continuar">Continuar</button>-->
            <asp:Button ID="btnCadastrar" Text="Confirmar" runat="server"  onclick="CadastraUsuario"/>
      
        </form>

        <!--Rodapé-->
        <footer>
            <div class="rodape">TTT 2019:&nbsp; F. Abarca - G. Shimokawa - J. Amparo</div>
        </footer>
    
    </body>

</html>
