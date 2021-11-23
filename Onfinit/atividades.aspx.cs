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
    public partial class atividades : System.Web.UI.Page
    {
        Conexao con = new Conexao();
        Int32 id;
        string emailUsuario, nivelUsuario;
        protected void Page_Load(object sender, EventArgs e)
        {
            emailUsuario = Request.QueryString["email"];
            nivelUsuario = Request.QueryString["nivel"];

            if (!IsPostBack)

            {

                Listar();

            }

        }
        /* Botão Adicionar nova atividade */
        protected void btnAdicionar_Click(object sender, EventArgs e)
        {

            if (txtAtividade.Text == "")
            {
                lblMensagemErro.Text = "Preencha o campo Atividade!";
                txtAtividade.Focus();
                return;



            }
            if (txtDescricao.Text == "")
            {
                lblMensagemErro.Text = "Preencha o campo Descrição da atividade!";
                txtDescricao.Focus();
                return;


            }

            if (txtPontuação.Text == "")
            {
                lblMensagemErro.Text = "Preencha o campo Pontuação da atividade!";
                txtPontuação.Focus();
                return;

            }

            AdicionarAtv();
        }

        protected void AdicionarAtv()
        {
            string sql;
            MySqlCommand cmd;

            con.AbrirCon();

           
          
            sql = " INSERT INTO atividades(atv_nome, atv_descricao, atv_pontos, statusatv) VALUES (@atv_nome, @atv_descricao, @atv_pontos, @statusatv)";
            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@atv_nome", txtAtividade.Text);
            cmd.Parameters.AddWithValue("@atv_descricao", txtDescricao.Text);
            cmd.Parameters.AddWithValue("@atv_pontos", Convert.ToDouble(txtPontuação.Text));
            cmd.Parameters.AddWithValue("@statusatv", "atribuida");


            cmd.ExecuteNonQuery();
            LimparCampos();
            lblatividade.Text = "Atividade Adicionado com Sucesso !!";
            Listar();
            con.FecharCon();
        }

        protected void grid_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
   
        private void LimparCampos()
        {
            txtAtividade.Text = "";
            txtDescricao.Text = "";
            txtPontuação.Text = "";
          
        }

       

        protected void btnSelecionar_Click(object sender, EventArgs e)
        {
            id = Convert.ToInt32((sender as Button).CommandArgument); //pegar o ID da grid
            string sql;
            MySqlCommand cmd;
            MySqlDataAdapter da = new MySqlDataAdapter(); //armazenar informações do mysql
            DataTable dt = new DataTable(); //para receber dados do mysql

            con.AbrirCon();
            sql = "SELECT * FROM atividades where id = @id"; //parametro id recebe parametro
            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@id", id); //sempre tem que jogar abaixo do MySqlCommand
            da.SelectCommand = cmd;
            da.Fill(dt);
            txtAtividade.Text = dt.Rows[0][1].ToString();
            txtDescricao.Text = dt.Rows[0][2].ToString();
            txtPontuação.Text = dt.Rows[0][3].ToString();   // para pegar os dados do banco e editar
            ;


            idatividades.Value = dt.Rows[0][0].ToString();

            btnAdicionar.Enabled = false;
            btnEditar.Enabled = true;
            btnDeletar.Enabled = true;
            
            con.FecharCon();


        }

        protected void btnDeletar_Click(object sender, EventArgs e)
        {
            if (idatividades.Value != "")
            {
                Excluir();
            }

           
        }
        private void Excluir()
        {
            string sql;
            MySqlCommand cmd;

            con.AbrirCon();

            sql = "DELETE FROM atividades where id = @id";
            cmd = new MySqlCommand(sql, con.con);

            cmd.Parameters.AddWithValue("@id", idatividades.Value);

            cmd.ExecuteNonQuery();
            lblatividade.Text = "Atividade Excluida com Sucesso !!";
            Listar();
            con.FecharCon();

            btnEditar.Enabled = false;
            btnDeletar.Enabled = false;
            btnAdicionar.Enabled = true;
            
            LimparCampos();
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            if (txtAtividade.Text == "")
            {
              /*  lblMensagemErro.Text = "Preencha o campo Nome!"; */
                txtAtividade.Focus();
                return;

            }
            if (txtDescricao.Text == "")
            {
                /*  lblMensagemErro.Text = "Preencha o campo Nome!"; */
                txtDescricao.Focus();
                return;

            }
            if (txtPontuação.Text == "")
            {
                /*  lblMensagemErro.Text = "Preencha o campo Nome!"; */
                txtPontuação.Focus();
                return;

            }
           

            if (idatividades.Value != "")// se for diferente de vazio edita.
            {

                Editar();

            }
        }
        private void Editar()  //método botão editar
        {
            string sql;
            MySqlCommand cmd;

            con.AbrirCon();

            sql = "UPDATE atividades SET atv_nome = @atv_nome, atv_descricao = @atv_descricao, atv_pontos = @atv_pontos  where id =@id";
            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@atv_nome", txtAtividade.Text);
            cmd.Parameters.AddWithValue("@atv_descricao", txtDescricao.Text);
            cmd.Parameters.AddWithValue("@atv_pontos", Convert.ToDouble(txtPontuação.Text));

            cmd.Parameters.AddWithValue("@id", idatividades.Value);

            cmd.ExecuteNonQuery();
            lblatividade.Text = "Atividade Editada com Sucesso !!";
            Listar();
            con.FecharCon();


            btnEditar.Enabled = false;
            btnDeletar.Enabled = false;
            btnAdicionar.Enabled = true;
            
            LimparCampos();
        }

            private void Listar()
        {
            string sql;
            MySqlCommand cmd;
            MySqlDataAdapter da = new MySqlDataAdapter(); //armazenar informações do mysql
            DataTable dt = new DataTable(); //para receber dados do mysql

            con.AbrirCon(); //Inner join para pegar de outras tabelas mudo o prefixo
            sql = "SELECT * FROM  atividades where statusatv = 'atribuida'";
            cmd = new MySqlCommand(sql, con.con);
            da.SelectCommand = cmd;
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {

                grid.Visible = true;
                grid.DataSource = dt; //receber na Datatable
                grid.DataBind(); // Atualizar dados           

            }
           


            con.FecharCon();
        }


    }
}