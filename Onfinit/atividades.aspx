<%@ Page Title="" Language="C#" MasterPageFile="~/menu.Master" AutoEventWireup="true" CodeBehind="atividades.aspx.cs" Inherits="Onfinit.atividades" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="Css/estilogeral.css" rel="stylesheet" />

    <link rel = "preconnect" href = "https://fonts.googleapis.com">
<link rel = "preconnect" href = "https://fonts.gstatic.com" crossorigin>
<link href = "https: //fonts.googleapis.com/css2? family = Hind + Siliguri & display = swap "rel =" stylesheet ">

    <header>
        <br />
        <h1>Atividades</h1>
        <br />
        
    </header>
     <asp:HiddenField ID="idatividades" runat="server" />
    <main class="meio">
      <!--  <div class="form-group row">
            <div class="col-sm-6 mb-3 mb-sm-0"> -->
                <div class="main--container">
                    <div class="main--atividade">
                        <div class="main--card">
                             <asp:Label Text="" ID="lblatividade" runat="server" ForeColor="Green" />
                             <asp:Label Text="" ID="lblMensagemErro" runat="server" ForeColor="Red" />
                            <asp:TextBox ID="txtAtividade" runat="server" class="form-control form-control-user" placeholder="Digite o nome da Atividade" />

                       
                            <asp:TextBox ID="txtDescricao" runat="server" class="form-control form-control-user" placeholder="Digite a descrição da atividade" />
                     
           
                        <asp:TextBox ID="txtPontuação"  runat="server" class="form-control form-control-user" TextMode="Number" placeholder="Digite a pontuação da atividade" />

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
                    <asp:GridView ID="grid" runat="server" CssClass="table table-striped" AutoGenerateColumns="false" OnSelectedIndexChanged="grid_SelectedIndexChanged">
                        <Columns>
                            <asp:BoundField DataField="atv_nome" HeaderText="Nome da Atividade" />
                            <asp:BoundField DataField="atv_descricao" HeaderText="Descrição da Atividade" />
                            <asp:BoundField DataField="atv_pontos" HeaderText="Pontuação da atividade" />
                            
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
