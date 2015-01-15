using System;
using System.Collections.Generic;
using Aplicacao;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dominio;

namespace AvaliacaoSoitic.Controllers
{
    public class CategoriaController : Controller
    {        
        private CategoriaAplicacao aplicacaoCategoria = new CategoriaAplicacao();
     
        /*
         * Exibe lista contendo todas as categorias cadastradas.
         */
        public ActionResult Index()
        {
            ViewBag.Title = "Categorias";
            return View(aplicacaoCategoria.ListarTodos());
        }

        /*
         * Abre formulário para inserção de uma nova categoria.
         */
        public ActionResult Create()
        {
            ViewBag.Title = "Cadastrar Categoria";
            return View();
        }

        /*
         * Recebe um objeto Categoria do formulário (via post), passa pela validação
         * e envia para o método da aplicação responsável pelo Insert.
         */
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Categoria categoria)
        {

            if(ModelState.IsValid)
            {                
                aplicacaoCategoria.Insert(categoria);
                _Mensagem("OK", " Cadastro realizado com sucesso.");
                return RedirectToAction("Index");
            }

            return View();
        }

        /*
         * Recebe categoria_id vindo do POST, e passa para o método da aplicação que
         * busca uma categoria pelo id (ListarPorId). Envia objeto Categoria encontrado
         * para o formulário de edição de dados.
         */
        public ActionResult Edit(int categoria_id)
        {
            var categoria = aplicacaoCategoria.ListarPorId(categoria_id);
            if (categoria == null)
            {
                return HttpNotFound(); // Personalizar página de erro.
            }
            ViewBag.Title = "Editar Categoria";
            return View(categoria);
        }

        /*
         * Recebe um objeto categoria, realiza a validação e envia para o método
         * da aplicação que irá realizar o Update.
         */
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Categoria categoria)
        {            
            if(ModelState.IsValid)
            {
                aplicacaoCategoria.Update(categoria);
                _Mensagem("OK", " Categoria editada com sucesso.");
                return RedirectToAction("Index");
            }            
            return View();            
        }

        /*
         * Recebe categoria_id. O método da aplicação ListarPorId é chamado obtendo
         * um objeto categoria.
         */
        [HttpGet]
        public ActionResult Details(int categoria_id)
        {            
            var categoria = aplicacaoCategoria.ListarPorId(categoria_id);
            if(categoria == null)
            {
                return HttpNotFound(); // Personalizar página de erro.
            }
            ViewBag.Title = "Detalhes";
            return View(categoria);
        }        

        /*
         * Recebe categoria_id e envia para o método da aplicação 
         * responsável pela remoção do registro. 
         */
        [HttpGet]
        public ActionResult Delete(int categoria_id)
        {         
            string status;
            string mensagem;
            try
            {               
                aplicacaoCategoria.Delete(categoria_id);
                status = "OK";
                mensagem = " Categoria excluída com sucesso.";
            }
            catch
            {
                status = "FAIL";
                mensagem = " Falha na exclusão.";
            }
            _Mensagem(status, mensagem);
            return RedirectToAction("Index");
        }

        /*
         * Método que retorna um TempData com mensagem, classe para exbição e ícone.
         * Observação: criar um helper para que possa ser usado em outras Controllers.
         */
        public void _Mensagem(string status, string mensagem)
        {
            if (status == "OK")
            {
                TempData["mensagem"] = mensagem;
                TempData["classe"] = "alert alert-success";
                TempData["icone"] = "fa fa-check";
            }
            else
            {
                TempData["mensagem"] = mensagem;
                TempData["classe"] = "alert alert-danger";
                TempData["icone"] = "fa fa-ban";
            }
            
        }


    }
}
