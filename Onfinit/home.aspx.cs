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
    public partial class home : System.Web.UI.Page
    {
        Conexao con = new Conexao();
        Int32 id;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)

            {

                Listar();
                Listarred();

            }
        }

        protected void grid_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        protected void btnbuscar_Click(object sender, EventArgs e)
        {
            Listar();
        }

        private void Listar()
        {
            string sql;
            MySqlCommand cmd;
            MySqlDataAdapter da = new MySqlDataAdapter(); //armazenar informações do mysql
            DataTable dt = new DataTable(); //para receber dados do mysql

            con.AbrirCon(); //Inner join para pegar de outras tabelas mudo o prefixo
            sql = "SELECT * FROM  atividades where statusatv = 'concluida'";
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


        private void Listarred()
        {
            string sql;
            MySqlCommand cmd;
            MySqlDataAdapter da = new MySqlDataAdapter(); //armazenar informações do mysql
            DataTable dt = new DataTable(); //para receber dados do mysql

            con.AbrirCon(); //Inner join para pegar de outras tabelas mudo o prefixo
            sql = "SELECT * FROM recompensas where status = 'escolhida' AND rec_pontos > '0';";
            cmd = new MySqlCommand(sql, con.con);
            da.SelectCommand = cmd;
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {

                grid1.Visible = true;
                grid1.DataSource = dt; //receber na Datatable
                grid1.DataBind(); // Atualizar dados           

            }



            con.FecharCon();
        }


    }
}