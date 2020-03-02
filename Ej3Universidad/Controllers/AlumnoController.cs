using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Ej3Universidad.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ej3Universidad.Controllers
{
    public class AlumnoController : Controller
    {
        // GET: /<controller>/
        public IActionResult AgregarAlumno()
        {

            return View();

        }
        [HttpPost]
        public IActionResult AgregarAlumno(DatosAlumnos datosAlumnos, Alumno alumno)
        {

            if (ModelState.IsValid)
            {

                datosAlumnos.Alumnos.Add(alumno);
                return RedirectToAction("VerAlumno", alumno);
            }

            return View(alumno);
        }

        public IActionResult VerAlumno(DatosAlumnos datosAlumnos)
        {

            return View(datosAlumnos);
        }


        public IActionResult EditarAlumno(Alumno alumno)
        {

            return View(alumno);

        }
        [HttpPost]
        public IActionResult EditarAlumno(DatosAlumnos datosAlumnos, Alumno alumno)
        {

            if (ModelState.IsValid)
            {
                var opciones = Request.Form["opciones"];
                foreach (var datos in datosAlumnos.Alumnos)
                {

                    if (datos.ID.ToString() == opciones)
                    {
                        ViewData["Codigo"] = datos.ID;
                        ViewData["Nombre"] = datos.NOMBRE;
                        ViewData["Cedula"] = datos.Cedula;
                        ViewData["FechaNac"] = datos.Fecha_Nac;
                        ViewData["IDMaestria"] = datos.ID_Maestria;
                        break;
                    }

                }
                var SaveButton = Request.Form["Save"];
                if (SaveButton == "save")
                {
                    int x = 0;

                    foreach (var datos in datosAlumnos.Alumnos)
                    {
                        if (datos.ID == alumno.ID)
                        {
                            break;

                        }
                        x++;
                    }

                    datosAlumnos.Alumnos.RemoveAt(x);
                    datosAlumnos.Alumnos.Add(alumno);
                    return RedirectToAction("VerAlumno", alumno);
                }



            }

            return View(alumno);
        }
        public IActionResult EliminarAlumno(DatosAlumnos datosAlumnos)
        {

            return View(datosAlumnos);

        }
        [HttpPost]
        public IActionResult EliminarAlumno(DatosAlumnos datosAlumnos, Alumno alumno)
        {

            if (ModelState.IsValid)
            {

                var ID = Request.Form["opciones"];
                foreach (var datos in datosAlumnos.Alumnos)
                {

                    if (ID == datos.ID.ToString())
                    {
                        ViewData["Codigo"] = datos.ID;
                        ViewData["Nombre"] = datos.NOMBRE;
                        ViewData["Cedula"] = datos.Cedula;
                        ViewData["FechaNac"] = datos.Fecha_Nac;
                        ViewData["IDMaestria"] = datos.ID_Maestria;
                        break;

                    }

                }


                var DeleteButton = Request.Form["Delete"];
                if (DeleteButton == "delete")
                {
                    int x = 0;

                    foreach (var data in datosAlumnos.Alumnos)
                    {
                        if (data.ID == datosAlumnos.IDSelected)
                        {
                            break;
                        }
                        x++;
                    }
               
                   datosAlumnos.Alumnos.RemoveAt(x);
                    return View("VerAlumno", datosAlumnos);
                }

            }

            return View(datosAlumnos);
        }


    }
}
