using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace WebMVC.Models
{
    public class conexaoDB
    {
        private string sHost;
        private int iPorta;
        private string sDatabase;
        private string sUtilizador;
        private string sPassword;
        private MySqlConnection sqlConnection = null;

        public conexaoDB(string sHost, int iPorta, string sDatabase, string sUtilizador, string sPassword)
        {
            this.sHost = sHost;
            this.iPorta = iPorta;
            this.sUtilizador = sUtilizador;
            this.sPassword = sPassword;
            this.sDatabase = sDatabase;
        }

        // Method that returns the connection
        public MySqlConnection obterConexao()
        {
            // Error treatment
            try
            {
                string sConnectionInfo = "datasource=" + sHost + ";port=" + iPorta + ";username=" + sUtilizador + ";password=" + sPassword + ";database=" + sDatabase + ";SslMode=none";

                sqlConnection = new MySqlConnection(sConnectionInfo);

                sqlConnection.Open();

                return sqlConnection;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.StackTrace);
            }
            return null;
        }
    }
}