using System;
using System.Collections.Generic;
// Validação e Helpers
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Autor
    {
        [DisplayName("Cód.")]
        public int autor_id { get; set; }

        [DisplayName("Autor")]
        [Required(ErrorMessage = "Informe o nome do autor.")]
        [MaxLength(100)]
        public string nome_autor { get; set; }

        [DisplayName("Data de inserção")]
        public DateTime data_insercao { get; set; }

        [DisplayName("Data de alteração")]
        public DateTime data_alteracao { get; set; }
    }
}
