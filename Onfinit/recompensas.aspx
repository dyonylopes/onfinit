<%@ Page Title="" Language="C#" MasterPageFile="~/menu.Master" AutoEventWireup="true" CodeBehind="recompensas.aspx.cs" Inherits="Onfinit.recompensas"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <link href="Css/estilogeral.css" rel="stylesheet" />

    <link rel = "preconnect" href = "https://fonts.googleapis.com">
<link rel = "preconnect" href = "https://fonts.gstatic.com" crossorigin>
<link href = "https: //fonts.googleapis.com/css2? family = Hind + Siliguri & display = swap "rel =" stylesheet ">

    <header>
        <br />
        <h1>Recompensas</h1>
        <br />
        
    </header>
     <asp:HiddenField ID="idrecompensas" runat="server" />
    <main class="meio">
      <!--  <div class="form-group row">
            <div class="col-sm-6 mb-3 mb-sm-0"> -->
                <div class="main--container">
                    <div class="main--atividade">
                        <div class="main--card">
                             <asp:Label Text="" ID="lblRecompensa" runat="server" ForeColor="Green" />
                             <asp:Label Text="" ID="lblMensagemErro" runat="server" ForeColor="Red" />
                            <asp:TextBox ID="txtRecompensa" runat="server" class="form-control form-control-user" placeholder="Digite o nome da Recompensa" />

                       
                            <asp:TextBox ID="txtDescricaorec" runat="server" class="form-control form-control-user" placeholder="Digite a descrição da Recompensa" />
                     
           
                        <asp:TextBox ID="txtPontuaçãorec"  runat="server" class="form-control form-control-user" TextMode="Number" placeholder="Digite a pontuação a recompensa" />

                            <div class="btn-group btn-group-lg" role="group">
                            <asp:Button ID="btnAdicionar" Text="Adicionar" runat="server" CssClass="btn btn-outline-success my-2 my-sm-0" Enabled="true" OnClick="btnAdicionar_Click" />
                        <asp:Button ID="btnEditar" Text="Editar" runat="server" CssClass="btn btn-outline-primary  my-2 my-sm-0" Enabled="False" OnClick="btnEditar_Click"/>
                       <asp:Button ID="btnDeletar" Text="Excluir" runat="server" CssClass="btn btn-outline-danger my-2 my-sm-0" Enabled="False" OnClick="btnDeletar_Click"/>
                          </div>
                    </div>
                </div>
            </div>
      </main>
    <br />
     
        <div class="container">
                <div class="gridview">
                    <asp:GridView ID="grid" runat="server" CssClass="table table-striped" AutoGenerateColumns="false" OnSelectedIndexChanged="grid_SelectedIndexChanged1">
                        <Columns>
                            <asp:BoundField DataField="rec_nome" HeaderText="Nome da Recompensa" />
                            <asp:BoundField DataField="rec_descricao" HeaderText="Descrição da Recompensa" />
                            <asp:BoundField DataField="rec_pontos" HeaderText="Pontuação a ser obtida para a Recompensa" />
                            
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
