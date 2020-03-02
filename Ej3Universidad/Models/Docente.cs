using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ej3Universidad.Models
{
    public class Docente
    {
        public int ID { get; set; }
        public string NOMBRE { get; set; }
        public string TELEFONO { get; set; }
        public int ID_UNIVERSIDAD { get; set; }
    }
    public class DatosDocente
    {
        public int[] SelectedItem { get; set; }
        public int IDSelected { get; set; }
        private static List<Docente> Docente;
        public List<Docente> Docentes
        {
            get
            {
                if (Docente == null)
                {
                    Docente = new List<Docente>();
                }
                return Docente;
            }
        }
    }
}
