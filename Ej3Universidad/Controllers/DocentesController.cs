using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ej3Universidad.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ej3Universidad.Controllers
{
    public class DocentesController : Controller
    {
        // GET: /<controller>/
        public IActionResult AgregarDocente()
        {

            return View();

        }
        [HttpPost]
        public IActionResult AgregarDocente(DatosDocente datosDocente, Docente docente)
        {

            if (ModelState.IsValid)
            {

                datosDocente.Docentes.Add(docente);
                return RedirectToAction("VerDocente", docente);
            }

            return View(docente);
        }

        public IActionResult VerDocente(DatosDocente datosDocente)
        {

            return View(datosDocente);
        }


        public IActionResult EditarDocente(Docente docente)
        {

            return View(docente);

        }
        [HttpPost]
        public IActionResult EditarDocente(DatosDocente datosDocente, Docente docente)
        {

            if (ModelState.IsValid)
            {
                var opciones = Request.Form["opciones"];
                foreach (var datos in datosDocente.Docentes)
                {

                    if (datos.ID.ToString() == opciones)
                    {
                        ViewData["Codigo"] = datos.ID;
                        ViewData["Nombre"] = datos.NOMBRE;
                        ViewData["Telefono"] = datos.TELEFONO;
                        ViewData["IDUniversidad"] = datos.ID_UNIVERSIDAD;
                        break;
                    }

                }
                var SaveButton = Request.Form["Save"];
                if (SaveButton == "save")
                {
                    int x = 0;

                    foreach (var datos in datosDocente.Docentes)
                    {
                        if (datos.ID == docente.ID)
                        {
                            break;

                        }
                        x++;
                    }

                    datosDocente.Docentes.RemoveAt(x);
                    datosDocente.Docentes.Add(docente);
                    return RedirectToAction("VerDocente", docente);
                }



            }

            return View(docente);
        }
        public IActionResult EliminarDocente(DatosDocente datosDocente)
        {

            return View(datosDocente);

        }
        [HttpPost]
        public IActionResult EliminarDocente(DatosDocente datosDocente, Docente docente)
        {

            if (ModelState.IsValid)
            {

                var ID = Request.Form["opciones"];
                foreach (var datos in datosDocente.Docentes)
                {

                    if (ID == datos.ID.ToString())
                    {
                        ViewData["Codigo"] = datos.ID;
                        ViewData["Nombre"] = datos.NOMBRE;
                        ViewData["Telefono"] = datos.TELEFONO;
                        ViewData["IDUniversidad"] = datos.ID_UNIVERSIDAD;
                        break;

                    }

                }


                var DeleteButton = Request.Form["Delete"];
                if (DeleteButton == "delete")
                {
                    int x = 0;

                    foreach (var datos in datosDocente.Docentes)
                    {
                        if (datos.ID == datosDocente.IDSelected)
                        {
                            break;

                        }
                        x++;
                    }

                    datosDocente.Docentes.RemoveAt(x);
                    return View("VerDocente", datosDocente);
                }

            }

            return View(datosDocente);
        }

    }
}
