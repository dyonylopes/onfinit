<%@ Page Title="" Language="C#" MasterPageFile="~/menu.Master" AutoEventWireup="true" CodeBehind="contas.aspx.cs" Inherits="Onfinit.contas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.2/dist/css/bootstrap.min.css" rel="stylesheet">
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.1.2/dist/js/bootstrap.bundle.min.js"></script>
    <link href="Css/estiloconta.css" rel="stylesheet" />
    <link rel="preconnect" href="https://fonts.googleapis.com">
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
    <link href="https: //fonts.googleapis.com/css2? family = Hind + Siliguri & display = swap " rel=" stylesheet ">


    <header>
        <br />
        <h1>Cadastro de usuário Infantil</h1>
        <br />
    </header>
    <asp:HiddenField ID="idcontas" runat="server" />

    <main class="meio">
        <div class="form-group row">
            <div class="col-12 col-md-8">
                <div class="main--container">
                    <div class="main--conta">
                        <div class="main--card">
                            <asp:Label Text="" ID="lblconta" runat="server" ForeColor="Green" />
                            <asp:Label Text="" ID="lblMensagemErro" runat="server" ForeColor="Red" />
                            <div class="form-group row">
                                <div class="col-sm-6 mb-3 mb-sm-0">


                                    <asp:TextBox ID="txtNome" runat="server" class="form-control form-control-user" placeholder="Digite seu Nome" />

                                </div>
                                <div class="col-sm-6">
                                    <asp:TextBox ID="txtSobrenome" runat="server" class="form-control form-control-user" placeholder="Digite seu Sobrenome" />
                                </div>
                            </div>
                            <br />
                            <div class="form-group">
                                <asp:TextBox ID="txtEmail" runat="server" class="form-control form-control-user" placeholder="Digite seu email" />

                            </div>
                            <br />
                            <div class="form-group row">
                                <div class="col-sm-6 mb-3 mb-sm-0">
                                    <asp:TextBox ID="txtSenha" runat="server" class="form-control form-control-user" TextMode="Password" placeholder="Digite sua Senha" />
                                </div>

                                <div class="col-sm-6 mb-3 mb-sm-0">
                                    <asp:TextBox ID="txtPassword" runat="server" class="form-control form-control-user" TextMode="Password" placeholder="Digite sua Senha novamente" />
                                </div>

                            </div>
                            <br />
                            <div class="btn-group btn-group-lg" role="group">
                                <asp:Button ID="btnBotaocadinf" runat="server"  CssClass="btn btn-outline-success" Text="Cadastrar" OnClick="btnBotaocadinf_Click" />
                                <asp:Button ID="btnEditar" Text="Editar" runat="server" CssClass="btn btn-outline-primary  my-2 my-sm-0" Enabled="False" OnClick="btnEditar_Click" />
                                <asp:Button ID="btnDeletar" Text="Excluir" runat="server" CssClass="btn btn-outline-danger my-2 my-sm-0" Enabled="False" OnClick="btnDeletar_Click" />
                            </div>

                            <br />

                            <asp:Label Text="" ID="lblUsuario" runat="server" ForeColor="Green" />

                        </div>
                    </div>
                </div>
            </div>
        </div>


        <div class="form-group row">
            <div class="col-6 col-md-4">


                <div class="maincontainer">
                    <div class="maininformacao">
                        <div class="maincard">
                            <img class="card-img-top" src="img/perfil.png" alt="Card image" style="width:30%">
                            <div class="card-body">
                            
                                
                             
                                <asp:Label text="Administrador de usuários" runat="server"></asp:Label>
                                <br />
                                <asp:Label text="Nome" ID="lblnome"  runat="server"></asp:Label>
                                
                                <br />
                                <asp:Label text="Sobrenome" ID="lblsobrenome"  runat="server"></asp:Label>
                               
                               
                                
                                <br />
                                 <asp:Label text="Email" ID="lblemail" runat="server"></asp:Label>
                                <br />
                              <br />
                                <br />
                                <br />

                            </div>

                        </div>
                    </div>
                </div>
            </div>
        </div>


       

    </main>


    <br />
    

    <div class="container">
        <div class="gridview">
            <asp:GridView ID="grid" runat="server" CssClass="table table-striped" AutoGenerateColumns="false" OnSelectedIndexChanged="grid_SelectedIndexChanged">
                <Columns>
                    <asp:BoundField DataField="nome" HeaderText="Nome" />
                    <asp:BoundField DataField="sobrenome" HeaderText="Sobrenome" />
                    <asp:BoundField DataField="email" HeaderText="Email" />




                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button ID="btnSelecionar" Text="Selecionar" CssClass="btn btn-outline-danger my-2 my-sm-0" CommandArgument='<%# Eval("id") %>' runat="server" OnClick="btnSelecionar_Click" />
                        </ItemTemplate>

                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>



</asp:Content>
