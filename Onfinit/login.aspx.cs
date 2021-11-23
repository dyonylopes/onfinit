using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Onfinit
{
    public partial class login : System.Web.UI.Page
    {
        Conexao con = new Conexao();
        string emailUsuario, nivelUsuario;

        protected void Page_Load(object sender, EventArgs e)
        {
            panelLogin.Visible = false;
        }

        protected void Login_Click(object sender, EventArgs e)
        {
            if (txtEmail.Text == "")
            {
                panelLogin.Visible = true;
                lblMensagemLogin.Text = "Insira seu usuário!";
                txtEmail.Focus();
                return;

            }
            if (txtSenha.Text == "")
            {
                panelLogin.Visible = true;
                lblMensagemLogin.Text = "Insira sua senha!";
                txtSenha.Focus();
                return;

            }

            Logar();
        }

        private void Logar()
        {
            MySqlCommand cmd;
            MySqlDataReader reader;

            con.AbrirCon(); //usuários do banco
            cmd = new MySqlCommand("SELECT * FROM usuarios where email = @email and senha = @senha", con.con);
            cmd.Parameters.AddWithValue("@email", txtEmail.Text);
            cmd.Parameters.AddWithValue("@senha", txtSenha.Text);
            reader = cmd.ExecuteReader(); //extrair dados do usuário

            if (reader.HasRows)
            {

                while (reader.Read())
                {
                    emailUsuario = reader["email"].ToString();
                    nivelUsuario = reader["nivel_nivel"].ToString();
                    panelLogin.Visible = true;
                    lblMensagemErro.Text = emailUsuario; //colocar o nome do usuário
                }




                if (nivelUsuario == "administrador") // se for  nível admin vai para index.aspx
                {

                    // Server.Transfer("index.aspx");
                    Response.Redirect("home.aspx"); // redirecionamento com parâmetro

                    lblMensagemErro.Text = "Logou";
                    panelLogin.Visible = false;
                    txtSenha.Text = "";
                    txtEmail.Text = "";
                }
                else if (nivelUsuario == "infantil") // se for  nível admin vai para pagamento.aspx
                {

                    Response.Redirect("infantil.aspx"); // redirecionamento com parâmetro
                    lblMensagemErro.Text = "Logou";
                    panelLogin.Visible = false;
                    txtSenha.Text = "";
                    txtEmail.Text = "";


                }



            }
            else
            {
                panelLogin.Visible = true;
                lblMensagemErro.Text = "Dados Incorretos!!";
                txtEmail.Text = "";
                txtSenha.Text = "";
                txtEmail.Focus();
            }


        }
    }
    
}