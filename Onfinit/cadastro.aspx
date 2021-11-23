<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="cadastro.aspx.cs" Inherits="Onfinit.cadastro" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Cadastro</title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />

    <link href="Css/fontawesome-free.css" rel="stylesheet" />
    <link href="https://fonts.googleapis.com/css?family=Nunito:200,200i,300,300i,400,400i,600,600i,700,700i,800,800i,900,900i"
        rel="stylesheet" />
    <link href="Css/sb-admin-2.min.css" rel="stylesheet" />


</head>
<body class="bg-gradient-primary">
    <form id="form1" runat="server">



        <div class="container">

            <div class="card o-hidden border-0 shadow-lg my-5">
                <div class="card-body p-0">
                    <!-- Nested Row within Card Body -->
                    <div class="row">
                        <div class="col-lg-5 d-none d-lg-block bg-register-image"></div>
                        <div class="col-lg-7">
                            <div class="p-5">
                                <div class="text-center">
                                    <h1 class="h4 text-gray-900 mb-4">Crie sua conta!!</h1>
                                </div>
                              
                                    <asp:Label Text="" ID="lblMensagemErro" runat="server" ForeColor="Red" />
                            
                                <div class="form-group row">
                                    <div class="col-sm-6 mb-3 mb-sm-0">


                                        <asp:TextBox ID="txtNome" runat="server" class="form-control form-control-user" placeholder="Digite seu Nome" />

                                    </div>
                                    <div class="col-sm-6">
                                        <asp:TextBox ID="txtSobrenome" runat="server" class="form-control form-control-user" placeholder="Digite seu Sobrenome" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <asp:TextBox ID="txtEmail" runat="server" class="form-control form-control-user" placeholder="Digite seu email" />

                                </div>
                                <div class="form-group row">
                                    <div class="col-sm-6 mb-3 mb-sm-0">
                                        <asp:TextBox ID="txtSenha" runat="server" class="form-control form-control-user" TextMode="Password" placeholder="Digite sua Senha" />
                                    </div>

                                    <div class="col-sm-6 mb-3 mb-sm-0">
                                        <asp:TextBox ID="txtPassword" runat="server" class="form-control form-control-user" TextMode="Password" placeholder="Digite sua Senha novamente" />
                                    </div>

                                </div>
                                <asp:Button ID="btnBotaocad" runat="server" class="btn btn-primary btn-user btn-block" Text="Cadastrar" OnClick="btnBotaocad_Click" />




                                <asp:Label Text="" ID="lblUsuario" runat="server" ForeColor="Green" />

                                <br />

                                <div class="text-center">
                                    <a class="small" href="login.aspx">Entrar!!!!</a>
                                </div>
                                
                            </div>
                        </div>
                    </div>
                </div>
            </div>

        </div>


    </form>
</body>
</html>
