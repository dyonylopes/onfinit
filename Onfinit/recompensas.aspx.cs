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
    public partial class recompensas : System.Web.UI.Page
    {
        Conexao con = new Conexao();
        Int32 id;
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)

            {

                Listar();

            }
        }

        protected void btnAdicionar_Click(object sender, EventArgs e)
        {
            if (txtRecompensa.Text == "")
            {
                lblMensagemErro.Text = "Preencha o campo Recompensa!";
                txtRecompensa.Focus();
                return;



            }
            if (txtDescricaorec.Text == "")
            {
                lblMensagemErro.Text = "Preencha o campo Descrição da Recompensa!";
                txtDescricaorec.Focus();
                return;


            }

            if (txtPontuaçãorec.Text == "")
            {
                lblMensagemErro.Text = "Preencha o campo Pontuação da Recompensa!";
                txtPontuaçãorec.Focus();
                return;

            }

            AdicionarAtv();
        }

        protected void AdicionarAtv()
        {
            string sql;
            MySqlCommand cmd;

            con.AbrirCon();

            sql = "INSERT INTO recompensas (rec_nome, rec_descricao, rec_pontos, status) VALUES (@nome, @descricao, @pontos, @status)";
            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@nome", txtRecompensa.Text);
            cmd.Parameters.AddWithValue("@descricao", txtDescricaorec.Text);
            cmd.Parameters.AddWithValue("@pontos", Convert.ToDouble(txtPontuaçãorec.Text));
            cmd.Parameters.AddWithValue("@status", "atribuida");


            cmd.ExecuteNonQuery();
            LimparCampos();
            lblRecompensa.Text = "Recompensa Adicionado com Sucesso !!";
            Listar();
            con.FecharCon();
        }

        protected void grid_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void LimparCampos()
        {
            txtRecompensa.Text = "";
            txtDescricaorec.Text = "";
            txtPontuaçãorec.Text = "";

        }

        private void Listar()
        {
            string sql;
            MySqlCommand cmd;
            MySqlDataAdapter re = new MySqlDataAdapter(); //armazenar informações do mysql
            DataTable dt = new DataTable(); //para receber dados do mysql

            con.AbrirCon(); //Inner join para pegar de outras tabelas mudo o prefixo
            sql = "SELECT * FROM  recompensas where status = 'atribuida'";
            cmd = new MySqlCommand(sql, con.con);
            re.SelectCommand = cmd;
            re.Fill(dt);

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
            MySqlDataAdapter re = new MySqlDataAdapter(); //armazenar informações do mysql
            DataTable dt = new DataTable(); //para receber dados do mysql

            con.AbrirCon();
            sql = "SELECT * FROM recompensas where id = @id"; //parametro id recebe parametro
            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@id", id); //sempre tem que jogar abaixo do MySqlCommand
            re.SelectCommand = cmd;
            re.Fill(dt);
            txtRecompensa.Text = dt.Rows[0][1].ToString();
            txtDescricaorec.Text = dt.Rows[0][2].ToString();
            txtPontuaçãorec.Text = dt.Rows[0][3].ToString();   // para pegar os dados do banco e editar
            ;


            idrecompensas.Value = dt.Rows[0][0].ToString();

            btnAdicionar.Enabled = false;
            btnEditar.Enabled = true;
            btnDeletar.Enabled = true;

            con.FecharCon();

        }

      

        protected void btnDeletar_Click(object sender, EventArgs e)
        {
            if (idrecompensas.Value != "")
            {
                Excluir();
            }
        }
        private void Excluir()
        {
            string sql;
            MySqlCommand cmd;

            con.AbrirCon();

            sql = "DELETE FROM recompensas where id = @id";
            cmd = new MySqlCommand(sql, con.con);

            cmd.Parameters.AddWithValue("@id", idrecompensas.Value);

            cmd.ExecuteNonQuery();
            lblRecompensa.Text = "Recompensa Excluida com Sucesso !!";
            Listar();
            con.FecharCon();

            btnEditar.Enabled = false;
            btnDeletar.Enabled = false;
            btnAdicionar.Enabled = true;

            LimparCampos();
        }


        protected void btnEditar_Click(object sender, EventArgs e)
        {
            if (txtRecompensa.Text == "")
            {
                /*  lblMensagemErro.Text = "Preencha o campo Nome!"; */
                txtRecompensa.Focus();
                return;

            }
            if (txtDescricaorec.Text == "")
            {
                /*  lblMensagemErro.Text = "Preencha o campo Nome!"; */
                txtDescricaorec.Focus();
                return;

            }
            if (txtPontuaçãorec.Text == "")
            {
                /*  lblMensagemErro.Text = "Preencha o campo Nome!"; */
                txtPontuaçãorec.Focus();
                return;

            }


            if (idrecompensas.Value != "")// se for diferente de vazio edita.
            {

                Editar();

            }
        }

        private void Editar()  //método botão editar
        {
            string sql;
            MySqlCommand cmd;

            con.AbrirCon();

            sql = "UPDATE recompensas SET rec_nome = @nome, rec_descricao = @descricao, rec_pontos = @pontos  where id =@id";
            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@nome", txtRecompensa.Text);
            cmd.Parameters.AddWithValue("@descricao", txtDescricaorec.Text);
            cmd.Parameters.AddWithValue("@pontos", Convert.ToDouble(txtPontuaçãorec.Text));

            cmd.Parameters.AddWithValue("@id", idrecompensas.Value);

            cmd.ExecuteNonQuery();
            lblRecompensa.Text = "Recompensa editada com Sucesso !!";
            Listar();
            con.FecharCon();


            btnEditar.Enabled = false;
            btnDeletar.Enabled = false;
            btnAdicionar.Enabled = true;

            LimparCampos();
        }

        protected void grid_SelectedIndexChanged1(object sender, EventArgs e)
        {

        }

       
    }
}