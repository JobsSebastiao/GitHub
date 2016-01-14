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
        // GET: Categoria
        public ActionResult Index()
        {
            CategoriasDAO dao = new CategoriasDAO();
            ViewBag.Categorias = dao.Lista();
            return View();
        }

        public ActionResult Form()
        {
            return View();
        }

        public ActionResult Adiciona(CategoriaDoProduto categoria)
        {
            var dao = new CategoriasDAO();
            dao.Adiciona(categoria);
            return RedirectToAction("Index");
        }
    }
}