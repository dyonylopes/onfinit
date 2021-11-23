using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace Onfinit
{
    public partial class cadastro : System.Web.UI.Page
    {
        Conexao con = new Conexao();
        
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnBotaocad_Click(object sender, EventArgs e)
        {
            if (txtNome.Text == "")
            {
              lblMensagemErro.Text = "Preencha o campo Nome!";
                txtNome.Focus();
                return;



            }
            if (txtSobrenome.Text == "")
            {
             lblMensagemErro.Text = "Preencha o campo Sobrenome!";
                txtSobrenome.Focus();
                return;


            }

            if (txtEmail.Text == "")
            {
              lblMensagemErro.Text = "Preencha o campo Email!";
                txtEmail.Focus();
                return;

            }

            if (txtSenha.Text == "")
            {
               lblMensagemErro.Text = "Preencha o campo Senha!";
                txtSenha.Focus();
                return;

            }
            if (txtPassword.Text == "")
            {
                lblMensagemErro.Text = "Preencha o campo Senha!";
                txtPassword.Focus();
                return;

            }


            CadUsuario();
        }
        private void CadUsuario()
        {
            string sql;
            MySqlCommand cmd;

            con.AbrirCon();

            sql = "INSERT INTO usuarios (nome, sobrenome, email, senha, senharepete, nivel_nivel) VALUES (@nome, @sobrenome, @email, @senha, @senharepete, @nivel_nivel)";
            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@nome", txtNome.Text);
            cmd.Parameters.AddWithValue("@sobrenome", txtSobrenome.Text);
            cmd.Parameters.AddWithValue("@email", txtEmail.Text);
            cmd.Parameters.AddWithValue("@senha", Convert.ToDouble(txtSenha.Text));
            cmd.Parameters.AddWithValue("@senharepete", Convert.ToDouble(txtSenha.Text));
            cmd.Parameters.AddWithValue("@nivel_nivel", "administrador");





            cmd.ExecuteNonQuery();
            LimparCampos();
            lblUsuario.Text = "Usuário Cadastrado com sucesso!! Agora você já pode aproveitar dos benefícios da Onfinit. Para acessa, clique em Entrar!!";

            con.FecharCon();



        }
        private void LimparCampos()
        {
            txtNome.Text = "";
            txtSobrenome.Text = "";
            txtEmail.Text = "";
            txtSenha.Text = "";
            txtPassword.Text = "";
           
        }
    }
}