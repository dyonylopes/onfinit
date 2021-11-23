<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="infantil.aspx.cs" Inherits="Onfinit.infantil" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Onfinit - Infantil</title>
    <link href="Css/styles.css" rel="stylesheet" />


    <link href="Css/estilogeral.css" rel="stylesheet" />
    <link rel="icon" type="image/x-icon" href="assets/favicon.ico" />
    <!-- Font Awesome icons (free version)-->
    <script src="https://use.fontawesome.com/releases/v5.15.4/js/all.js" crossorigin="anonymous"></script>
    <!-- Google fonts-->
    <link href="https://fonts.googleapis.com/css?family=Montserrat:400,700" rel="stylesheet" type="text/css" />
    <link href="https://fonts.googleapis.com/css?family=Roboto+Slab:400,100,300,700" rel="stylesheet" type="text/css" />
    <!-- Core theme CSS (includes Bootstrap)-->


</head>
<body>
    <form id="form2" runat="server">
        <asp:HiddenField ID="idinfantil" runat="server" />


        <nav class="navbar navbar-expand-lg navbar-dark fixed-top" id="mainNav">
            <div class="container">
                <a class="navbar-brand" href="#page-top">
                    <img src="img/Onfinit.sem.fundo.png" alt="..." /></a>
                <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarResponsive" aria-controls="navbarResponsive" aria-expanded="false" aria-label="Toggle navigation">
                    Menu
                   
                    <i class="fas fa-bars ms-1"></i>
                </button>
                <div class="collapse navbar-collapse" id="navbarResponsive">
                    <ul class="navbar-nav text-uppercase ms-auto py-4 py-lg-0">
                        
                        <li class="nav-item"><a class="nav-link" href="#atividade">Atividades</a></li>
                        <li class="nav-item"><a class="nav-link" href="#recompensas">Recompensas</a></li>

                        <li class="nav-item"><a class="nav-link" href="login.aspx">Sair</a></li>
                    </ul>
                </div>
            </div>
        </nav>
        <br />

        <section class="page-section bg-light" id="pontos">
             <div class="text-center">
                <div class="form-group row">
                    <div class="col-md-12 offset-md-4">
                        <asp:Label Text="Pontos"  runat="server" />
                <asp:TextBox ID="txtpontos" runat="server" class="form-control form-control-user" Enabled="False" style="text-align:right;" />
            </div>
                    </div>
                 </div>
            
            <br />
          
            <div class="text-center">
                <div class="form-group row">
                    <div class="col-sm-12 mb-3 mb-sm-0">
                        <asp:Label Text="" ID="lblatividade" runat="server" ForeColor="Green" />
                        </div>
                    </div>
             </div>
        </section>


        <!--  Grid Atividades-->
        <section class="page-section bg-light" id="atividade">


            <div class="container">
                <div class="text-center">
                    <h2 class="section-heading text-uppercase">Terminar Atividades</h2>
                </div>
            </div>

             
            

            <div class="text-center">
                <div class="form-group row">
                    <div class="col-sm-12 mb-3 mb-sm-0">

                        
                        <asp:TextBox ID="txtAtividade" runat="server" class="form-control form-control-user" Enabled="False" />
                         <asp:TextBox ID="txtponto" runat="server" class="form-control form-control-user" Enabled="False" />

                        <asp:Button ID="btnTerminar" Text="Terminar Tarefa" runat="server" CssClass="btn btn-outline-success my-2 my-sm-0" Enabled="False" OnClick="btnTerminar_Click" />
                        <asp:Button ID="bntCancelar" Text="Cancelar" runat="server" CssClass="btn btn-outline-danger" Enabled="False" OnClick="bntCancelar_Click" />

                    </div>
                </div>
            </div>

            <div class="container">
                <div class="gridview">
                    <asp:GridView ID="grid" runat="server" CssClass="table table-striped" AutoGenerateColumns="false" OnSelectedIndexChanged="grid_SelectedIndexChanged">
                        <Columns>
                            <asp:BoundField DataField="atv_nome" HeaderText="Nome da Atividade" />
                            <asp:BoundField DataField="atv_descricao" HeaderText="Descrição da Atividade" />
                            <asp:BoundField DataField="atv_pontos" HeaderText="Pontuação da atividade" />

                            <asp:TemplateField>
                                <ItemTemplate>

                                    <asp:Button ID="btnSelecionaratv" Text="Selecionar" CssClass="btn btn-outline-danger my-2 my-sm-0" CommandArgument='<%# Eval("id") %>' runat="server" OnClick="btnSelecionaratv_Click" />
                                </ItemTemplate>

                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>



        </section>


        <!--  Grid Recompensas-->
        <section class="page-section bg-light" id="recompensas">
            <div class="container">
                <div class="text-center">
                    <h2 class="section-heading text-uppercase">Escolher Recompensa</h2>
                </div>
            </div>
            <div class="text-center">
                <div class="form-group row">
                    <div class="col-sm-12 mb-3 mb-sm-0">

                       
                        <asp:TextBox ID="txtrec" runat="server" class="form-control form-control-user" Enabled="False" />
                        <asp:TextBox ID="txtrecponto" runat="server" class="form-control form-control-user" Enabled="False" />

                        <asp:Button ID="btnEscolher" Text="Escolher recompensa" runat="server" CssClass="btn btn-outline-success my-2 my-sm-0" Enabled="False" OnClick="btnEscolher_Click" />
                        <asp:Button ID="btnSair" Text="Cancelar" runat="server" CssClass="btn btn-outline-danger" Enabled="False" OnClick="btnSair_Click" />

                    </div>
                </div>
            </div>

            <div class="container">
                <div class="gridview">
                    <asp:GridView ID="gridrec" runat="server" CssClass="table table-striped" AutoGenerateColumns="false" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                        <Columns>
                            <asp:BoundField DataField="rec_nome" HeaderText="Nome da Recompensa" />
                            <asp:BoundField DataField="rec_descricao" HeaderText="Descrição da Recompensa" />
                            <asp:BoundField DataField="rec_pontos" HeaderText="Pontuação a ser obtida para a Recompensa" />

                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:Button ID="btnSelecionarrec" Text="Selecionar" CssClass="btn btn-outline-danger my-2 my-sm-0" CommandArgument='<%# Eval("id") %>' runat="server" OnClick="btnSelecionarrec_Click"/>
                                </ItemTemplate>

                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>



        </section>


    </form>
    <!-- Bootstrap core JS-->
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/js/bootstrap.bundle.min.js"></script>
    <!-- Core theme JS-->
    <script src="js/scripts.js"></script>
    <!-- * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *-->
    <!-- * *                               SB Forms JS                               * *-->
    <!-- * * Activate your form at https://startbootstrap.com/solution/contact-forms * *-->
    <!-- * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *-->
    <script src="https://cdn.startbootstrap.com/sb-forms-latest.js"></script>
</body>
</html>
