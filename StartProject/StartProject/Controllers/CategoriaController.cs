using StartProject.DAO;
using StartProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StartProject.Controllers
{
    public class CategoriaController : Controller
    {
        private CategoriasDAO dao;

        public CategoriaController(CategoriasDAO dao)
        {
            this.dao = dao;
        }


        // GET: Categoria
        public ActionResult Index()
        {
            ViewBag.Categorias = dao.Lista();
            return View();
        }

        public ActionResult Form()
        {
            return View();
        }

        public ActionResult Adiciona(CategoriaDoProduto categoria)
        {
            dao.Adiciona(categoria);
            return RedirectToAction("Index");
        }

        public ActionResult NumeroDeProdutosPorCategoria()
        {
            var list = dao.ListaNumeroDeProdutosPorCategoria();
            return View(list);
        }
    }
}