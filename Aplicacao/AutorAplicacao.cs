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
    public class AutorAplicacao
    {
        private Contexto contexto;

        /*
         * Monta a query de inserção recebendo um autor como parâmetro. 
         * Executa o método da classe contexto que não possui retorno (ExecutaComando).         
         */
        public void Insert(Autor autor)
        {
            var query = "";
            query += "INSERT INTO autor (nome_autor)";
            query += string.Format("VALUES ('{0}') ", autor.nome_autor);            
            using (contexto = new Contexto())
            {
                contexto.ExecutaComando(query);
            }
        }

        /*
         * Recebe um autor_id, monta a query e executa o comando da classe Contexto
         * que não possui retorno.
         */
        public void Delete(int autor_id)
        {
            var query = "";
            query += "DELETE FROM autor ";
            query += string.Format("WHERE autor_id = '{0}' ", autor_id);
            using (contexto = new Contexto())
            {
                contexto.ExecutaComando(query);
            }
        }

        /*
         * Monta a query de update recebendo um autor como parâmetro. 
         * Executa o método da classe contexto que não possui retorno (ExecutaComando).         
         */
        public void Update(Autor autor)
        {
            var query = "";
            query += "UPDATE autor SET ";
            query += string.Format("nome_autor = '{0}', ", autor.nome_autor);
            query += string.Format("data_alteracao = getdate() ");
            query += string.Format(" WHERE autor_id = '{0}' ", autor.autor_id);
            using (contexto = new Contexto())
            {
                contexto.ExecutaComando(query);
            }
        }

        /*
         * Busca uma lista de autores e envia para o método responsável por transformar
         * a lista em objeto.
         */
        public List<Autor> ListarTodos()
        {
            using (contexto = new Contexto())
            {
                var strQuery = "SELECT * FROM autor";
                var retornoDataReader = contexto.ExecutaComandoRetorno(strQuery);
                return TransformaReaderEmListaDeObjetos(retornoDataReader);
            }
        }

        /*
         * Recebe um autor_id. Executa método com retorno (ExecutaComandoRetorno) da classe Contexto.
         * O primeiro resultado encontrado é transformado em objeto.
         */
        public Autor ListarPorId(int autor_id)
        {
            using (contexto = new Contexto())
            {
                var query = "";
                query += "SELECT * FROM autor ";
                query += string.Format("WHERE autor_id = '{0}' ", autor_id);
                var retornoDataReader = contexto.ExecutaComandoRetorno(query);
                return TransformaReaderEmListaDeObjetos(retornoDataReader).FirstOrDefault();
            }
        }

        /*
         * Recebe um sqlDataReader de categoria e adiciona cada linha da tabela 
         * à uma lista de categorias.                                                                
         */
        private List<Autor> TransformaReaderEmListaDeObjetos(SqlDataReader reader)
        {
            var autores = new List<Autor>();
            while (reader.Read())
            {
                var autor = new Autor()
                {
                    autor_id = int.Parse(reader["autor_id"].ToString()),
                    nome_autor = reader["nome_autor"].ToString(),
                    data_insercao = DateTime.Parse(reader["data_insercao"].ToString()),
                    data_alteracao = DateTime.Parse(reader["data_alteracao"].ToString())
                };
                autores.Add(autor);
            }
            reader.Close();
            return autores;
        }


    }
}
