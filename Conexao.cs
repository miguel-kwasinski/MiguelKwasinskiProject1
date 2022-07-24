using Microsoft.Data.SqlClient;
using System;


namespace trab1
{
    public class Conexao
    {
        SqlConnection connection = new SqlConnection();
        public Conexao()
        {
            connection.ConnectionString = @"User ID=aluno4;Password=aluno_4682;Data Source=localhost\SQLEXPRESS;
            Initial Catalog=Eproc_aluno4;Persist Security Info=True;Timeout=120;TrustServerCertificate=True";
        }
        public SqlConnection Conectar()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
            return connection;
        }
        public void Desconectar()
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }

        }
    }

}