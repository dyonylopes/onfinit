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
    public partial class contas : System.Web.UI.Page
    {
        Conexao con = new Conexao();
        Int32 id;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)

            {

                Listar();
               // Usuario();

            }
            

        }
     /*   private void Usuario()
        {
            string sql;
            MySqlCommand cmd;
            MySqlDataAdapter da = new MySqlDataAdapter(); //armazenar informações do mysql
            DataTable dt = new DataTable(); //para receber dados do mysql

            con.AbrirCon();
            //  sql = "SELECT sum(atv_pontos ) as SOMA from atividades where statusatv = 'concluida';";
            sql = "SELECT nome as NOME, sobrenome as SOBRENOME, email as EMAIL FROM usuarios where id = '9';";
            cmd = new MySqlCommand(sql, con.con);
            // cmd.Parameters.AddWithValue("@pontos", txtpontos.Text); //sempre tem que jogar abaixo do MySqlCommand
            da.SelectCommand = cmd;
            da.Fill(dt);



            lblnome.Text = dt.Rows[0]["NOME"].ToString();
            lblsobrenome.Text = dt.Rows[0]["SOBRENOME"].ToString();
            lblemail.Text = dt.Rows[0]["EMAIL"].ToString();

            


            con.FecharCon();



        } */



        protected void btnBotaocadinf_Click(object sender, EventArgs e)
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
            cmd.Parameters.AddWithValue("@nivel_nivel", "infantil");





            cmd.ExecuteNonQuery();
            Listar();
            LimparCampos();
            lblUsuario.Text = "Usuário Cadastrado com sucesso!! Agora a criança já pode aproveitar dos benefícios da Onfinit!!";

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

        protected void grid_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Listar()
        {
            string sql;
            MySqlCommand cmd;
            MySqlDataAdapter co = new MySqlDataAdapter(); //armazenar informações do mysql
            DataTable dt = new DataTable(); //para receber dados do mysql

            con.AbrirCon(); //Inner join para pegar de outras tabelas mudo o prefixo
            sql = "SELECT * FROM  usuarios where nivel_nivel = 'infantil'";
            cmd = new MySqlCommand(sql, con.con);
            co.SelectCommand = cmd;
            co.Fill(dt);

            if (dt.Rows.Count > 0)
            {

                grid.Visible = true;
                grid.DataSource = dt; //receber na Datatable
                grid.DataBind(); // Atualizar dados           

            }



            con.FecharCon();
        }




        protected void btnSelecionar_Click(object sender, EventArgs e)
        {
            id = Convert.ToInt32((sender as Button).CommandArgument); //pegar o ID da grid
            string sql;
            MySqlCommand cmd;
            MySqlDataAdapter co = new MySqlDataAdapter(); //armazenar informações do mysql
            DataTable dt = new DataTable(); //para receber dados do mysql

            con.AbrirCon();
            sql = "SELECT * FROM usuarios where id = @id"; //parametro id recebe parametro
            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@id", id); //sempre tem que jogar abaixo do MySqlCommand
            co.SelectCommand = cmd;
            co.Fill(dt);
            txtNome.Text = dt.Rows[0][1].ToString();
            txtEmail.Text = dt.Rows[0][2].ToString();
            txtSobrenome.Text = dt.Rows[0][6].ToString();
            // para pegar os dados do banco e editar
            txtSenha.Text = dt.Rows[0][4].ToString();
            txtPassword.Text = dt.Rows[0][3].ToString();

            ;


            idcontas.Value = dt.Rows[0][0].ToString();

            btnBotaocadinf.Enabled = false;
            btnEditar.Enabled = true;
            btnDeletar.Enabled = true;

            con.FecharCon();
        }

        protected void btnDeletar_Click(object sender, EventArgs e)
        {
            if (idcontas.Value != "")
            {
                Excluir();
            }
        }

        private void Excluir()
        {
            string sql;
            MySqlCommand cmd;

            con.AbrirCon();

            sql = "DELETE FROM usuarios where id = @id";
            cmd = new MySqlCommand(sql, con.con);

            cmd.Parameters.AddWithValue("@id", idcontas.Value);

            cmd.ExecuteNonQuery();
            lblconta.Text = "Usuário Excluido com Sucesso !!";
            Listar();
            con.FecharCon();

            btnEditar.Enabled = false;
            btnDeletar.Enabled = false;
            btnBotaocadinf.Enabled = true;

            LimparCampos();
        }

        protected void btnEditar_Click(object sender, EventArgs e)
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
            if (idcontas.Value != "")// se for diferente de vazio edita.
            {

                Editar();

            }
        }
        private void Editar()  //método botão editar
        {
            string sql;
            MySqlCommand cmd;

            con.AbrirCon();

            sql = "UPDATE usuarios SET nome = @nome, email = @email, senha = @senha, senharepete = @senharepete, sobrenome = @sobrenome  where id =@id";
            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@nome", txtNome.Text);
            cmd.Parameters.AddWithValue("@sobrenome", txtSobrenome.Text);
            cmd.Parameters.AddWithValue("@email", txtEmail.Text);
            cmd.Parameters.AddWithValue("@senha", Convert.ToDouble(txtSenha.Text));
            cmd.Parameters.AddWithValue("@senharepete", Convert.ToDouble(txtPassword.Text));


            cmd.Parameters.AddWithValue("@id", idcontas.Value);

            cmd.ExecuteNonQuery();
            lblconta.Text = "Usuário editado com Sucesso !!";
            Listar();
            con.FecharCon();


            btnEditar.Enabled = false;
            btnDeletar.Enabled = false;
            btnBotaocadinf.Enabled = true;

            LimparCampos();
        }


        
        









    }
}