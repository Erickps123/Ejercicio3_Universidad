using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ej3Universidad.Models
{
    public class Alumno
    {
        public int ID { get; set; }
        public string NOMBRE { get; set; }
        public string Cedula { get; set; }
        public string Fecha_Nac { get; set; }

        public int ID_Maestria { get; set; }
    }
    public class DatosAlumnos
    {
        public int[] SelectedItem { get; set; }
        public int IDSelected { get; set; }
        private static List<Alumno> Alumno;
        public List<Alumno> Alumnos
        {
            get
            {
                if (Alumno == null)
                {
                    Alumno = new List<Alumno>();
                }
                return Alumno;
            }
        }
    }
}
