﻿using Aplicacao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AvaliacaoSoitic.Controllers
{
    public class LivroController : Controller
    {
       
        // GET: /Livro/
        public ActionResult Index()
        {
            var aplicacaoCategoria = new CategoriaAplicacao();
            var listaCategorias = aplicacaoCategoria.ListarTodos();
            return View(listaCategorias);
        }

        //
        // GET: /Livro/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Livro/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Livro/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Livro/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Livro/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Livro/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Livro/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
