using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Onfinit
{
    public class Conexao
    {

        public string conec = "SERVER=localhost; DATABASE=onfinit; UID=root; PWD=root; PORT=3306";
        public MySqlConnection con = null;

        public void AbrirCon ()
        {
            try
            {
                con = new MySqlConnection(conec);
                con.Open();
            }
            catch (Exception ex)
            {

                
            }

        }
        public void FecharCon()
        {
            try
            {
                con = new MySqlConnection(conec);
                con.Close();
            }
            catch (Exception ex)
            {

                HttpContext.Current.Response.Write("Erro ao Fechar" + ex);
            }

        }



    }
}