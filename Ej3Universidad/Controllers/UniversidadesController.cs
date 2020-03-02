using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Ej3Universidad.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ej3Universidad.Controllers
{
    public class UniversidadesController : Controller
    {
        // GET: /<controller>/
        public IActionResult AgregarUniversidad()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AgregarUniversidad(DatosUniversidad datosUniversidad, Universidades universidades)
        {
            if (ModelState.IsValid)
            {
                datosUniversidad.Universidades.Add(universidades);
                return RedirectToAction("VerUniversidad", universidades);
            }
            return View(universidades);
        }

        public IActionResult VerUniversidad(DatosUniversidad datosUniversidad)
        {
            return View(datosUniversidad);
        }


        public IActionResult EditarUniversidad(Universidades universidades)
        {

            return View(universidades);

        }
        [HttpPost]
        public IActionResult EditarUniversidad(DatosUniversidad datosUniversidad, Universidades universidades)
        {

            if (ModelState.IsValid)
            {
                var opciones = Request.Form["opciones"];
                foreach (var datos in datosUniversidad.Universidades)
                {

                    if (datos.ID.ToString() == opciones)
                    {
                        ViewData["Codigo"] = datos.ID;
                        ViewData["Nombre"] = datos.NOMBRE;

                        break;
                    }

                }
                var SaveButton = Request.Form["Save"];
                if (SaveButton == "save")
                {
                    int x = 0;

                    foreach (var datos in datosUniversidad.Universidades)
                    {
                        if (datos.ID == universidades.ID)
                        {
                            break;

                        }
                        x++;
                    }

                    datosUniversidad.Universidades.RemoveAt(x);
                    datosUniversidad.Universidades.Add(universidades);
                    return RedirectToAction("VerUniversidad", universidades);
                }



            }

            return View(universidades);
        }

        public IActionResult EliminarUniversidad(DatosUniversidad datosUniversidad)
        {

            return View(datosUniversidad);

        }
        [HttpPost]
        public IActionResult EliminarUniversidad(DatosUniversidad datosUniversidad, Universidades universidades)
        {

            if (ModelState.IsValid)
            {

                var ID = Request.Form["opciones"];
                foreach (var datos in datosUniversidad.Universidades)
                {

                    if (ID == datos.ID.ToString())
                    {
                        ViewData["Codigo"] = datos.ID;
                        ViewData["Nombre"] = datos.NOMBRE;
                        break;

                    }

                }


                var DeleteButton = Request.Form["Delete"];
                if (DeleteButton == "delete")
                {
                    int x = 0;

                    foreach (var datos in datosUniversidad.Universidades)
                    {
                        if (datos.ID == datosUniversidad.IDSelected)
                        {
                            break;

                        }
                        x++;
                    }

                    datosUniversidad.Universidades.RemoveAt(x);
                    return View("VerUniversidad", datosUniversidad);
                }

            }

            return View(datosUniversidad);
        }
    }
}
