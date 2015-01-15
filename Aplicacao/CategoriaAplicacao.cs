using Dominio;
using Repositorio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao
{
    public class CategoriaAplicacao
    {
        private Contexto contexto;

        /*
         * Monta a query de inserção recebendo uma categoria como parâmetro. 
         * Executa o método da classe contexto que não possui retorno (ExecutaComando).         
         */
        public void Insert(Categoria categoria)
        {
            var query = "";
            query += "INSERT INTO categoria (nome_categoria)";
            query += string.Format("VALUES ('{0}') ", categoria.nome_categoria);
            // O objeto é destruído após ser usado.
            using (contexto = new Contexto())
            {
                contexto.ExecutaComando(query);
            }
        }


        public void Update(Categoria categoria)
        {
            var query = "";
            query += "UPDATE categoria SET ";
            query += string.Format("nome_categoria = '{0}', ", categoria.nome_categoria);
            query += string.Format("data_alteracao = getdate() ");
            query += string.Format(" WHERE categoria_id = '{0}' ", categoria.categoria_id);
            using (contexto = new Contexto())
            {
                contexto.ExecutaComando(query);
            }
        }

        public void Delete(int categoria_id)
        {
            var query = "";
            query += "DELETE FROM categoria ";
            query += string.Format("WHERE categoria_id = '{0}' ", categoria_id);
            using (contexto = new Contexto())
            {
                contexto.ExecutaComando(query);
            }
        }

        public Categoria ListarPorId(int categoria_id)
        {   
            using (contexto = new Contexto())
            {
                var query = "";
                query += "SELECT * FROM categoria ";
                query += string.Format("WHERE categoria_id = '{0}' ", categoria_id);
                var retornoDataReader = contexto.ExecutaComandoRetorno(query);
                return TransformaReaderEmListaDeObjetos(retornoDataReader).FirstOrDefault(); 
            }
        }

        public List<Categoria>ListarTodos()
        {
            using (contexto = new Contexto())
            {
                var strQuery = "SELECT * FROM categoria";
                var retornoDataReader = contexto.ExecutaComandoRetorno(strQuery);
                return TransformaReaderEmListaDeObjetos(retornoDataReader);
            }
        }


        /*
         * Recebe um sqlDataReader de categoria e adiciona cada linha da tabela 
         * à uma lista de categorias.                                                                
         */
        private List<Categoria> TransformaReaderEmListaDeObjetos(SqlDataReader reader)
        {
            var categorias = new List<Categoria>();
            while (reader.Read())
            {
                var categoria = new Categoria()
                {
                    categoria_id = int.Parse(reader["categoria_id"].ToString()),
                    nome_categoria = reader["nome_categoria"].ToString(),
                    data_insercao = DateTime.Parse(reader["data_insercao"].ToString()),
                    data_alteracao = DateTime.Parse(reader["data_alteracao"].ToString())
                };
                categorias.Add(categoria);
            }
            reader.Close();
            return categorias;
        }
    }
}
