﻿using System;
using System.Collections.Generic;

// Validação e Helpers
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

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
        [DisplayName("Cód.")]
        public int categoria_id { get; set; }

        [DisplayName("Categoria")]
        [Required(ErrorMessage = "Informe um nome para a categoria.")]
        [MaxLength(100)]
        public string nome_categoria { get; set; }

        [DisplayName("Data de inserção")]
        public DateTime data_insercao { get; set; }

        [DisplayName("Data de alteração")]
        public DateTime data_alteracao { get; set; }
    }
}
