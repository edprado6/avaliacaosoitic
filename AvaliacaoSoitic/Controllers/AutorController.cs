using System;
using System.Collections.Generic;
using Aplicacao;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dominio;

namespace AvaliacaoSoitic.Controllers
{
    public class AutorController : Controller
    {
        private AutorAplicacao autorAplicacao = new AutorAplicacao();

        /*
         * Exibe lista contendo todos os autores cadastrados.
         */
        public ActionResult Index()
        {
            ViewBag.Title = "Autores";
            return View(autorAplicacao.ListarTodos());
        }

        /* GET: /Autor/Details/5
         * Recebe autor_id. O método da aplicação ListarPorId é chamado obtendo
         * um objeto categoria.
         */
        public ActionResult Details(int autor_id)
        {
            var autor = autorAplicacao.ListarPorId(autor_id);
            if (autor == null)
            {
                return HttpNotFound(); // Personalizar página de erro.
            }
            ViewBag.Title = "Detalhes";
            return View(autor);
        }

        /* GET: /Autor/Create
         * 
         * Abre formulário para inserção de um novo autor.
         */
        public ActionResult Create()
        {
            ViewBag.Title = "Cadastrar Autor";
            return View();
        }

        /* POST: /Autor/Create
         * 
         * Recebe um objeto Autor do formulário (via post), passa pela validação
         * e envia para o método da aplicação responsável pelo Insert.
         */
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Autor autor)
        {
            if(ModelState.IsValid)
            {
                autorAplicacao.Insert(autor);
                _Mensagem("OK", " Cadastro realizado com sucesso.");
                return RedirectToAction("Index");
            }            
            return View();            
        }

        /* GET: /Autor/Edit/5
         * Recebe autor_id vindo do POST, e passa para o método da aplicação que
         * busca um autor pelo id (ListarPorId). Envia objeto Autor encontrado
         * para o formulário de edição de dados.
         */
        public ActionResult Edit(int autor_id)
        {
            var autor = autorAplicacao.ListarPorId(autor_id);
            if (autor == null)
            {
                return HttpNotFound(); // Personalizar página de erro.
            }
            ViewBag.Title = "Editar Autor";
            return View(autor);
        }
                
        /* POST: /Autor/Edit/5
         * Recebe um objeto autor, realiza a validação e envia para o método
         * da aplicação que irá realizar o Update.
         */
        [HttpPost]
        public ActionResult Edit(Autor autor)
        {
            if(ModelState.IsValid)
            {
                autorAplicacao.Update(autor);
                _Mensagem("OK", " Autor editado com sucesso.");
                return RedirectToAction("Index");
            }
          
            return View();
            
        }
               
        /* POST: /Autor/Delete/5
         * 
         */
        [HttpGet]
        public ActionResult Delete(int autor_id)
        {
            string status;
            string mensagem;
            try
            {
                autorAplicacao.Delete(autor_id);
                status = "OK";
                mensagem = " Autor excluído com sucesso.";
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
