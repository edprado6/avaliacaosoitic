using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    /*
     * Classe que representa a tabela categoria. 
     */
    public class Categoria
    {
        public int categoria_id { get; set; }
        public string nome_categoria { get; set; }
        public DateTime data_insercao { get; set; }
        public DateTime data_alteracao { get; set; }
    }
}
