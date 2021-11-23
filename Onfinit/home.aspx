<%@ Page Title="" Language="C#" MasterPageFile="~/menu.Master" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="Onfinit.home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="Css/estilogeral.css" rel="stylesheet" />
    <br />

    <main>
        <div>
    <h1>Atividades Concluidas</h1>
            </div>
        </main>
   

    <div class="container">
                <div class="gridview">
                    <asp:GridView ID="grid" runat="server" CssClass="table table-striped" AutoGenerateColumns="false" OnSelectedIndexChanged="grid_SelectedIndexChanged">
                        <Columns>
                            <asp:BoundField DataField="atv_nome" HeaderText="Nome da Atividade" />
                            <asp:BoundField DataField="atv_descricao" HeaderText="Descrição da Atividade" />
                            <asp:BoundField DataField="atv_pontos" HeaderText="Pontuação da atividade" />
                            
                           
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
    <br />
    <br>
     <div class="justify-content-center">
    <h1>Recompensa escolhida</h1>
            </div>
   
    <div class="container">
                <div class="gridview">
                    <asp:GridView ID="grid1" runat="server" CssClass="table table-striped" AutoGenerateColumns="false" OnSelectedIndexChanged="grid_SelectedIndexChanged">
                        <Columns>
                            <asp:BoundField DataField="rec_nome" HeaderText="Nome da Recompensa" />
                            <asp:BoundField DataField="rec_descricao" HeaderText="Descrição da Recompensa" />
                            <asp:BoundField DataField="rec_pontos" HeaderText="Pontuação da recompensa" />
                            
                           
                        </Columns>
                    </asp:GridView>
                </div>
            </div>

</asp:Content>
