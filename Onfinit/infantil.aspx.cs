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
    public partial class infantil : System.Web.UI.Page
    {
        Conexao con = new Conexao();
        Int32 id;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)

            {

                Listar_atv();
                Listar_rec();
                Pontos();

            }




        }
        private void Pontos()
        {
            string sql;
            MySqlCommand cmd;
            MySqlDataAdapter da = new MySqlDataAdapter(); //armazenar informações do mysql
            DataTable dt = new DataTable(); //para receber dados do mysql

            con.AbrirCon();
            //  sql = "SELECT sum(atv_pontos ) as SOMA from atividades where statusatv = 'concluida';";
            sql = "select (select sum(atv_pontos) from atividades where statusatv = 'concluida')  - (select sum(rec_pontos) from recompensas WHERE status = 'escolhida') as SOMA;";
            cmd = new MySqlCommand(sql, con.con);
            // cmd.Parameters.AddWithValue("@pontos", txtpontos.Text); //sempre tem que jogar abaixo do MySqlCommand
            da.SelectCommand = cmd;
            da.Fill(dt);



            txtpontos.Text = dt.Rows[0]["SOMA"].ToString();




            con.FecharCon();



        }

        private void Listar_atv()
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

        protected void grid_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }



        protected void btnSelecionaratv_Click(object sender, EventArgs e)
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
            txtponto.Text = dt.Rows[0][3].ToString();
            ;   // para pegar os dados do banco e editar
            ;


            idinfantil.Value = dt.Rows[0][0].ToString();

            btnTerminar.Enabled = true;

            bntCancelar.Enabled = true;

            con.FecharCon();


        }

        protected void bntCancelar_Click(object sender, EventArgs e)
        {
            LimparCampos();
            btnTerminar.Enabled = false;
            bntCancelar.Enabled = false;
            Listar_atv();
        }

        private void LimparCampos()
        {
            txtAtividade.Text = "";
            txtponto.Text = "";

        }
        private void LimparCampos1()
        {
            txtrec.Text = "";
            txtrecponto.Text = "";
        }

        protected void btnTerminar_Click(object sender, EventArgs e)
        {
            if (idinfantil.Value != "")// se for diferente de vazio edita.
            {

                Editar();

            }
            Listar_atv();
            Pontos();
        }

        private void Editar()  //método botão editar
        {
            string sql;
            MySqlCommand cmd;

            con.AbrirCon();

            sql = "UPDATE atividades SET statusatv = @statusatv where id =@id";
            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@statusatv", "concluida");


            cmd.Parameters.AddWithValue("@id", idinfantil.Value);

            cmd.ExecuteNonQuery();
            lblatividade.Text = "Atividade Conculida com Sucesso !!";
            Listar_atv();
            con.FecharCon();


            btnTerminar.Enabled = false;
            bntCancelar.Enabled = false;

            LimparCampos();
        }


        private void Pontorec()
        {

        }

        protected void btnEscolher_Click(object sender, EventArgs e)
        {
            if (idinfantil.Value != "")// se for diferente de vazio edita.
            {


                Editar1();




            }
            Listar_rec();
            Pontos();
        }

        protected void btnSair_Click(object sender, EventArgs e)
        {
            LimparCampos1();
            btnEscolher.Enabled = false;
            btnSair.Enabled = false;
            Listar_rec();
        }

        protected void btnSelecionarrec_Click(object sender, EventArgs e)
        {
            id = Convert.ToInt32((sender as Button).CommandArgument); //pegar o ID da grid
            string sql;
            MySqlCommand cmd;
            MySqlDataAdapter da = new MySqlDataAdapter(); //armazenar informações do mysql
            DataTable dt = new DataTable(); //para receber dados do mysql

            con.AbrirCon();
            sql = "SELECT id, rec_nome, rec_descricao, rec_pontos as PONTO, status FROM recompensas where id = @id"; //parametro id recebe parametro
            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@id", id); //sempre tem que jogar abaixo do MySqlCommand
            da.SelectCommand = cmd;
            da.Fill(dt);
            txtrec.Text = dt.Rows[0][1].ToString();
            txtrecponto.Text = dt.Rows[0][3].ToString();
            ;   // para pegar os dados do banco e editar
            ;


            idinfantil.Value = dt.Rows[0][0].ToString();
            btnSair.Enabled = true;

            btnEscolher.Enabled = true;




            con.FecharCon();
        }

        private void Editar1()  //método botão editar
        {
            string sql;
            MySqlCommand cmd;

            con.AbrirCon();

            sql = "UPDATE recompensas SET status = @status where id =@id";
            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@status", "escolhida");


            cmd.Parameters.AddWithValue("@id", idinfantil.Value);

            cmd.ExecuteNonQuery();
            lblatividade.Text = "Recompensa Escolhida com Sucesso !!";
            Listar_atv();
            con.FecharCon();


            btnEscolher.Enabled = false;
            btnSair.Enabled = false;

            LimparCampos1();
        }

        private void Listar_rec()
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

                gridrec.Visible = true;
                gridrec.DataSource = dt; //receber na Datatable
                gridrec.DataBind(); // Atualizar dados           

            }



            con.FecharCon();
        }
















    }



}