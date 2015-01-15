using System;
using System.Collections.Generic;
using Aplicacao;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AvaliacaoSoitic.Helpers
{
    public class HelpersSoitic
    {

        /*
         * Método que retorna um TempData com mensagem, classe para exbição e ícone.
         * Observação: criar um helper para que possa ser usado em outras Controllers.
         */
        public static void Mensagem(string status, string mensagem)
        {
            if (status == "OK")
            {
                //TempData["mensagem"] = mensagem;
                //TempData["classe"] = "alert alert-success";
                //TempData["icone"] = "fa fa-check";
            }
            else
            {
                //TempData["mensagem"] = mensagem;
                //TempData["classe"] = "alert alert-danger";
                //TempData["icone"] = "fa fa-ban";
            }

        }
    }
}