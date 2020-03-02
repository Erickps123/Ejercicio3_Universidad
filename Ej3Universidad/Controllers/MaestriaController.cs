using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Ej3Universidad.Models;
// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ej3Universidad.Controllers
{
    public class MaestriaController : Controller
    {
        // GET: /<controller>/
        public IActionResult AgregarMaestria()
        {

            return View();

        }
        [HttpPost]
        public IActionResult AgregarMaestria(DatosMaestria datosMaestria, Maestria maestria)
        {

            if (ModelState.IsValid)
            {

                datosMaestria.Maestrias.Add(maestria);
                return RedirectToAction("VerMaestria", maestria);
            }

            return View(maestria);
        }

        public IActionResult VerMaestria(DatosMaestria datosMaestria)
        {

            return View(datosMaestria);
        }


        public IActionResult EditarMaestria(Maestria maestria)
        {

            return View(maestria);

        }
        [HttpPost]
        public IActionResult EditarMaestria(DatosMaestria datosMaestria, Maestria maestria)
        {

            if (ModelState.IsValid)
            {
                var opciones = Request.Form["opciones"];
                foreach (var datos in datosMaestria.Maestrias)
                {

                    if (datos.ID.ToString() == opciones)
                    {
                        ViewData["Codigo"] = datos.ID;
                        ViewData["Nombre"] = datos.NOMBRE;
                        ViewData["Duracion"] = datos.DURACION;
                        ViewData["IDDocente"] = datos.ID_DOCENTE;
                        break;
                    }

                }
                var SaveButton = Request.Form["Save"];
                if (SaveButton == "save")
                {
                    int x = 0;

                    foreach (var datos in datosMaestria.Maestrias)
                    {
                        if (datos.ID == maestria.ID)
                        {
                            break;

                        }
                        x++;
                    }

                    datosMaestria.Maestrias.RemoveAt(x);
                    datosMaestria.Maestrias.Add(maestria);
                    return RedirectToAction("VerMaestria", maestria);
                }



            }

            return View(maestria);
        }
        public IActionResult EliminarMaestria(DatosMaestria datosMaestria)
        {

            return View(datosMaestria);

        }
        [HttpPost]
        public IActionResult EliminarMaestria(DatosMaestria datosMaestria, Maestria maestria)
        {

            if (ModelState.IsValid)
            {

                var ID = Request.Form["opciones"];
                foreach (var datos in datosMaestria.Maestrias)
                {

                    if (ID == datos.ID.ToString())
                    {
                        ViewData["Codigo"] = datos.ID;
                        ViewData["Nombre"] = datos.NOMBRE;
                        ViewData["Duracion"] = datos.DURACION;
                        ViewData["IDDocente"] = datos.ID_DOCENTE;
                        break;

                    }

                }


                var DeleteButton = Request.Form["Delete"];
                if (DeleteButton == "delete")
                {
                    int x = 0;

                    foreach (var datos in datosMaestria.Maestrias)
                    {
                        if (datos.ID == datosMaestria.IDSelected)
                        {
                            break;

                        }
                        x++;
                    }

                    datosMaestria.Maestrias.RemoveAt(x);
                    return View("VerMaestria", datosMaestria);
                }

            }

            return View(datosMaestria);
        }


    }
}
