<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="Onfinit.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Onfinit</title>

    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link href="Css/estiloLogin.css" rel="stylesheet" />
    <script src="Scripts/jquery-3.6.0.min.js"></script>
    <script src="Mostrar.js"></script>


    <link rel="preconnect" href="https://fonts.googleapis.com" />
    <link rel="preconnect" href="https://fonts.gstatic.com" />
    <link href="https://fonts.googleapis.com/css2?family=Kaushan+Script&display=swap" rel="stylesheet" />



    <link rel="preconnect" href="https://fonts.googleapis.com" />
    <link rel="preconnect" href="https://fonts.gstatic.com" />
    <link href="https://fonts.googleapis.com/css2?family=Mulish:ital,wght@1,900&family=Roboto&display=swap" rel="stylesheet" />

    <script type="text/javascript">

        $(function () {
            $("[id*=txtEmail], [id*=txtSenha]").WaterMark();
        });
    </script>

</head>
<body class="inicio">
    <form id="frmLogin" runat="server" class="container">

        <header class="cabecalho">
            <div class="center">
                <nav>
                    <h1>Onfinit</h1>
                </nav>
            </div>
        </header>
        <main class="meio">
            <div class="main--container">
                <div class="main--description">
                   <div class="fadeIn first">
                <img src="img/Onfinit.sem.fundo.png" class="logoimg" id="icon"/>
                        </div>

                    <p>Seja Bem Vindo! A Onfinit tem como propósito proporcionar um relacionamento entre pais/tutores e filhos em um ambiente de aprendizagem, visando o bom comportamento e educação financeira sem perder a diversão.</p>
                </div>

                <div class="main--login">
                    <div class="main--card">
                        <!-- Alert -->
                        <asp:Panel ID="panelLogin" runat="server">
                            <div class="alert alert-danger" role="alert">
                                <asp:Label Text="" ID="lblMensagemErro" runat="server" />
                                 <asp:Label Text="" ID="lblMensagemLogin" runat="server" />
                            </div>
                        </asp:Panel>

                        <asp:TextBox ID="txtEmail" runat="server" class="fadeIn second" placeholder="Digite seu email" />


                        <asp:TextBox ID="txtSenha" runat="server" placeholder="Digite sua senha" TextMode="Password" />


                        <asp:Button ID="Login" runat="server" class="btn btn-primary" Text="Entrar" OnClick="Login_Click" />

                        <div class="main--link">
                        <!--    <a href="#">Esqueceu a senha?</a> -->
                        </div>

                        <hr />
                        <br />

                        <div class="main--btn">
                            <a href="cadastro.aspx">Criar nova conta</a>
                        </div>



                    </div>

                </div>


            </div>
        </main>





    </form>

    <script src="jQuery/Content/Scripts/jquery-3.5.1.min.js"></script>
    <script src="js/bootstrap.bundle.min.js"></script>

</body>
</html>
