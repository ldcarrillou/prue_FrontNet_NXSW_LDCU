using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using APIRESTFul_WebNexosLDCU.Negocio;

namespace APIRESTFul_WebNexosLDCU.Controllers
{
    public class LibroController : Controller
    {
        // GET: Libro
        public ActionResult Index()
        {
            ViewBag.libros = new Libro_nxsw().ReadAll();
            return View();
        }

        // GET: Libro/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Libro/Create
        public ActionResult Create()
        {
            EnviarAutores();

            return View();
        }

        private void EnviarAutores()
        {
            ViewBag.autores = new Autor_nxsw().ReadAll();
        }

        // POST: Libro/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "Titulo_libro, Ano_libro, Genero_libro," +
            "Numpags_libro, Autor_id")]Libro_nxsw libro)
        {
            try
            {
                // TODO: Add insert logic here
                libro.Save();
                TempData["mensaje"] = "Guardado correctamente";
                return RedirectToAction("Index");
            }
            catch
            {
                return View(libro);
            }
        }

        // GET: Libro/Edit/5
        public ActionResult Edit(int id_libro)
        {
            Libro_nxsw p = new Libro_nxsw().Find(id_libro);
            if(p == null)
            {
                TempData["mensaje"] = "El libro no existe";
                return RedirectToAction("Index");
            }
            EnviarAutores();
            return View(p);
        }

        // POST: Libro/Edit/5
        [HttpPost]
        public ActionResult Edit([Bind(Include = "Id_libro, Titulo_libro, Ano_libro, Genero_libro," +
            "Numpags_libro, Autor_id")]Libro_nxsw libro)
        {
            try
            {
                // TODO: Add update logic here
                libro.Update();
                TempData["mensaje"] = "Modificado correctamente";
                return RedirectToAction("Index");
            }
            catch
            {
                return View(libro);
            }
        }

        // GET: Libro/Delete/5
        public ActionResult Delete(int id_libro)
        {
            if(new Libro_nxsw().Find(id_libro) == null)
            {
                TempData["mensaje"] = "No existe el libro";
                return RedirectToAction("Index");
            }
            if (new Libro_nxsw().Delete(id_libro))
            {
                TempData["mensaje"] = "Eliminado correctamente";
                return RedirectToAction("Index");
            }
            TempData["mensaje"] = "No se ha podido eliminar";
            return RedirectToAction("Index");
        }

        // POST: Libro/Delete/5
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
