using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio
{
    /* 
     * Classe de conexão com o DB. Executa dois métodos.
     * 
     * 1. Necessita retorno (SELECT)
     * 2. Não necessita retorno (CREATE, UPDATE, DELETE)
     * 
     * Herda da classe IDisposable. Método Dispose fecha conexão com o banco. 
     * É sempre executadoquando a classe é encerrada.
     */
    public class Contexto : IDisposable
    {

        private readonly SqlConnection conexaodb;


        public Contexto()
        {
            conexaodb = new SqlConnection(ConfigurationManager.ConnectionStrings["AvaliacaoSoiticConfig"].ConnectionString);
            conexaodb.Open();
        }

        /*
         * Método que não possui retorno (CREATE, UPDATE, DELETE)
         * Recebe uma string SQL e executa o comando.
         */
        public void ExecutaComando(string query)
        {
            var comando = new SqlCommand
            {
                CommandText = query,
                CommandType = CommandType.Text,
                Connection = conexaodb
            };

            comando.ExecuteNonQuery();
        }

        /*
         * Método que possui retorno (SELECT)
         */
        public SqlDataReader ExecutaComandoRetorno(string query)
        {
            var comando = new SqlCommand(query, conexaodb);
            return comando.ExecuteReader();
        }

        /*
         * É sempre executado, encerrando a conexão com o DB.
         */
        public void Dispose()
        {
            if (conexaodb.State == ConnectionState.Open)
            {
                conexaodb.Close();
            }

        }
    }
}
